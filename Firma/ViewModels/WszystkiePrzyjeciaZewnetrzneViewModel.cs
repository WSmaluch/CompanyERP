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
    public class WszystkiePrzyjeciaZewnetrzneViewModel : WszystkieViewModel<PrzyjecieZewnetrzneForAllView>
    {
        #region Properties
        bool add = false;
        private PrzyjecieZewnetrzneForAllView _WybranePrzyjecieZewnetrzne;
        public PrzyjecieZewnetrzneForAllView WybranePrzyjecieZewnetrzne
        {
            get
            {
                return _WybranePrzyjecieZewnetrzne;
            }
            set
            {
                if (value != _WybranePrzyjecieZewnetrzne)
                {
                    _WybranePrzyjecieZewnetrzne = value;
                    Messenger.Default.Send(_WybranePrzyjecieZewnetrzne);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkiePrzyjeciaZewnetrzneViewModel() : base("Wszystkie przyjecia zewnetrzne")
        {
        }
        public WszystkiePrzyjeciaZewnetrzneViewModel(bool _add) : base("Wszystkie przyjecia zewnetrzne")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>
               (
               from PrzyjecieZewnetrzne in Projekt2Entities.PrzyjecieZewnetrzne
               where PrzyjecieZewnetrzne.CzyAktywny == true
               select new PrzyjecieZewnetrzneForAllView
               {
                   IdPrzyjeciaZewnetrznego = PrzyjecieZewnetrzne.IdPrzyjeciaZewnetrznego,
                   NumerPrzyjecia = PrzyjecieZewnetrzne.NumerPrzyjecia,
                   KontrahentNazwa = PrzyjecieZewnetrzne.Kontrahent.Nazwa,
                   MagazynNazwa = PrzyjecieZewnetrzne.Magazyn.Nazwa,
                   DataWystawienia = PrzyjecieZewnetrzne.DataWystawienia,
                   DataPrzyjecia = PrzyjecieZewnetrzne.DataPrzyjecia,
                   Rabat = PrzyjecieZewnetrzne.Rabat,
                   CzyAktywny = PrzyjecieZewnetrzne.CzyAktywny,
                   KiedyDodal = PrzyjecieZewnetrzne.KiedyDodal,
                   KtoZmodyfikowal = PrzyjecieZewnetrzne.KtoZmodyfikowal,
                   KiedyZmodyfikowal = PrzyjecieZewnetrzne.KiedyZmodyfikowal,
                   KtoUsunal = PrzyjecieZewnetrzne.KtoUsunal,
                   KiedyUsunal = PrzyjecieZewnetrzne.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Numer przyjecia")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.OrderBy(Item => Item.NumerPrzyjecia));
            }
            if (SortField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.OrderBy(Item => Item.KontrahentNazwa));
            }
            if (SortField == "Nazwa magazynu")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.OrderBy(Item => Item.MagazynNazwa));
            }
            if (SortField == "Data wystawienia")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.OrderBy(Item => Item.DataWystawienia));
            }
            if (SortField == "Data przyjecia")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.OrderBy(Item => Item.DataPrzyjecia));
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
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.Where(Item => Item.NumerPrzyjecia != null && Item.NumerPrzyjecia.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.Where(Item => Item.KontrahentNazwa != null && Item.KontrahentNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa magazynu")
            {
                List = new ObservableCollection<PrzyjecieZewnetrzneForAllView>(List.Where(Item => Item.MagazynNazwa != null && Item.MagazynNazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.PrzyjecieZewnetrzne.Where(a => a.IdPrzyjeciaZewnetrznego == WybranePrzyjecieZewnetrzne.IdPrzyjeciaZewnetrznego).FirstOrDefault();
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
