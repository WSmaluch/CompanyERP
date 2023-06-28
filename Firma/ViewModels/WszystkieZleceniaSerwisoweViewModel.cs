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
    public class WszystkieZleceniaSerwisoweViewModel : WszystkieViewModel<ZlecenieSerwisoweForAllView>
    {
        #region Properties
        bool add = false;
        private ZlecenieSerwisoweForAllView _WybraneZlecenieSerwisowe;
        public ZlecenieSerwisoweForAllView WybraneZlecenieSerwisowe
        {
            get
            {
                return _WybraneZlecenieSerwisowe;
            }
            set
            {
                if (value != _WybraneZlecenieSerwisowe)
                {
                    _WybraneZlecenieSerwisowe = value;
                    Messenger.Default.Send(_WybraneZlecenieSerwisowe);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieZleceniaSerwisoweViewModel() : base("Wszystkie zlecenia seriwsowe")
        {
        }
        public WszystkieZleceniaSerwisoweViewModel(bool _add) : base("Wszystkie zlecenia seriwsowe")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZlecenieSerwisoweForAllView>
               (
               from ZlecenieSerwisowe in Projekt2Entities.ZlecenieSerwisowe
               where ZlecenieSerwisowe.CzyAktywny == true
               select new ZlecenieSerwisoweForAllView
               {
                   IdZleceniaSerwisowego = ZlecenieSerwisowe.IdZleceniaSerwisowego,
                   KontrahentaNazwa = ZlecenieSerwisowe.Kontrahent.Nazwa,
                   KategoriiSerwisuNazwa = ZlecenieSerwisowe.KategorieSerwisu.NazwaUslugi,
                   UrzadzeniaNazwa = ZlecenieSerwisowe.Urzadzenie.Nazwa,
                   MagazynuNazwa = ZlecenieSerwisowe.Magazyn.Nazwa,
                   SerwisantNazwisko = ZlecenieSerwisowe.Serwisanci.Nazwisko,
                   Priorytet = ZlecenieSerwisowe.Priorytet,
                   DataPrzyjecia = ZlecenieSerwisowe.DataPrzyjecia,
                   DataRealizacji = ZlecenieSerwisowe.DataRealizacji,
                   PlanowanyCzas = ZlecenieSerwisowe.PlanowanyCzas,
                   RzeczywistyCzas = ZlecenieSerwisowe.RzeczywistyCzas,
                   Opis = ZlecenieSerwisowe.Opis,
                   Status = ZlecenieSerwisowe.Status,
                   CzyAktywny = ZlecenieSerwisowe.CzyAktywny,
                   KiedyDodal = ZlecenieSerwisowe.KiedyDodal,
                   KtoZmodyfikowal = ZlecenieSerwisowe.KtoZmodyfikowal,
                   KiedyZmodyfikowal = ZlecenieSerwisowe.KiedyZmodyfikowal,
                   KtoUsunal = ZlecenieSerwisowe.KtoUsunal,
                   KiedyUsunal = ZlecenieSerwisowe.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Kontrahent")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.KontrahentaNazwa));
            }
            if (SortField == "Kategoria serwisu")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.KategoriiSerwisuNazwa));
            }
            if (SortField == "Urzadzenia")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.UrzadzeniaNazwa));
            }
            if (SortField == "Magazyn")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.MagazynuNazwa));
            }
            if (SortField == "Priorytet")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.Priorytet));
            }
            if (SortField == "Data przyjecia")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.DataPrzyjecia));
            }
            if (SortField == "Planowany czas")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.PlanowanyCzas));
            }
            if (SortField == "Status")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.OrderBy(Item => Item.Status));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Kontrahent", "Kategoria serwisu" , "Urzadzenia", "Magazyn", "Priorytet", "Data przyjecia", "Planowany czas" , "Status" };
        }
        public override void Find()
        {
            if (FindField == "Kontrahent")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.KontrahentaNazwa != null && Item.KontrahentaNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Kategoria serwisu")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.KategoriiSerwisuNazwa != null && Item.KategoriiSerwisuNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Urzadzenia")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.UrzadzeniaNazwa != null && Item.UrzadzeniaNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Magazyn")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.MagazynuNazwa != null && Item.MagazynuNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Priorytet")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.Priorytet != null && Item.Priorytet.StartsWith(FindTextBox)));
            }
            if (SortField == "Data przyjecia")
            {
               // List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.DataPrzyjecia != null && Item.DataPrzyjecia.StartsWith(FindTextBox)));
            }
            if (SortField == "Planowany czas")
            {
                //List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.PlanowanyCzas != null && Item.PlanowanyCzas.StartsWith(FindTextBox)));
            }
            if (SortField == "Status")
            {
                List = new ObservableCollection<ZlecenieSerwisoweForAllView>(List.Where(Item => Item.Status != null && Item.Status.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Kontrahent", "Kategoria serwisu", "Urzadzenia", "Magazyn", "Priorytet", "Data przyjecia", "Planowany czas", "Status" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.ZlecenieSerwisowe.Where(a => a.IdZleceniaSerwisowego == WybraneZlecenieSerwisowe.IdZleceniaSerwisowego).FirstOrDefault();
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
