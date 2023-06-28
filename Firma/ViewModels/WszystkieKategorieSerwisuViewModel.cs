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
    public class WszystkieKategorieSerwisuViewModel : WszystkieViewModel<KategorieSerwisu>
    {
        #region Properties
        bool add = false;
        private KategorieSerwisu _WybranaKategoriaSerwisu;
        public KategorieSerwisu WybranaKategoriaSerwisu
        {
            get
            {
                return _WybranaKategoriaSerwisu;
            }
            set
            {
                if (value != _WybranaKategoriaSerwisu)
                {
                    _WybranaKategoriaSerwisu = value;
                    Messenger.Default.Send(_WybranaKategoriaSerwisu);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieKategorieSerwisuViewModel() : base("Wszystkie kategorie serwisu")
        {
        }
        public WszystkieKategorieSerwisuViewModel(bool _add) : base("Wszystkie kategorie serwisu")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KategorieSerwisu>
                (
                from KategorieSerwisu in Projekt2Entities.KategorieSerwisu
                where KategorieSerwisu.CzyAktywny == true
                select KategorieSerwisu
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<KategorieSerwisu>(List.OrderBy(Item => Item.NazwaUslugi));
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
                List = new ObservableCollection<KategorieSerwisu>(List.Where(Item => Item.NazwaUslugi != null && Item.NazwaUslugi.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.KategorieSerwisu.Where(a => a.IdKategoriiSerwisu == WybranaKategoriaSerwisu.IdKategoriiSerwisu).FirstOrDefault();
                if (del != null)
                {
                    del.CzyAktywny = false;
                    del.KiedyUsunal = (DateTime.Now).ToString();
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
