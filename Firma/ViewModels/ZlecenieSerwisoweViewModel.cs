using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class ZlecenieSerwisoweViewModel : JedenViewModel<ZlecenieSerwisowe>
    {
        #region Commands
        private BaseCommand _ShowKontrahenciCommand;
        public ICommand ShowKontrahenciCommand
        {
            get
            {
                if (_ShowKontrahenciCommand == null)
                {
                    _ShowKontrahenciCommand = new BaseCommand(() => showKontrahenci());
                }
                return _ShowKontrahenciCommand;
            }
        }
        private void showKontrahenci()
        {
            Messenger.Default.Send("KontrahenciAll");
        }
        private BaseCommand _ShowSerwisanciCommand;
        public ICommand ShowSerwisanciCommand
        {
            get
            {
                if (_ShowSerwisanciCommand == null)
                {
                    _ShowSerwisanciCommand = new BaseCommand(() => showSerwisanci());
                }
                return _ShowSerwisanciCommand;
            }
        }
        private void showSerwisanci()
        {
            Messenger.Default.Send("SerwisantAll");
        }
        #endregion
        #region Konstruktor
        public ZlecenieSerwisoweViewModel()
            : base("Dodawanie zlecenia serwisowego")
        {
            Item = new ZlecenieSerwisowe();
            DataPrzyjecia = DateTime.Today;
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
            Messenger.Default.Register<SerwisanciForAllView>(this, getWybranySerwisant);
        }
        #endregion
        #region Properties
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
        private string _KontrahentAdres;
        public string KontrahentAdres
        {
            get
            {
                return _KontrahentAdres;
            }
            set
            {
                if (value != _KontrahentAdres)
                {
                    _KontrahentAdres = value;
                    base.OnPropertyChanged(() => KontrahentAdres);
                }
            }
        }
        public IQueryable<KeyAndValue> KontahenciComboBoxItems
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
        public int IdKategoriiSerwisu
        {
            get
            {
                return Item.IdKategoriiSerwisu;
            }
            set
            {
                if (value != Item.IdKategoriiSerwisu)
                {
                    Item.IdKategoriiSerwisu = value;
                    base.OnPropertyChanged(() => IdKategoriiSerwisu);
                }
            }
        }
        public IQueryable<KeyAndValue> KategorieSerwisuComboBoxItems
        {
            get
            {
                return
                (
                    from KategoriaSerwisu in Db.KategorieSerwisu
                    select new KeyAndValue
                    {
                        Key = KategoriaSerwisu.IdKategoriiSerwisu,
                        Value = KategoriaSerwisu.NazwaUslugi
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
        public int IdUrzadzenia
        {
            get
            {
                return Item.IdUrzadzenia;
            }
            set
            {
                if (value != Item.IdUrzadzenia)
                {
                    Item.IdUrzadzenia = value;
                    base.OnPropertyChanged(() => IdUrzadzenia);
                }
            }
        }
        public IQueryable<KeyAndValue> UrzadzeniaComboBoxItems
        {
            get
            {
                return
                (
                    from Urzadzenie in Db.Urzadzenie
                    select new KeyAndValue
                    {
                        Key = Urzadzenie.IdUrzadzenia,
                        Value = Urzadzenie.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public int IdSerwisanta
        {
            get
            {
                return Item.IdSerwisanta;
            }
            set
            {
                if (value != Item.IdSerwisanta)
                {
                    Item.IdSerwisanta = value;
                    base.OnPropertyChanged(() => IdSerwisanta);
                }
            }
        }
        private string _SerwisantImieNazwisko;
        public string SerwisantImieNazwisko
        {
            get
            {
                return _SerwisantImieNazwisko;
            }
            set
            {
                if (value != _SerwisantImieNazwisko)
                {
                    _SerwisantImieNazwisko = value;
                    base.OnPropertyChanged(() => SerwisantImieNazwisko);
                }
            }
        }
        private string _SerwisantNazwaFirmy;
        public string SerwisantNazwaFirmy
        {
            get
            {
                return _SerwisantNazwaFirmy;
            }
            set
            {
                if (value != _SerwisantNazwaFirmy)
                {
                    _SerwisantNazwaFirmy = value;
                    base.OnPropertyChanged(() => SerwisantNazwaFirmy);
                }
            }
        }
        public IQueryable<KeyAndValue> SerwisanciComboBoxItems
        {
            get
            {
                return
                (
                    from Serwisanci in Db.Serwisanci
                    select new KeyAndValue
                    {
                        Key = Serwisanci.IdSerwisanta,
                        Value = Serwisanci.Imie + " " + Serwisanci.Nazwisko + " " + Serwisanci.NazwaFirmy
                    }
                ).ToList().AsQueryable();
            }
        }
        public string Priorytet
        {
            get
            {
                return Item.Priorytet;
            }
            set
            {
                if (value != Item.Priorytet)
                {
                    Item.Priorytet = value;
                    base.OnPropertyChanged(() => Priorytet);
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
        public DateTime? DataRealizacji
        {
            get
            {
                return Item.DataRealizacji;
            }
            set
            {
                if (value != Item.DataRealizacji)
                {
                    Item.DataRealizacji = value;
                    base.OnPropertyChanged(() => DataRealizacji);
                }
            }
        }
        public TimeSpan PlanowanyCzas
        {
            get
            {
                return Item.PlanowanyCzas;
            }
            set
            {
                if (value != Item.PlanowanyCzas)
                {
                    Item.PlanowanyCzas = value;
                    base.OnPropertyChanged(() => PlanowanyCzas);
                }
            }
        }
        public TimeSpan? RzeczywistyCzas
        {
            get
            {
                return Item.RzeczywistyCzas;
            }
            set
            {
                if (value != Item.RzeczywistyCzas)
                {
                    Item.RzeczywistyCzas = value;
                    base.OnPropertyChanged(() => RzeczywistyCzas);
                }
            }
        }
        public string Opis
        {
            get
            {
                return Item.Opis;
            }
            set
            {
                if (value != Item.Opis)
                {
                    Item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        public string Status
        {
            get
            {
                return Item.Status;
            }
            set
            {
                if (value != Item.Status)
                {
                    Item.Status = value;
                    base.OnPropertyChanged(() => Status);
                }
            }
        }
        #endregion
        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Db.ZlecenieSerwisowe.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void getWybranyKontrahent(KontrahentForAllView kontrahentForAllView)
        {
            IdKontrahenta = kontrahentForAllView.IdKontrahenta;
            KontrahentNazwa = kontrahentForAllView.Nazwa;
            KontrahentNIP = kontrahentForAllView.NIP;
            KontrahentAdres = kontrahentForAllView.AdresZKRSMiejscowosc;
        }
        #endregion
        #region Helpers
        private void getWybranySerwisant(SerwisanciForAllView serwisanciForAllView)
        {
            IdSerwisanta = serwisanciForAllView.IdSerwisanta;
            SerwisantImieNazwisko = serwisanciForAllView.Imie + ' ' + serwisanciForAllView.Nazwisko;
            SerwisantNazwaFirmy = serwisanciForAllView.NazwaFirmy;
        }
        #endregion
    }
}
