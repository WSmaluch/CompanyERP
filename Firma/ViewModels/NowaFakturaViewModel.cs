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
    public class NowaFakturaViewModel: JedenViewModel<Dokument>, IDataErrorInfo
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
        #endregion
        #region Konstruktor
        public NowaFakturaViewModel()
            : base("Dodawanie nowego dokumentu")
        {
            Item = new Dokument();
            DataWystawienia = DateTime.Today;
            DataSprzedazy = DateTime.Today;
            Messenger.Default.Register<KontrahentForAllView>(this, getWybranyKontrahent);
        }
        #endregion
        #region Properties
        public int IdTypuDokumentu
        {
            get
            {
                return Item.IdTypuDokumentu;
            }
            set
            {
                if (value != Item.IdTypuDokumentu)
                {
                    Item.IdTypuDokumentu = value;
                    base.OnPropertyChanged(() => IdTypuDokumentu);
                }
            }
        }
        public IQueryable<KeyAndValue> TypyDokumentuComboBoxItems
        {
            get
            {
                return
                (
                    from TypDokumentu in Db.TypDokumentu
                    select new KeyAndValue
                    {
                        Key = TypDokumentu.IdTypuDokumentu,
                        Value = TypDokumentu.Nazwa
                    }
                ).ToList().AsQueryable();
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
                        Value = Kontrahent.Nazwa + " " + Kontrahent.KRS
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? IdKategoriiDokumentu
        {
            get
            {
                return Item.IdKategoriiDokumentu;
            }
            set
            {
                if (value != Item.IdKategoriiDokumentu)
                {
                    Item.IdKategoriiDokumentu = value;
                    base.OnPropertyChanged(() => IdKategoriiDokumentu);
                }
            }
        }
        public IQueryable<KeyAndValue> KategorieDokumentuComboBoxItems
        {
            get
            {
                return
                (
                    from KategoriaDokumentu in Db.KategoriaDokumentu
                    select new KeyAndValue
                    {
                        Key = KategoriaDokumentu.IdKategoriiDokumentu,
                        Value = KategoriaDokumentu.Nazwa
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
        public DateTime DataSprzedazy
        {
            get
            {
                return Item.DataSprzedazy;
            }
            set
            {
                if (value != Item.DataSprzedazy)
                {
                    Item.DataSprzedazy = value;
                    base.OnPropertyChanged(() => DataSprzedazy);
                }
            }
        }
        public string FakturaLiczonaOd
        {
            get
            {
                return Item.FakturaLiczonaOd;
            }
            set
            {
                if (value != Item.FakturaLiczonaOd)
                {
                    Item.FakturaLiczonaOd = value;
                    base.OnPropertyChanged(() => FakturaLiczonaOd);
                }
            }
        }
        public decimal Rabat
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
        public int IdSposobuPlatnosci
        {
            get
            {
                return Item.IdSposobuPlatnosci;
            }
            set
            {
                if (value != Item.IdSposobuPlatnosci)
                {
                    Item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public IQueryable<KeyAndValue> SposobyPlatnosciComboBoxItems
        {
            get
            {
                return
                (
                    from SposobPlatnosci in Db.SposobPlatnosci
                    where SposobPlatnosci.CzyAktywny==true
                    select new KeyAndValue
                    {
                        Key = SposobPlatnosci.IdSposobuPlatnosci,
                        Value = SposobPlatnosci.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public DateTime Termin
        {
            get
            {
                return Item.Termin;
            }
            set
            {
                if (value != Item.Termin)
                {
                    Item.Termin = value;
                    base.OnPropertyChanged(() => Termin);
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

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Rabat"] == null)
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
            Item.KtoDodal = Environment.MachineName;
            Item.KiedyDodal = DateTime.Now;
            Item.Rabat = Rabat/100;
            Db.Dokument.AddObject(Item);
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
    }
}
