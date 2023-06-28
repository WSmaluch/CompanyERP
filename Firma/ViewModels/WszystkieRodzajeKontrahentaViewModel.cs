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
    public class WszystkieRodzajeKontrahentaViewModel : WszystkieViewModel<RodzajKontrahenta>
    {
        #region Properties
        bool add = false;
        private RodzajKontrahenta _WybranyRodzajKontrahenta;
        public RodzajKontrahenta WybranyRodzajKontrahenta
        {
            get
            {
                return _WybranyRodzajKontrahenta;
            }
            set
            {
                if (value != _WybranyRodzajKontrahenta)
                {
                    _WybranyRodzajKontrahenta = value;
                    Messenger.Default.Send(_WybranyRodzajKontrahenta);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieRodzajeKontrahentaViewModel() : base("Wszystkie rodzaje kontrahenta")
        {
        }
        public WszystkieRodzajeKontrahentaViewModel(bool _add) : base("Wszystkie rodzaje kontrahenta")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajKontrahenta>
                (
                from RodzajKontrahenta in Projekt2Entities.RodzajKontrahenta
                where RodzajKontrahenta.CzyAktywny.Value
                select RodzajKontrahenta
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<RodzajKontrahenta>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<RodzajKontrahenta>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.RodzajKontrahenta.Where(a => a.IdRodzajKontrahenta == WybranyRodzajKontrahenta.IdRodzajKontrahenta).FirstOrDefault();
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
