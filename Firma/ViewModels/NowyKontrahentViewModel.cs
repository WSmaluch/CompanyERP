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
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahent>, IDataErrorInfo
    {

        #region Commands
        private BaseCommand _ShowAdresyCommand;
        public ICommand ShowAdresyCommand
        {
            get
            {
                if (_ShowAdresyCommand == null)
                {
                    _ShowAdresyCommand = new BaseCommand(() => showAdresy());
                }
                return _ShowAdresyCommand;
            }
        }
        private void showAdresy()
        {
            Messenger.Default.Send("AdresyAll");
        }
        private BaseCommand _ShowKontaktyCommand;
        public ICommand ShowKontaktyCommand
        {
            get
            {
                if (_ShowKontaktyCommand == null)
                {
                    _ShowKontaktyCommand = new BaseCommand(() => showKontakty());
                }
                return _ShowKontaktyCommand;
            }
        }
        private void showKontakty()
        {
            Messenger.Default.Send("KontaktyAll");
        }
        #endregion
        #region Konstruktor
        public NowyKontrahentViewModel()
            : base("Kontrahent")
        {
            Item = new Kontrahent();
            Messenger.Default.Register<AdresForAllView>(this, getWybranyAdres);
            Messenger.Default.Register<Kontakt>(this, getWybranyKontakt);
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                if (value != Item.Nazwa)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string NIP
        {
            get
            {
                return Item.NIP;
            }
            set
            {
                if (value != Item.NIP)
                {
                    Item.NIP = value;
                    base.OnPropertyChanged(() => NIP);
                }
            }
        }
        public bool PodatnikVAT
        {
            get
            {
                return Item.PodatnikVAT;
            }
            set
            {
                if (value != Item.PodatnikVAT)
                {
                    Item.PodatnikVAT = value;
                    base.OnPropertyChanged(() => PodatnikVAT);
                }
            }
        }
        public string PESEL
        {
            get
            {
                return Item.PESEL;
            }
            set
            {
                if (value != Item.PESEL)
                {
                    Item.PESEL = value;
                    base.OnPropertyChanged(() => PESEL);
                }
            }
        }
        public string REGON
        {
            get
            {
                return Item.REGON;
            }
            set
            {
                if (value != Item.REGON)
                {
                    Item.REGON = value;
                    base.OnPropertyChanged(() => REGON);
                }
            }
        }
        public string KRS
        {
            get
            {
                return Item.KRS;
            }
            set
            {
                if (value != Item.KRS)
                {
                    Item.KRS = value;
                    base.OnPropertyChanged(() => KRS);
                }
            }
        }
        public string GLN
        {
            get
            {
                return Item.GLN;
            }
            set
            {
                if (value != Item.GLN)
                {
                    Item.GLN = value;
                    base.OnPropertyChanged(() => GLN);
                }
            }
        }
        public int? IdAdresuZKRS
        {
            get
            {
                return Item.IdAdresuZKRS;
            }
            set
            {
                if (value != Item.IdAdresuZKRS)
                {
                    Item.IdAdresuZKRS = value;
                    base.OnPropertyChanged(() => IdAdresuZKRS);
                }
            }
        }
        private string _AdresKRS;
        public string AdresKRS
        {
            get
            {
                return _AdresKRS;
            }
            set
            {
                if (value != _AdresKRS)
                {
                    _AdresKRS = value;
                    base.OnPropertyChanged(() => AdresKRS);
                }
            }
        }

        public int? IdAdresuSiedziby
        {
            get
            {
                return Item.IdAdresuSiedziby;
            }
            set
            {
                if (value != Item.IdAdresuSiedziby)
                {
                    Item.IdAdresuSiedziby = value;
                    base.OnPropertyChanged(() => IdAdresuSiedziby);
                }
            }
        }
        private string _AdresSiedziby;
        public string AdresSiedziby
        {
            get
            {
                return _AdresSiedziby;
            }
            set
            {
                if (value != _AdresSiedziby)
                {
                    _AdresSiedziby = value;
                    base.OnPropertyChanged(() => AdresSiedziby);
                }
            }
        }
        public int? IdAdresuKontaktowego
        {
            get
            {
                return Item.IdAdresuKontaktowego;
            }
            set
            {
                if (value != Item.IdAdresuKontaktowego)
                {
                    Item.IdAdresuKontaktowego = value;
                    base.OnPropertyChanged(() => IdAdresuKontaktowego);
                }
            }
        }
        private string _AdresKontaktowy;
        public string AdresKontaktowy
        {
            get
            {
                return _AdresKontaktowy;
            }
            set
            {
                if (value != _AdresKontaktowy)
                {
                    _AdresKontaktowy = value;
                    base.OnPropertyChanged(() => AdresKontaktowy);
                }
            }
        }
        public IQueryable<KeyAndValue> AdresyComboBoxItems
        {
            get
            {
                return
                (
                    from Adres in Db.Adres
                    select new KeyAndValue
                    {
                        Key = Adres.IdAdresu,
                        Value = Adres.Miejscowosc + " "+ Adres.NumerDomu
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? IdTypuKontrahenta
        {
            get
            {
                return Item.IdTypuKontrahenta;
            }
            set
            {
                if (value != Item.IdTypuKontrahenta)
                {
                    Item.IdTypuKontrahenta = value;
                    base.OnPropertyChanged(() => IdTypuKontrahenta);
                }
            }
        }
        public IQueryable<KeyAndValue> TypyKontrahentaComboBoxItems
        {
            get
            {
                return
                (
                    from TypKontrahenta in Db.TypKontrahenta
                    where TypKontrahenta.CzyAktywny == true
                    select new KeyAndValue
                    {
                        Key = TypKontrahenta.IdTypuKontrahenta,
                        Value = TypKontrahenta.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? IdRodzajuKontrahenta
        {
            get
            {
                return Item.IdRodzajuKontrahenta;
            }
            set
            {
                if (value != Item.IdRodzajuKontrahenta)
                {
                    Item.IdRodzajuKontrahenta = value;
                    base.OnPropertyChanged(() => IdRodzajuKontrahenta);
                }
            }
        }
        public IQueryable<KeyAndValue> RodzajeKontrahentaComboBoxItems
        {
            get
            {
                return
                (
                    from RodzajKontrahenta in Db.RodzajKontrahenta
                    where RodzajKontrahenta.CzyAktywny == true
                    select new KeyAndValue
                    {
                        Key = RodzajKontrahenta.IdRodzajKontrahenta,
                        Value = RodzajKontrahenta.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? IdKategoriiKontrahenta
        {
            get
            {
                return Item.IdKategoriiKontrahenta;
            }
            set
            {
                if (value != Item.IdKategoriiKontrahenta)
                {
                    Item.IdKategoriiKontrahenta = value;
                    base.OnPropertyChanged(() => IdKategoriiKontrahenta);
                }
            }
        }
        public IQueryable<KeyAndValue> KategorieKontrahentaComboBoxItems
        {
            get
            {
                return
                (
                    from KategoriaKontrahenta in Db.KategoriaKontrahenta
                    where KategoriaKontrahenta.CzyAktywny == true
                    select new KeyAndValue
                    {
                        Key = KategoriaKontrahenta.IdKategoriiKontrahenta,
                        Value = KategoriaKontrahenta.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public int? IdKontaktu
        {
            get
            {
                return Item.IdKontaktu;
            }
            set
            {
                if (value != Item.IdKontaktu)
                {
                    Item.IdKontaktu = value;
                    base.OnPropertyChanged(() => IdKontaktu);
                }
            }
        }
        private string _KontaktNazwaDzialu;
        public string KontaktNazwaDzialu
        {
            get
            {
                return _KontaktNazwaDzialu;
            }
            set
            {
                if (value != _KontaktNazwaDzialu)
                {
                    _KontaktNazwaDzialu = value;
                    base.OnPropertyChanged(() => KontaktNazwaDzialu);
                }
            }
        }
        private string _KontaktEmail1;
        public string KontaktEmail1
        {
            get
            {
                return _KontaktEmail1;
            }
            set
            {
                if (value != _KontaktEmail1)
                {
                    _KontaktEmail1 = value;
                    base.OnPropertyChanged(() => KontaktEmail1);
                }
            }
        }
        private string _KontaktEmail2;
        public string KontaktEmail2
        {
            get
            {
                return _KontaktEmail2;
            }
            set
            {
                if (value != _KontaktEmail2)
                {
                    _KontaktEmail2 = value;
                    base.OnPropertyChanged(() => KontaktEmail2);
                }
            }
        }
        private string _KontaktUwagi;
        public string KontaktUwagi
        {
            get
            {
                return _KontaktUwagi;
            }
            set
            {
                if (value != _KontaktUwagi)
                {
                    _KontaktUwagi = value;
                    base.OnPropertyChanged(() => KontaktUwagi);
                }
            }
        }
        private string _KontaktNrtel1;
        public string KontaktNrtel1
        {
            get
            {
                return _KontaktNrtel1;
            }
            set
            {
                if (value != _KontaktNrtel1)
                {
                    _KontaktNrtel1 = value;
                    base.OnPropertyChanged(() => KontaktNrtel1);
                }
            }
        }
        private string _KontaktNrtel2;
        public string KontaktNrtel2
        {
            get
            {
                return _KontaktNrtel2;
            }
            set
            {
                if (value != _KontaktNrtel2)
                {
                    _KontaktNrtel2 = value;
                    base.OnPropertyChanged(() => KontaktNrtel2);
                }
            }
        }
        private string _KontaktFax;
        public string KontaktFax
        {
            get
            {
                return _KontaktFax;
            }
            set
            {
                if (value != _KontaktFax)
                {
                    _KontaktFax = value;
                    base.OnPropertyChanged(() => KontaktFax);
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
                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Nazwa);
                }
                if (name == "PESEL")
                {
                    komunikat = BusinessValidator.SprawdzPESEL(PESEL);
                }
                if (name == "REGON")
                {
                    komunikat = BusinessValidator.SprawdzREGON(REGON);
                }
                if (name == "NIP")
                {
                    komunikat = BusinessValidator.SprawdzNIP(NIP);
                }
                if (name == "KRS")
                {
                    komunikat = BusinessValidator.SprawdzKRS(KRS);
                }
                if (name == "GLN")
                {
                    komunikat = BusinessValidator.SprawdzGLN(GLN);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["PESEL"] == null && this["REGON"] == null && this["NIP"] == null/* && this["KRS"] == null && this["GLN"] == null*/)
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
            Db.Kontrahent.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void getWybranyAdres(AdresForAllView adresForAllView)
        {
            IdAdresuZKRS = adresForAllView.IdAdresu;
            IdAdresuKontaktowego = adresForAllView.IdAdresu;
            IdAdresuSiedziby = adresForAllView.IdAdresu;
            AdresKRS = adresForAllView.Miejscowosc + ' ' + adresForAllView.Ulica + ' ' + adresForAllView.NumerDomu;
            AdresKontaktowy = adresForAllView.Miejscowosc + ' ' + adresForAllView.Ulica + ' ' + adresForAllView.NumerDomu;
            AdresSiedziby = adresForAllView.Miejscowosc + ' ' + adresForAllView.Ulica + ' ' + adresForAllView.NumerDomu;
        }
        private void getWybranyKontakt(Kontakt kontakt)
        {
            IdKontaktu = kontakt.IdKontaktu;
            KontaktNazwaDzialu = kontakt.NazwaDzialu;
            KontaktEmail1 = kontakt.Email1;
            KontaktEmail2 = kontakt.Email2;
            KontaktUwagi = kontakt.Uwagi;
            KontaktNrtel1 = kontakt.Telefon1;
            KontaktNrtel2 = kontakt.Telefon2;
            KontaktFax = kontakt.Fax;

        }
        #endregion
    }
}
