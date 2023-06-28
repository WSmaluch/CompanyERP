using Firma.Helpers;
using Firma.Models;
using Firma.Models.Entities;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        private readonly Projekt2Entities projekt2Entities;
        public Projekt2Entities Projekt2Entities
        {
            get
            {
                return projekt2Entities;
            }
        }
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());
                }
                return _LoadCommand;
            }
        }
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        private BaseCommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        private BaseCommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new BaseCommand(() => delete());
                }
                return _DeleteCommand;
            }
        }

        #endregion
        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;
            this.projekt2Entities = new Projekt2Entities();
        }
        #endregion
        #region SortAndField
        private BaseCommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }
        public abstract void Sort();
        public string SortField { get; set; }
        public List<string> SortComboBoxItems
        {
            get
            {
                return GetComboBoxSortList();
            }
        }
        public abstract List<string> GetComboBoxSortList();
        private BaseCommand _FindCommand;
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => Find());
                }
                return _FindCommand;
            }
        }
        public abstract void Find();
        public string FindField { get; set; }
        public string FindTextBox { get; set; }
        public List<string> FindComboBoxItems
        {
            get
            {
                return GetComboBoxFindList();
            }
        }
        public abstract List<string> GetComboBoxFindList();

        private BaseCommand _ResetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_ResetCommand == null)
                {
                    _ResetCommand = new BaseCommand(() => Load());
                }
                return _ResetCommand;
            }
        }
        #endregion

        #region Helpers
        public abstract void Load();
        public void add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        public virtual void delete()
        {
            
        }
        #endregion
    }
}
