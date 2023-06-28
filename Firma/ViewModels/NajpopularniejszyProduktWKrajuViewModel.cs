using Firma.Helpers;
using Firma.Models.BusinessLogic;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NajpopularniejszyProduktWKrajuViewModel : WorkspaceViewModel
    {
        #region Wlasciwosci
        public Projekt2Entities Projekt2Entities { get; set; }
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

        private int _IdKraju;
        public int IdKraju
        {
            get
            {
                return _IdKraju;
            }
            set
            {
                if (_IdKraju != value)
                {
                    _IdKraju = value;
                    OnPropertyChanged(() => _IdKraju);
                }
            }
        }
        public IQueryable<KeyAndValue> KrajeComboBoxItems
        {
            get
            {
                return new KrajB(Projekt2Entities).GetKraje();
            }
        }
        private string _NajpopularniejszyTowarWKraju;
        public string NajpopularniejszyTowarWKraju
        {
            get
            {
                return _NajpopularniejszyTowarWKraju;
            }
            set
            {
                if (_NajpopularniejszyTowarWKraju != value)
                {
                    _NajpopularniejszyTowarWKraju = value;
                    OnPropertyChanged(() => NajpopularniejszyTowarWKraju);
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
            NajpopularniejszyTowarWKraju = new NajpopularniejszyProduktWKrajuB(Projekt2Entities).NajpopularniejszyTowarKraj(IdKraju,DataOd,DataDo);
        }
        #endregion
        #region Konstruktor
        public NajpopularniejszyProduktWKrajuViewModel()
        {
            base.DisplayName = "Najpopularniejszy produkt w danym kraju";
            Projekt2Entities = new Projekt2Entities();
            DataOd = DateTime.Today;
            DataDo = DateTime.Today;
        }
        #endregion
    }
}
