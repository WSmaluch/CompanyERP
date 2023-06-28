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
    public class WszystkieUrzadzeniaViewModel : WszystkieViewModel<UrzadzenieForAllView>
    {
        #region Properties
        bool add = false;
        private UrzadzenieForAllView _WybraneUrzadzenie;
        public UrzadzenieForAllView WybraneUrzadzenie
        {
            get
            {
                return _WybraneUrzadzenie;
            }
            set
            {
                if (value != _WybraneUrzadzenie)
                {
                    _WybraneUrzadzenie = value;
                    Messenger.Default.Send(_WybraneUrzadzenie);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieUrzadzeniaViewModel() : base("Wszystkie urzadzenia")
        {
        }
        public WszystkieUrzadzeniaViewModel(bool _add) : base("Wszystkie urzadzenia")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<UrzadzenieForAllView>
               (
               from Urzadzenie in Projekt2Entities.Urzadzenie
               where Urzadzenie.CzyAktywny == true
               select new UrzadzenieForAllView
               {
                   IdUrzadzenia = Urzadzenie.IdUrzadzenia,
                   Nazwa = Urzadzenie.Nazwa,
                   Opis = Urzadzenie.Opis,
                   Uwagi = Urzadzenie.Uwagi,
                   KategoriaSerwisuNzawa = Urzadzenie.KategorieSerwisu.NazwaUslugi,
                   CzyAktywny = Urzadzenie.CzyAktywny,
                   KiedyDodal = Urzadzenie.KiedyDodal,
                   KtoZmodyfikowal = Urzadzenie.KtoZmodyfikowal,
                   KiedyZmodyfikowal = Urzadzenie.KiedyZmodyfikowal,
                   KtoUsunal = Urzadzenie.KtoUsunal,
                   KiedyUsunal = Urzadzenie.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<UrzadzenieForAllView>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Kategoria serwisu")
            {
                List = new ObservableCollection<UrzadzenieForAllView>(List.OrderBy(Item => Item.KategoriaSerwisuNzawa));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Kategoria serwisu" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<UrzadzenieForAllView>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Kategoria serwisu")
            {
                List = new ObservableCollection<UrzadzenieForAllView>(List.Where(Item => Item.KategoriaSerwisuNzawa != null && Item.KategoriaSerwisuNzawa.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Kategoria serwisu" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Urzadzenie.Where(a => a.IdUrzadzenia == WybraneUrzadzenie.IdUrzadzenia).FirstOrDefault();
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
