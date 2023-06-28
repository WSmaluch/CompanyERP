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
    public class WszystkieRodzajeVATViewModel : WszystkieViewModel<RodzajVAT>
    {
        #region Properties
        bool add = false;
        private RodzajVAT _WybranyRodzajVAT;
        public RodzajVAT WybranyRodzajVAT
        {
            get
            {
                return _WybranyRodzajVAT;
            }
            set
            {
                if (value != _WybranyRodzajVAT)
                {
                    _WybranyRodzajVAT = value;
                    Messenger.Default.Send(_WybranyRodzajVAT);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieRodzajeVATViewModel() : base("Wszystkie rodzaje VAT")
        {
        }
        public WszystkieRodzajeVATViewModel(bool _add) : base("Wszystkie rodzaje VAT")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<RodzajVAT>
                (
                from RodzajVAT in Projekt2Entities.RodzajVAT
                where RodzajVAT.CzyAktywny == true
                select RodzajVAT
                );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<RodzajVAT>(List.OrderBy(Item => Item.Nazwa));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Stawka" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<RodzajVAT>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Stawka")
            {
                List = new ObservableCollection<RodzajVAT>(List.Where(Item => Item.Stawka != null && Item.Stawka.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Stawka" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.RodzajVAT.Where(a => a.IdRodzajuVAT == WybranyRodzajVAT.IdRodzajuVAT).FirstOrDefault();
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
