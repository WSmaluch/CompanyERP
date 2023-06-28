using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.Models.Validators;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NowePrzyjecieZewnetrzneViewModel : JedenViewModel<PrzyjecieZewnetrzne>, IDataErrorInfo
    {
        #region Commands
        private BaseCommand _ShowKontrahentCommand;
        public ICommand ShowKontrahentCommand
        {
            get
            {
                if (_ShowKontrahentCommand == null)
                {
                    _ShowKontrahentCommand = new BaseCommand(() => showKontrahent());
                }
                return _ShowKontrahentCommand;
            }
        }
        private void showKontrahent()
        {
            Messenger.Default.Send("KontrahenciAll");
        }
        #endregion
        #region Konstruktor
        public NowePrzyjecieZewnetrzneViewModel()
            : base("Dodawanie przyjecia zewnetrznego")
        {
            Item = new PrzyjecieZewnetrzne();
            DataWystawienia = new DateTime(DateTime.Now.Year, 1, 1);
            DataPrzyjecia = new DateTime(DateTime.Now.Year, 1, 1);
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
        }
        #endregion
        #region Properties
        public string NumerPrzyjecia
        {
            get
            {
                return Item.NumerPrzyjecia;
            }
            set
            {
                if (value != Item.NumerPrzyjecia)
                {
                    Item.NumerPrzyjecia = value;
                    base.OnPropertyChanged(() => NumerPrzyjecia);
                }
            }
        }
        public int IdKontrahenta
        {
            get
            {
                return Item.IdKontrahenta;
            }
            set
            {
                if (value != Item.IdKontrahenta)
                {
                    Item.IdKontrahenta = value;
                    base.OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }
        private string _KontrahentNazwa;
        public string KontrahentNazwa
        {
            get
            {
                return _KontrahentNazwa;
            }
            set
            {
                if (value != _KontrahentNazwa)
                {
                    _KontrahentNazwa = value;
                    base.OnPropertyChanged(() => KontrahentNazwa);
                }
            }
        }
        private string _KontrahentNIP;
        public string KontrahentNIP
        {
            get
            {
                return _KontrahentNIP;
            }
            set
            {
                if (value != _KontrahentNIP)
                {
                    _KontrahentNIP = value;
                    base.OnPropertyChanged(() => KontrahentNIP);
                }
            }
        }
        private string _KontrahentAdresKRS;
        public string KontrahentAdresKRS
        {
            get
            {
                return _KontrahentAdresKRS;
            }
            set
            {
                if (value != _KontrahentAdresKRS)
                {
                    _KontrahentAdresKRS = value;
                    base.OnPropertyChanged(() => KontrahentAdresKRS);
                }
            }
        }
        private string _KontrahentTyp;
        public string KontrahentTyp
        {
            get
            {
                return _KontrahentTyp;
            }
            set
            {
                if (value != _KontrahentTyp)
                {
                    _KontrahentTyp = value;
                    base.OnPropertyChanged(() => KontrahentTyp);
                }
            }
        }
        public IQueryable<KeyAndValue> KontrahenciComboBoxItems
        {
            get
            {
                return
                (
                    from Kontrahent in Db.Kontrahent
                    select new KeyAndValue
                    {
                        Key = Kontrahent.IdKontrahenta,
                        Value = Kontrahent.Nazwa + " " + Kontrahent.NIP
                    }
                ).ToList().AsQueryable();
            }
        }
        public int IdMagazynu
        {
            get
            {
                return Item.IdMagazynu;
            }
            set
            {
                if (value != Item.IdMagazynu)
                {
                    Item.IdMagazynu = value;
                    base.OnPropertyChanged(() => IdMagazynu);
                }
            }
        }
        public IQueryable<KeyAndValue> MagazynyComboBoxItems
        {
            get
            {
                return
                (
                    from Magazyn in Db.Magazyn
                    select new KeyAndValue
                    {
                        Key = Magazyn.IdMagazynu,
                        Value = Magazyn.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public DateTime DataWystawienia
        {
            get
            {
                return Item.DataWystawienia;
            }
            set
            {
                if (value != Item.DataWystawienia)
                {
                    Item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime DataPrzyjecia
        {
            get
            {
                return Item.DataPrzyjecia;
            }
            set
            {
                if (value != Item.DataPrzyjecia)
                {
                    Item.DataPrzyjecia = value;
                    base.OnPropertyChanged(() => DataPrzyjecia);
                }
            }
        }
        public decimal? Rabat
        {
            get
            {
                return Item.Rabat;
            }
            set
            {
                if (value != Item.Rabat)
                {
                    Item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
                }
            }
        }

        #endregion
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Rabat")
                {
                    komunikat = DecimalValidator.SprawdzRabat(Rabat);
                }
                if (name == "NumerPrzyjecia")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(NumerPrzyjecia);
                }


                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Rabat"] == null && this["NumerPrzyjecia"] == null)
            {
                return true;
            }
            return false;
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Item.DataPrzyjecia = DateTime.Now;
            Item.DataWystawienia = DateTime.Now;
            Db.PrzyjecieZewnetrzne.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void getWybranyKontrahent(KontrahentForAllView kontrahentForAllView)
        {
            IdKontrahenta = kontrahentForAllView.IdKontrahenta;
            KontrahentNazwa = kontrahentForAllView.Nazwa;
            KontrahentNIP = kontrahentForAllView.NIP;
            KontrahentAdresKRS = kontrahentForAllView.AdresZKRSMiejscowosc + ' ' + kontrahentForAllView.AdresZKRSUlica + ' ' + kontrahentForAllView.AdresZKRSNrDomu;
            KontrahentTyp = kontrahentForAllView.TypKontrahentaNazwa;
        }
        #endregion
    }
}
