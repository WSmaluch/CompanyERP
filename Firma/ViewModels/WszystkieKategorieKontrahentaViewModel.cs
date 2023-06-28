using Firma.Models;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Firma.ViewModels
{
    public class WszystkieKategorieKontrahentaViewModel : WszystkieViewModel<KategoriaKontrahenta>
    {
        #region Properties
        bool add = false;
        private KategoriaKontrahenta _WybranaKategoriaKontrahenta;
        public KategoriaKontrahenta WybranaKategoriaKontrahenta
        {
            get
            {
                return _WybranaKategoriaKontrahenta;
            }
            set
            {
                if (value != _WybranaKategoriaKontrahenta)
                {
                    _WybranaKategoriaKontrahenta = value;
                    Messenger.Default.Send(_WybranaKategoriaKontrahenta);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieKategorieKontrahentaViewModel() : base("Wszystkie kategorie kontrahenta")
        {
        }
        public WszystkieKategorieKontrahentaViewModel(bool _add) : base("Wszystkie kategorie kontrahenta")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KategoriaKontrahenta>
                (
                from KategoriaKontrahenta in Projekt2Entities.KategoriaKontrahenta
                where KategoriaKontrahenta.CzyAktywny.Value
                select KategoriaKontrahenta
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<KategoriaKontrahenta>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<KategoriaKontrahenta>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.KategoriaKontrahenta.Where(a => a.IdKategoriiKontrahenta == WybranaKategoriaKontrahenta.IdKategoriiKontrahenta).FirstOrDefault();
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
