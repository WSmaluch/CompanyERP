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
    public class WszystkieWydaniaZewnetrzneViewModel : WszystkieViewModel<WydanieZewnetrzneForAllView>
    {
        #region Properties
        bool add = false;
        private WydanieZewnetrzneForAllView _WybraneWydanieZewnetrzne;
        public WydanieZewnetrzneForAllView WybraneWydanieZewnetrzne
        {
            get
            {
                return _WybraneWydanieZewnetrzne;
            }
            set
            {
                if (value != _WybraneWydanieZewnetrzne)
                {
                    _WybraneWydanieZewnetrzne = value;
                    Messenger.Default.Send(_WybraneWydanieZewnetrzne);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieWydaniaZewnetrzneViewModel() : base("Wszystkie wydania zewnetrzne")
        {
        }
        public WszystkieWydaniaZewnetrzneViewModel(bool _add) : base("Wszystkie wydania zewnetrzne")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<WydanieZewnetrzneForAllView>
               (
               from WydanieZewnetrzne in Projekt2Entities.WydanieZewnetrzne
               where WydanieZewnetrzne.CzyAktywny == true
               select new WydanieZewnetrzneForAllView
               {
                   IdWydaniaZewnetrznego = WydanieZewnetrzne.IdWydaniaZewnetrznego,
                   NumerPrzyjecia = WydanieZewnetrzne.NumerPrzyjecia,
                   KontrahentNazwa = WydanieZewnetrzne.Kontrahent.Nazwa,
                   MagazynNazwa = WydanieZewnetrzne.Magazyn.Nazwa,
                   DataWystawienia = WydanieZewnetrzne.DataWystawienia,
                   DataPrzyjecia = WydanieZewnetrzne.DataPrzyjecia,
                   Rabat = WydanieZewnetrzne.Rabat,
                   CzyAktywny = WydanieZewnetrzne.CzyAktywny,
                   KiedyDodal = WydanieZewnetrzne.KiedyDodal,
                   KtoZmodyfikowal = WydanieZewnetrzne.KtoZmodyfikowal,
                   KiedyZmodyfikowal = WydanieZewnetrzne.KiedyZmodyfikowal,
                   KtoUsunal = WydanieZewnetrzne.KtoUsunal,
                   KiedyUsunal = WydanieZewnetrzne.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Numer przyjecia")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.OrderBy(Item => Item.NumerPrzyjecia));
            }
            if (SortField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.OrderBy(Item => Item.KontrahentNazwa));
            }
            if (SortField == "Nazwa magazynu")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.OrderBy(Item => Item.MagazynNazwa));
            }
            if (SortField == "Data wystawienia")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.OrderBy(Item => Item.DataWystawienia));
            }
            if (SortField == "Data przyjecia")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.OrderBy(Item => Item.DataPrzyjecia));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa przyjecia", "Nazwa kontrahenta", "Nazwa magazynu", "Data wystawienia", "Data przyjecia" };
        }
        public override void Find()
        {
            if (FindField == "Numer przyjecia")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.Where(Item => Item.NumerPrzyjecia != null && Item.NumerPrzyjecia.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.Where(Item => Item.KontrahentNazwa != null && Item.KontrahentNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa magazynu")
            {
                List = new ObservableCollection<WydanieZewnetrzneForAllView>(List.Where(Item => Item.MagazynNazwa != null && Item.MagazynNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Data wystawienia")
            {
                //List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.Where(Item => Item.DataWystawienia != null && Item.DataWystawienia.StartsWith(FindTextBox)));
            }
            if (FindField == "Data przyjecia")
            {
                //List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.Where(Item => Item.DataPrzyjecia != null && Item.DataPrzyjecia.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer przyjecia", "Nazwa kontrahenta", "Nazwa magazynu", "Data wystawienia", "Data przyjecia" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.WydanieZewnetrzne.Where(a => a.IdWydaniaZewnetrznego == WybraneWydanieZewnetrzne.IdWydaniaZewnetrznego).FirstOrDefault();
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
