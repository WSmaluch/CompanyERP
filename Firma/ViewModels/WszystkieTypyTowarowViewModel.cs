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
    public class WszystkieTypyTowarowViewModel : WszystkieViewModel<TypTowaru>
    {
        #region Properties
        bool add = false;
        private TypTowaru _WybranyTypTowaru;
        public TypTowaru WybranyTypTowaru
        {
            get
            {
                return _WybranyTypTowaru;
            }
            set
            {
                if (value != _WybranyTypTowaru)
                {
                    _WybranyTypTowaru = value;
                    Messenger.Default.Send(_WybranyTypTowaru);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieTypyTowarowViewModel() : base("Wszystkie typy towarow")
        {
        }
        public WszystkieTypyTowarowViewModel(bool _add) : base("Wszystkie typy towarow")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<TypTowaru>
                (
                from TypTowaru in Projekt2Entities.TypTowaru
                where TypTowaru.CzyAktywny == true
                select TypTowaru
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<TypTowaru>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<TypTowaru>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.TypTowaru.Where(a => a.IdTypuTowaru == WybranyTypTowaru.IdTypuTowaru).FirstOrDefault();
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
