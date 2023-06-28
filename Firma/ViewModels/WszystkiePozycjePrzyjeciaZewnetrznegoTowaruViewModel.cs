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
    public class WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel : WszystkieViewModel<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>
    {
        #region Properties
        bool add = false;
        private PozycjaPrzyjeciaZewnetrznegoTowaruForAllView _WybranaPozycjaPrzyjeciaZewnetrznegoTowaru;
        public PozycjaPrzyjeciaZewnetrznegoTowaruForAllView WybranaPozycjaPrzyjeciaZewnetrznegoTowaru
        {
            get
            {
                return _WybranaPozycjaPrzyjeciaZewnetrznegoTowaru;
            }
            set
            {
                if (value != _WybranaPozycjaPrzyjeciaZewnetrznegoTowaru)
                {
                    _WybranaPozycjaPrzyjeciaZewnetrznegoTowaru = value;
                    Messenger.Default.Send(_WybranaPozycjaPrzyjeciaZewnetrznegoTowaru);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel() : base("Wszystkie pozycje przyjecia zewnetrznego towaru")
        {
        }
        public WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel(bool _add) : base("Wszystkie pozycje przyjecia zewnetrznego towaru")
        {
            add = _add; 
        }
        #region Helpers
        public override void Load()
    {
        List = new ObservableCollection<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>
           (
           from PozycjaPrzyjeciaZewnętrznegoTowaru in Projekt2Entities.PozycjaPrzyjeciaZewnętrznegoTowaru
           where PozycjaPrzyjeciaZewnętrznegoTowaru.CzyAktywny == true
           select new PozycjaPrzyjeciaZewnetrznegoTowaruForAllView
           {
               IdPrzyjeciaZewnetrznegoTowaru = PozycjaPrzyjeciaZewnętrznegoTowaru.IdPrzyjeciaZewnetrznegoTowaru,
               TowarNazwa = PozycjaPrzyjeciaZewnętrznegoTowaru.Towar.Nazwa,
               Ilosc = PozycjaPrzyjeciaZewnętrznegoTowaru.Ilosc,
               JednostkiMiaryNazwa = PozycjaPrzyjeciaZewnętrznegoTowaru.JednostkaMiary.Nazwa,
               CenaZakupuPierwotna = PozycjaPrzyjeciaZewnętrznegoTowaru.CenaZakupuPierwotna,
               Rabat = PozycjaPrzyjeciaZewnętrznegoTowaru.Rabat,
               CzyAktywny = PozycjaPrzyjeciaZewnętrznegoTowaru.CzyAktywny,
               KiedyDodal = PozycjaPrzyjeciaZewnętrznegoTowaru.KiedyDodal,
               KtoZmodyfikowal = PozycjaPrzyjeciaZewnętrznegoTowaru.KtoZmodyfikowal,
               KiedyZmodyfikowal = PozycjaPrzyjeciaZewnętrznegoTowaru.KiedyZmodyfikowal,
               KtoUsunal = PozycjaPrzyjeciaZewnętrznegoTowaru.KtoUsunal,
               KiedyUsunal = PozycjaPrzyjeciaZewnętrznegoTowaru.KiedyUsunal
           }
           );
    }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>(List.OrderBy(Item => Item.TowarNazwa));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>(List.OrderBy(Item => Item.Ilosc));
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
                List = new ObservableCollection<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>(List.Where(Item => Item.TowarNazwa != null && Item.TowarNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Ilosc")
            {
                List = new ObservableCollection<PozycjaPrzyjeciaZewnetrznegoTowaruForAllView>(List.Where(Item => Item.Ilosc != null && Item.Ilosc.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.PozycjaPrzyjeciaZewnętrznegoTowaru.Where(a => a.IdPrzyjeciaZewnetrznegoTowaru == WybranaPozycjaPrzyjeciaZewnetrznegoTowaru.IdPrzyjeciaZewnetrznegoTowaru).FirstOrDefault();
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
