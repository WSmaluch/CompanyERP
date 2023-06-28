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
    public class WszystkieTypyKontrahentaViewModel : WszystkieViewModel<TypKontrahenta>
    {
        #region Properties
        bool add = false;
        private TypKontrahenta _WybranyTypKontrahenta;
        public TypKontrahenta WybranyTypKontrahenta
        {
            get
            {
                return _WybranyTypKontrahenta;
            }
            set
            {
                if (value != _WybranyTypKontrahenta)
                {
                    _WybranyTypKontrahenta = value;
                    Messenger.Default.Send(_WybranyTypKontrahenta);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieTypyKontrahentaViewModel() : base("Wszystkie typy kontrahenta")
        {
        }
        public WszystkieTypyKontrahentaViewModel(bool _add) : base("Wszystkie typy kontrahenta")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypKontrahenta>
                (
                from TypKontrahenta in Projekt2Entities.TypKontrahenta
                where TypKontrahenta.CzyAktywny.Value
                select TypKontrahenta
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TypKontrahenta>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<TypKontrahenta>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.TypKontrahenta.Where(a => a.IdTypuKontrahenta == WybranyTypKontrahenta.IdTypuKontrahenta).FirstOrDefault();
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
