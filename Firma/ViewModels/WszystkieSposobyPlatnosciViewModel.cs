using Firma.Models;
using Firma.Models.Entities;
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
    public class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobPlatnosci>
    {
        #region Properties
        bool add = false;
        private SposobPlatnosci _WybranySposobPlatnosci;
        public SposobPlatnosci WybranySposobPlatnosci
        {
            get
            {
                return _WybranySposobPlatnosci;
            }
            set
            {
                if (value != _WybranySposobPlatnosci)
                {
                    _WybranySposobPlatnosci = value;
                    Messenger.Default.Send(_WybranySposobPlatnosci);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieSposobyPlatnosciViewModel() : base("Wszystkie sposoby platnosci")
        {
        }
        public WszystkieSposobyPlatnosciViewModel(bool _add) : base("Wszystkie sposoby platnosci")
        {
            add = _add; 
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<SposobPlatnosci>
                (
                from SposobPlatnosci in Projekt2Entities.SposobPlatnosci
                where SposobPlatnosci.CzyAktywny == true
                select SposobPlatnosci
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<SposobPlatnosci>(List.OrderBy(Item => Item.Nazwa));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<SposobPlatnosci>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.SposobPlatnosci.Where(a => a.IdSposobuPlatnosci == WybranySposobPlatnosci.IdSposobuPlatnosci).FirstOrDefault();
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
