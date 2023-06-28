using Firma.Helpers;
using Firma.Models;
using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Firma.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public Projekt2Entities Db { get; set; }
        public T Item { get; set; }

        #endregion
        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;
            Db = new Projekt2Entities();
        }
        #endregion
        #region Command
        public ICommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }


        private BaseCommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new BaseCommand(() => CloseView());
                }
                return _CancelCommand;
            }
        }

        private void CloseView()
        {
            base.OnRequestClose();
        }

        #endregion
        #region Save
        public abstract void Save();
        public virtual bool IsValid()
        {
            return true;
        }
        private void saveAndClose()
        {
            if (IsValid())
            {
                Save();
                base.OnRequestClose();
            }
            else
            {
                MessageBox.Show("Popraw wszystkie bledy");
            }
        }
        #endregion
    }
}
