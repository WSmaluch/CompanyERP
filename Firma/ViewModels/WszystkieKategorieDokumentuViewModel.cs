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
    public class WszystkieKategorieDokumentuViewModel : WszystkieViewModel<KategoriaDokumentu>
    {
        #region Properties
        bool add = false;
        private KategoriaDokumentu _WybranaKategoriaDokumentu;
        public KategoriaDokumentu WybranaKategoriaDokumentu
        {
            get
            {
                return _WybranaKategoriaDokumentu;
            }
            set
            {
                if (value != _WybranaKategoriaDokumentu)
                {
                    _WybranaKategoriaDokumentu = value;
                    Messenger.Default.Send(_WybranaKategoriaDokumentu);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieKategorieDokumentuViewModel() : base("Wszystkie kategorie dokumentu")
        {
        }
        public WszystkieKategorieDokumentuViewModel(bool _add) : base("Wszystkie kategorie dokumentu")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KategoriaDokumentu>
                (
                from KategoriaDokumentu in Projekt2Entities.KategoriaDokumentu
                where KategoriaDokumentu.CzyAktywny.Value
                select KategoriaDokumentu
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<KategoriaDokumentu>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<KategoriaDokumentu>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.KategoriaDokumentu.Where(a => a.IdKategoriiDokumentu == WybranaKategoriaDokumentu.IdKategoriiDokumentu).FirstOrDefault();
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
