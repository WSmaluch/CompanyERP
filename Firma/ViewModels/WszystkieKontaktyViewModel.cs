using Firma.Models;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Firma.ViewModels
{
    public class WszystkieKontaktyViewModel : WszystkieViewModel<Kontakt>
    {
        #region Properties
        bool add = false;
        private Kontakt _WybranyKontakt;
        public Kontakt WybranyKontakt
        {
            get
            {
                return _WybranyKontakt;
            }
            set
            {
                if (value != _WybranyKontakt)
                {
                    _WybranyKontakt = value;
                    Messenger.Default.Send(_WybranyKontakt);
                    if(add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieKontaktyViewModel() : base("Wszystkie kontakty")
        {
        }
        public WszystkieKontaktyViewModel(bool _add) : base("Wszystkie kontakty")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Kontakt>
                (
                from Kontakt in Projekt2Entities.Kontakt
                where Kontakt.CzyAktywny.Value
                select Kontakt
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa działu")
            {
                List = new ObservableCollection<Kontakt>(List.OrderBy(Item => Item.NazwaDzialu));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa działu" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa działu")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.NazwaDzialu != null && Item.NazwaDzialu.StartsWith(FindTextBox)));
            }
            if (FindField == "Telefon")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.Telefon1 != null && Item.Telefon1.StartsWith(FindTextBox)));
            }
            else if (FindField == "Telefon")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.Telefon2 != null && Item.Telefon2.StartsWith(FindTextBox)));
            }
            if (FindField == "Email")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.Email1 != null && Item.Email1.StartsWith(FindTextBox)));
            }
            else if (FindField == "Email")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.Email2 != null && Item.Email2.StartsWith(FindTextBox)));
            }
            if (FindField == "Fax")
            {
                List = new ObservableCollection<Kontakt>(List.Where(Item => Item.Fax != null && Item.Fax.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Telefon", "Email","Fax" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Kontakt.Where(a => a.IdKontaktu == WybranyKontakt.IdKontaktu).FirstOrDefault();
                if (del != null)
                {
                    del.CzyAktywny = false;
                    del.KiedyUsunal = DateTime.Now;
                    del.KtoUsunal = Environment.MachineName;
                    Projekt2Entities.SaveChanges();
                    Load();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Proszę o zaznaczenie!", "Uwaga!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
