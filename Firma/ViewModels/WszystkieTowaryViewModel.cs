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
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowarForAllView>
    {
        #region Properties
        bool add = false;
        private TowarForAllView _WybranyTowar;
        public TowarForAllView WybranyTowar
        {
            get
            {
                return _WybranyTowar;
            }
            set
            {
                if (value != _WybranyTowar)
                {
                    _WybranyTowar = value;
                    Messenger.Default.Send(_WybranyTowar);
                    OnRequestClose();
                }
            }
        }
        #endregion
        public WszystkieTowaryViewModel() : base("Wszystkie towary")
        {
        }
        public WszystkieTowaryViewModel(bool _add) : base("Wszystkie towary")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TowarForAllView>
               (
               from Towar in Projekt2Entities.Towar
               where Towar.CzyAktywny == true
               select new TowarForAllView
               {
                   IdTowaru = Towar.IdTowaru,
                   Kod = Towar.Kod,
                   Nazwa = Towar.Nazwa,
                   KodKreskowy = Towar.KodKreskowy,
                   NrKatalogowy = Towar.NrKatalogowy,
                   JednostkiMiaryNazwa = Towar.JednostkaMiary.Nazwa,
                   PKWiU = Towar.PKWiU,
                   TypTowaruNazwa = Towar.TypTowaru.Nazwa,
                   StawkaVATSprzedazyStawka = Towar.RodzajVAT.Stawka,
                   StawkaVATZakupuStawka = Towar.RodzajVAT.Stawka,
                   StawkaVATKaucjiStawka = Towar.RodzajVAT.Stawka,
                   CzyAktywny = Towar.CzyAktywny,
                   KiedyDodal = Towar.KiedyDodal,
                   KtoZmodyfikowal = Towar.KtoZmodyfikowal,
                   KiedyZmodyfikowal = Towar.KiedyZmodyfikowal,
                   KtoUsunal = Towar.KtoUsunal,
                   KiedyUsunal = Towar.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Kod")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.Kod));
            }
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Kod kreskowy")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.KodKreskowy));
            }
            if (SortField == "Jednostka miary")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.JednostkiMiaryNazwa));
            }
            if (SortField == "Typ towaru")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.TypTowaruNazwa));
            }
            if (SortField == "Stawka VAT sprzedazy")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.StawkaVATSprzedazyStawka));
            }
            if (SortField == "Stawka VAT zakupu")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.StawkaVATZakupuStawka));
            }
            if (SortField == "Stawka VAT kaucji")
            {
                List = new ObservableCollection<TowarForAllView>(List.OrderBy(Item => Item.StawkaVATKaucjiStawka));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Kod","Nazwa","Kod kreskowy","Jednostka miary", "Typ towaru", "Stawka VAT sprzedazy", "Stawka VAT zakupu", "Stawka VAT kaucj" };
        }
        public override void Find()
        {
            if (SortField == "Kod")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.Kod != null && Item.Kod.StartsWith(FindTextBox)));
            }
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Kod kreskowy")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.KodKreskowy != null && Item.KodKreskowy.StartsWith(FindTextBox)));
            }
            if (SortField == "Jednostka miary")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.JednostkiMiaryNazwa != null && Item.JednostkiMiaryNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Typ towaru")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.TypTowaruNazwa != null && Item.TypTowaruNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Stawka VAT sprzedazy")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.StawkaVATSprzedazyStawka != null && Item.StawkaVATSprzedazyStawka.StartsWith(FindTextBox)));
            }
            if (SortField == "Stawka VAT zakupu")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.StawkaVATZakupuStawka != null && Item.StawkaVATZakupuStawka.StartsWith(FindTextBox)));
            }
            if (SortField == "Stawka VAT kaucji")
            {
                List = new ObservableCollection<TowarForAllView>(List.Where(Item => Item.StawkaVATKaucjiStawka != null && Item.StawkaVATKaucjiStawka.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Kod", "Nazwa", "Kod kreskowy", "Jednostka miary", "Typ towaru", "Stawka VAT sprzedazy", "Stawka VAT zakupu", "Stawka VAT kaucj" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Towar.Where(a => a.IdTowaru == WybranyTowar.IdTowaru).FirstOrDefault();
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
