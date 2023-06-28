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
    public class WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel : WszystkieViewModel<PozycjaWydaniaZewnetrznegoTowaruForAllView>
    {
        #region Properties
        bool add = false;
        private PozycjaWydaniaZewnetrznegoTowaruForAllView _WybranaPozycjaWydaniaZewnetrznegoTowaru;
        public PozycjaWydaniaZewnetrznegoTowaruForAllView WybranaPozycjaWydaniaZewnetrznegoTowaru
        {
            get
            {
                return _WybranaPozycjaWydaniaZewnetrznegoTowaru;
            }
            set
            {
                if (value != _WybranaPozycjaWydaniaZewnetrznegoTowaru)
                {
                    _WybranaPozycjaWydaniaZewnetrznegoTowaru = value;
                    Messenger.Default.Send(_WybranaPozycjaWydaniaZewnetrznegoTowaru);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel() : base("Wszystkie pozycje wydania zewnetrznego towaru")
        {
        }
        public WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel(bool _add) : base("Wszystkie pozycje wydania zewnetrznego towaru")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PozycjaWydaniaZewnetrznegoTowaruForAllView>
               (
               from PozycjaWydaniaZewnetrznegoTowaru in Projekt2Entities.PozycjaWydaniaZewnetrznegoTowaru
               where PozycjaWydaniaZewnetrznegoTowaru.CzyAktywny == true
               select new PozycjaWydaniaZewnetrznegoTowaruForAllView
               {
                   IdPozycjaWydaniaZewnetrznegoTowaru = PozycjaWydaniaZewnetrznegoTowaru.IdPozycjaWydaniaZewnetrznegoTowaru,
                   TowarNazwa = PozycjaWydaniaZewnetrznegoTowaru.Towar.Nazwa,
                   Ilosc = PozycjaWydaniaZewnetrznegoTowaru.Ilosc,
                   JednostkiMiaryNazwa = PozycjaWydaniaZewnetrznegoTowaru.JednostkaMiary.Nazwa,
                   CenaZakupuPierwotna = PozycjaWydaniaZewnetrznegoTowaru.CenaZakupuPierwotna,
                   Rabat = PozycjaWydaniaZewnetrznegoTowaru.Rabat,
                   CzyAktywny = PozycjaWydaniaZewnetrznegoTowaru.CzyAktywny,
                   KiedyDodal = PozycjaWydaniaZewnetrznegoTowaru.KiedyDodal,
                   KtoZmodyfikowal = PozycjaWydaniaZewnetrznegoTowaru.KtoZmodyfikowal,
                   KiedyZmodyfikowal = PozycjaWydaniaZewnetrznegoTowaru.KiedyZmodyfikowal,
                   KtoUsunal = PozycjaWydaniaZewnetrznegoTowaru.KtoUsunal,
                   KiedyUsunal = PozycjaWydaniaZewnetrznegoTowaru.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjaWydaniaZewnetrznegoTowaruForAllView>(List.OrderBy(Item => Item.TowarNazwa));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<PozycjaWydaniaZewnetrznegoTowaruForAllView>(List.OrderBy(Item => Item.Ilosc));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa towaru", "Ilosc" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjaWydaniaZewnetrznegoTowaruForAllView>(List.Where(Item => Item.TowarNazwa != null && Item.TowarNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Ilosc")
            {
                List = new ObservableCollection<PozycjaWydaniaZewnetrznegoTowaruForAllView>(List.Where(Item => Item.Ilosc != null && Item.Ilosc.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.PozycjaWydaniaZewnetrznegoTowaru.Where(a => a.IdPozycjaWydaniaZewnetrznegoTowaru == WybranaPozycjaWydaniaZewnetrznegoTowaru.IdPozycjaWydaniaZewnetrznegoTowaru).FirstOrDefault();
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
