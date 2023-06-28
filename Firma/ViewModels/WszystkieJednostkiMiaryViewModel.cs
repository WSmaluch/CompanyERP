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
    public class WszystkieJednostkiMiaryViewModel : WszystkieViewModel<JednostkaMiary>
    {
        #region Properties
        bool add = false;
        private JednostkaMiary _WybranaJednostkaMiary;
        public JednostkaMiary WybranaJednostkaMiary
        {
            get
            {
                return _WybranaJednostkaMiary;
            }
            set
            {
                if (value != _WybranaJednostkaMiary)
                {
                    _WybranaJednostkaMiary = value;
                    Messenger.Default.Send(_WybranaJednostkaMiary);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieJednostkiMiaryViewModel() : base("Wszystkie jednostki miary")
        {
        }
        public WszystkieJednostkiMiaryViewModel(bool _add) : base("Wszystkie jednostki miary")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            bool? dd = false;
            List = new ObservableCollection<JednostkaMiary>
                (
                from JednostkaMiary in Projekt2Entities.JednostkaMiary
                where JednostkaMiary.CzyAktywny.Value 
                select JednostkaMiary
                ); 
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<JednostkaMiary>(List.OrderBy(Item => Item.Nazwa));
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
                List = new ObservableCollection<JednostkaMiary>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
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
                var del = Projekt2Entities.JednostkaMiary.Where(a => a.IdJednostkiMiary == WybranaJednostkaMiary.IdJednostkiMiary).FirstOrDefault();
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
