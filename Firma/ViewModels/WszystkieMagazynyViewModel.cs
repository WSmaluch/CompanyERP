using Firma.Models;
using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firma.ViewModels
{
    public class WszystkieMagazynyViewModel : WszystkieViewModel<Magazyn>
    {
        #region Properties
        bool add = false;
        private Magazyn _WybranyMagazyn;
        public Magazyn WybranyMagazyn
        {
            get
            {
                return _WybranyMagazyn;
            }
            set
            {
                if (value != _WybranyMagazyn)
                {
                    _WybranyMagazyn = value;
                    Messenger.Default.Send(_WybranyMagazyn);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieMagazynyViewModel() : base("Wszystkie magazyny")
        {
        }
        public WszystkieMagazynyViewModel(bool _add) : base("Wszystkie magazyny")
        {
            add = _add; 
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Magazyn>
                (
                from Magazyn in Projekt2Entities.Magazyn
                where Magazyn.CzyAktywny.Value
                select Magazyn
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Magazyn>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Symbol")
            {
                List = new ObservableCollection<Magazyn>(List.OrderBy(Item => Item.Symbol));
            }
            if (SortField == "Typ")
            {
                List = new ObservableCollection<Magazyn>(List.OrderBy(Item => Item.Typ));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Symbol", "Typ" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Magazyn>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Symbol")
            {
                List = new ObservableCollection<Magazyn>(List.Where(Item => Item.Symbol != null && Item.Symbol.StartsWith(FindTextBox)));
            }
            if (FindField == "Typ")
            {
                List = new ObservableCollection<Magazyn>(List.Where(Item => Item.Typ != null && Item.Typ.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Symbol","Typ" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Magazyn.Where(a => a.IdMagazynu == WybranyMagazyn.IdMagazynu).FirstOrDefault();
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
