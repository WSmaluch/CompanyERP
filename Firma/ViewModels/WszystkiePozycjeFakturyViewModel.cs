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
    public class WszystkiePozycjeFakturyViewModel: WszystkieViewModel<PozycjaFakturyForAllView>
    {
        #region Properties
        bool add = false;
        private PozycjaFakturyForAllView _WybranaPozycjaFaktury;
        public PozycjaFakturyForAllView WybranaPozycjaFaktury
        {
            get
            {
                return _WybranaPozycjaFaktury;
            }
            set
            {
                if (value != _WybranaPozycjaFaktury)
                {
                    _WybranaPozycjaFaktury = value;
                    Messenger.Default.Send(_WybranaPozycjaFaktury);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkiePozycjeFakturyViewModel() : base("Wszystkie pozycje faktury")
        {
        }
        public WszystkiePozycjeFakturyViewModel(bool _add) : base("Wszystkie pozycje faktury")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PozycjaFakturyForAllView>
               (
               from PozycjaFaktury in Projekt2Entities.PozycjaFaktury
               where PozycjaFaktury.CzyAktywny == true
               select new PozycjaFakturyForAllView
               {
                   IdPozycjiFaktury = PozycjaFaktury.IdPozycjiFaktury,
                   DokumentNumer = PozycjaFaktury.Dokument.IdDokumentu,
                   TowarNazwa = PozycjaFaktury.Towar.Nazwa,
                   Cena = PozycjaFaktury.Cena,
                   Ilosc = PozycjaFaktury.Ilosc,
                   Rabat = PozycjaFaktury.Rabat,
                   CzyAktywny = PozycjaFaktury.CzyAktywny,
                   KiedyDodal = PozycjaFaktury.KiedyDodal,
                   KtoZmodyfikowal = PozycjaFaktury.KtoZmodyfikowal,
                   KiedyZmodyfikowal = PozycjaFaktury.KiedyZmodyfikowal,
                   KtoUsunal = PozycjaFaktury.KtoUsunal,
                   KiedyUsunal = PozycjaFaktury.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Numer dokumentu")
            {
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(Item => Item.DokumentNumer));
            }
            if (SortField == "Nazwa towaru")
            {
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(Item => Item.TowarNazwa));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(Item => Item.Cena));
            }
            if (SortField == "Ilosc")
            {
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(Item => Item.Ilosc));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Numer dokumentu" };
        }
        public override void Find()
        {
            if (FindField == "Numer dokumentu")
            {
                //List = new ObservableCollection<PozycjaFakturyForAllView>(List.Where(Item => Item.DokumentNumer != null && Item.DokumentNumer.StartsWith(FindTextBox)));
            }
            if (SortField == "Cena")
            {
                List = new ObservableCollection<PozycjaFakturyForAllView>(List.OrderBy(Item => Item.Cena));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Numer dokumentu","Cena" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.PozycjaFaktury.Where(a => a.IdPozycjiFaktury == WybranaPozycjaFaktury.IdPozycjiFaktury).FirstOrDefault();
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
