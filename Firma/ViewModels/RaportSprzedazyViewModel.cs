using Firma.Helpers;
using Firma.Models;
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
    public class RaportSprzedazyViewModel : WorkspaceViewModel
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
        private int _IdTowaru;
        public int IdTowaru
        {
            get
            {
                return _IdTowaru;
            }
            set
            {
                if (_IdTowaru != value)
                {
                    _IdTowaru = value;
                    OnPropertyChanged(() => IdTowaru);
                }
            }
        }
        //dla kazdego comboBoxa w systemie nalezy otworzyc nastepujacy properties
        public IQueryable<KeyAndValue> TowaryComboBoxItems
        {
            get
            {
                // w tym miejscu wywolujemy funkcje logiki biznesowej, ktora znajduje sie w klasie TowarB
                return new TowarB(Projekt2Entities).GetAktywneTowary();
            }
        }
        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (_Utarg != value)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }
        #endregion
        #region Komendy
        //tworzymy komende ktora podlaczymy pod przycisk oblicz, ktora wywola funkcje ObliczUtargClick
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(obliczCommandClick);
                }
                return _ObliczCommand;
            }
        }
        #endregion
        #region Helpers
        private void obliczCommandClick()
        {
            Utarg = new UtargB(Projekt2Entities).UtargOkresTowar(IdTowaru, DataOd, DataDo); //wywolujemy funkcje z logiki biznesoweoj z klasy UtargB
        }
        #endregion
        #region Konstruktor
        public RaportSprzedazyViewModel()
        {
            base.DisplayName = "Raport Sprzedazy";
            Projekt2Entities = new Projekt2Entities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
        }
        #endregion

    }
}
