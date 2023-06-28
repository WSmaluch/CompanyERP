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
    public class WszystkieKrajeViewModel : WszystkieViewModel<Kraj>
    {
        #region Properties
        bool add = false;
        private Kraj _WybranyKraj;
        public Kraj WybranyKraj
        {
            get
            {
                return _WybranyKraj;
            }
            set
            {
                if (value != _WybranyKraj)
                {
                    _WybranyKraj = value;
                    Messenger.Default.Send(_WybranyKraj);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieKrajeViewModel() : base("Wszystkie kraje")
        {
        }
        public WszystkieKrajeViewModel(bool _add) : base("Wszystkie kraje")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Kraj>
                (
                from Kraj in Projekt2Entities.Kraj
                where Kraj.CzyAktywny.Value
                select Kraj
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Kraj>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<Kraj>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.Kraj.Where(a => a.IdKraju == WybranyKraj.IdKraju).FirstOrDefault();
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
