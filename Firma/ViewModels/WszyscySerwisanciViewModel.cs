using Firma.Helpers;
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
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class WszyscySerwisanciViewModel:WszystkieViewModel<SerwisanciForAllView>
    {
        bool add = false;
        #region Properties
        private SerwisanciForAllView _WybranySerwisant;
        public SerwisanciForAllView WybranySerwisant
        {
            get
            {
                return _WybranySerwisant;
            }
            set
            {
                if (value != _WybranySerwisant)
                {
                    _WybranySerwisant = value;
                    Messenger.Default.Send(_WybranySerwisant);
                    if(add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszyscySerwisanciViewModel() : base("Wszyscy serwisanci")
        {
        }
        public WszyscySerwisanciViewModel(bool _add) : base("Wszyscy serwisanci")
        {
            add= _add;
        }

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SerwisanciForAllView>
               (
               from Serwisanci in Projekt2Entities.Serwisanci
               where Serwisanci.CzyAktywny == true
               select new SerwisanciForAllView
               {
                   IdSerwisanta = Serwisanci.IdSerwisanta,
                   Imie = Serwisanci.Imie,
                   Nazwisko = Serwisanci.Nazwisko,
                   NazwaFirmy = Serwisanci.NazwaFirmy,
                   KategoriaSerwisuNazwa = Serwisanci.KategorieSerwisu.NazwaUslugi,
                   Koszt = Serwisanci.Koszt,
                   CzyAktywny = Serwisanci.CzyAktywny,
                   KtoDodal = Serwisanci.KtoDodal,
                   KiedyDodal = Serwisanci.KiedyDodal,
                   KtoZmodyfikowal = Serwisanci.KtoZmodyfikowal,
                   KiedyZmodyfikowal = Serwisanci.KiedyZmodyfikowal,
                   KtoUsunal = Serwisanci.KtoUsunal,
                   KiedyUsunal = Serwisanci.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<SerwisanciForAllView>(List.OrderBy(Item => Item.Nazwisko));
            }
            if (SortField == "Nazwa firmy")
            {
                List = new ObservableCollection<SerwisanciForAllView>(List.OrderBy(Item => Item.NazwaFirmy));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwisko", "Nazwa firmy" };
        }
        public override void Find()
        {
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<SerwisanciForAllView>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa firmy")
            {
                List = new ObservableCollection<SerwisanciForAllView>(List.Where(Item => Item.NazwaFirmy != null && Item.NazwaFirmy.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwisko", "Nazwa firmy" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Serwisanci.Where(a => a.IdSerwisanta == WybranySerwisant.IdSerwisanta).FirstOrDefault();
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
