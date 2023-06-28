using Firma.Models;
using Firma.Models.EntitiesForView;
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
    public class WszystkieAdresyViewModel : WszystkieViewModel<AdresForAllView>
    {
        #region Properties
        bool add = false;
        private AdresForAllView _WybranyAdres;
        public AdresForAllView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                if (value != _WybranyAdres)
                {
                    _WybranyAdres = value;
                    Messenger.Default.Send(_WybranyAdres);
                    if(add)
                    {
                        OnRequestClose();
                    }
                    
                }
            }
        }
        #endregion
        public WszystkieAdresyViewModel() : base("Wszystkie adresy")
        {
        }
        public WszystkieAdresyViewModel(bool _add) : base("Wszystkie adresy")
        {
            add = _add;
        }

        #region Helpers
        public override void Load()
    {
        List = new ObservableCollection<AdresForAllView>
           (
           from Adres in Projekt2Entities.Adres
           where Adres.CzyAktywny == true
           select new AdresForAllView
           {
               IdAdresu = Adres.IdAdresu,
               Kod = Adres.Kod,
               Miejscowosc = Adres.Miejscowosc,
               KodPocztowy = Adres.KodPocztowy,
               Poczta = Adres.Poczta,
               Ulica = Adres.Ulica,
               NumerDomu = Adres.NumerDomu,
               NumerLokalu = Adres.NumerLokalu,
               KrajNazwa = Adres.Kraj.Nazwa,
               CzyAktywny = Adres.CzyAktywny,
               KiedyDodal = Adres.KiedyDodal,
               KtoZmodyfikowal = Adres.KtoZmodyfikowal,
               KiedyZmodyfikowal = Adres.KiedyZmodyfikowal,
               KtoUsunal = Adres.KtoUsunal,
               KiedyUsunal = Adres.KiedyUsunal
           }
           );
    }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Miejscowosc")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.Miejscowosc));
            }
            if (SortField == "Kraj")
            {
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(Item => Item.KrajNazwa));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Miejscowosc", "Kraj" };
        }
        public override void Find()
        {
            if (FindField == "Miejscowosc")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.Miejscowosc != null && Item.Miejscowosc.StartsWith(FindTextBox)));
            }
            if (FindField == "Kraj")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.KrajNazwa != null && Item.KrajNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Ulica")
            {
                List = new ObservableCollection<AdresForAllView>(List.Where(Item => Item.Ulica != null && Item.Ulica.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Miejscowosc", "Kraj" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Adres.Where(a => a.IdAdresu == WybranyAdres.IdAdresu).FirstOrDefault();
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
