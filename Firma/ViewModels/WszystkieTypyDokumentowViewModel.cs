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
    public class WszystkieTypyDokumentowViewModel : WszystkieViewModel<TypDokumentu>
    {
        #region Properties
        bool add = false;
        private TypDokumentu _WybranyTypDokumentu;
        public TypDokumentu WybranyTypDokumentu
        {
            get
            {
                return _WybranyTypDokumentu;
            }
            set
            {
                if (value != _WybranyTypDokumentu)
                {
                    _WybranyTypDokumentu = value;
                    Messenger.Default.Send(_WybranyTypDokumentu);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieTypyDokumentowViewModel() : base("Wszystkie typy dokumentow")
        {
        }
        public WszystkieTypyDokumentowViewModel(bool _add) : base("Wszystkie typy dokumentow")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypDokumentu>
                (
                from TypDokumentu in Projekt2Entities.TypDokumentu
                where TypDokumentu.CzyAktywny == true
                select TypDokumentu
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TypDokumentu>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<TypDokumentu>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.TypDokumentu.Where(a => a.IdTypuDokumentu == WybranyTypDokumentu.IdTypuDokumentu).FirstOrDefault();
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
