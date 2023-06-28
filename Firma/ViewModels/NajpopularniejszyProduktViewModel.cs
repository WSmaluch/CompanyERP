using Firma.Helpers;
using Firma.Models.BusinessLogic;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NajpopularniejszyProduktViewModel : WorkspaceViewModel
    {
        #region Wlasciwosci
        public Projekt2Entities Projekt2Entities { get; set; }
        //dla kazdego pola na widoku istotnego w obliczeniach tworzymy pole i wlasciwosc 
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IdKontrahenta;
        public int IdKontrahenta
        {
            get
            {
                return _IdKontrahenta;
            }
            set
            {
                if (_IdKontrahenta != value)
                {
                    _IdKontrahenta = value;
                    OnPropertyChanged(() => _IdKontrahenta);
                }
            }
        }
        public IQueryable<KeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return new KontrahentB(Projekt2Entities).GetKontrahenci();
            }
        }
        private string _NajpopularniejszyTowar;
        public string NajpopularniejszyTowar
        {
            get
            {
                return _NajpopularniejszyTowar;
            }
            set
            {
                if (_NajpopularniejszyTowar != value)
                {
                    _NajpopularniejszyTowar = value;
                    OnPropertyChanged(() => NajpopularniejszyTowar);
                }
            }
        }

        #endregion
        #region Komendy
        private BaseCommand _PokazCommand;
        public ICommand PokazCommand
        {
            get
            {
                if (_PokazCommand == null)
                {
                    _PokazCommand = new BaseCommand(pokazCommandClick);
                }
                return _PokazCommand;
            }
        }
        #endregion
        #region Helpers
        private void pokazCommandClick()
        {
            NajpopularniejszyTowar = new NajpopularniejszyProduktB(Projekt2Entities).NajpopularniejszyTowarOkres(IdKontrahenta, DataOd, DataDo); 
        }
        #endregion
        #region Konstruktor
        public NajpopularniejszyProduktViewModel()
        {
            base.DisplayName = "Najpopularniejszy produkt";
            Projekt2Entities = new Projekt2Entities();
            DataOd = DateTime.Today;
            DataDo = DateTime.Today;
        }
        #endregion
    }
}
