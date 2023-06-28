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
    public class NowyPracownikViewModel : JedenViewModel<Pracownik>, IDataErrorInfo
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
        public NowyPracownikViewModel()
            : base("Dodawanie nowego pracownika")
        {
            Item = new Pracownik();
            Messenger.Default.Register<AdresForAllView>(this, getWybranyAdres);
            Messenger.Default.Register<Kontakt>(this, getWybranyKontakt);
        }
        #endregion
        #region Properties
        public string Imie
        {
            get
            {
                return Item.Imie;
            }
            set
            {
                if (value != Item.Imie)
                {
                    Item.Imie = value;
                    base.OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return Item.Nazwisko;
            }
            set
            {
                if (value != Item.Nazwisko)
                {
                    Item.Nazwisko = value;
                    base.OnPropertyChanged(() => Nazwisko);
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
        public DateTime DataUrodzenia
        {
            get
            {
                return Item.DataUrodzenia;
            }
            set
            {
                if (value != Item.DataUrodzenia)
                {
                    Item.DataUrodzenia = value;
                    base.OnPropertyChanged(() => DataUrodzenia);
                }
            }
        }
        public string ImieOjca
        {
            get
            {
                return Item.ImieOjca;
            }
            set
            {
                if (value != Item.ImieOjca)
                {
                    Item.ImieOjca = value;
                    base.OnPropertyChanged(() => ImieOjca);
                }
            }
        }
        public string ImieMatki
        {
            get
            {
                return Item.ImieMatki;
            }
            set
            {
                if (value != Item.ImieMatki)
                {
                    Item.ImieMatki = value;
                    base.OnPropertyChanged(() => ImieMatki);
                }
            }
        }
        public string NazwiskoRodowe
        {
            get
            {
                return Item.NazwiskoRodowe;
            }
            set
            {
                if (value != Item.NazwiskoRodowe)
                {
                    Item.NazwiskoRodowe = value;
                    base.OnPropertyChanged(() => NazwiskoRodowe);
                }
            }
        }
        public int? IdAdresu
        {
            get
            {
                return Item.IdAdresu;
            }
            set
            {
                if (value != Item.IdAdresu)
                {
                    Item.IdAdresu = value;
                    base.OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        private string _AdresUlica;
        public string AdresUlica
        {
            get
            {
                return _AdresUlica;
            }
            set
            {
                if (value != _AdresUlica)
                {
                    _AdresUlica = value;
                    base.OnPropertyChanged(() => AdresUlica);
                }
            }
        }
        private string _AdresKodPocztowy;
        public string AdresKodPocztowy
        {
            get
            {
                return _AdresKodPocztowy;
            }
            set
            {
                if (value != _AdresKodPocztowy)
                {
                    _AdresKodPocztowy = value;
                    base.OnPropertyChanged(() => AdresKodPocztowy);
                }
            }
        }
        private string _AdresPoczta;
        public string AdresPoczta
        {
            get
            {
                return _AdresPoczta;
            }
            set
            {
                if (value != _AdresPoczta)
                {
                    _AdresPoczta = value;
                    base.OnPropertyChanged(() => AdresPoczta);
                }
            }
        }

        private string _AdresNrDomu;
        public string AdresNrDomu
        {
            get
            {
                return _AdresNrDomu;
            }
            set
            {
                if (value != _AdresNrDomu)
                {
                    _AdresNrDomu = value;
                    base.OnPropertyChanged(() => AdresNrDomu);
                }
            }
        }
        private string _AdresNrLokalu;
        public string AdresNrlokalu
        {
            get
            {
                return _AdresNrLokalu;
            }
            set
            {
                if (value != _AdresNrLokalu)
                {
                    _AdresNrLokalu = value;
                    base.OnPropertyChanged(() => AdresNrlokalu);
                }
            }
        }
        private string _AdresMiejscowosc;
        public string AdresMiejscowosc
        {
            get
            {
                return _AdresMiejscowosc;
            }
            set
            {
                if (value != _AdresMiejscowosc)
                {
                    _AdresMiejscowosc = value;
                    base.OnPropertyChanged(() => AdresMiejscowosc);
                }
            }
        }
        private string _AdresPowiat;
        public string AdresPowiat
        {
            get
            {
                return _AdresPowiat;
            }
            set
            {
                if (value != _AdresPowiat)
                {
                    _AdresPowiat = value;
                    base.OnPropertyChanged(() => AdresPowiat);
                }
            }
        }
        private string _AdresKraj;
        public string AdresKraj
        {
            get
            {
                return _AdresKraj;
            }
            set
            {
                if (value != _AdresKraj)
                {
                    _AdresKraj = value;
                    base.OnPropertyChanged(() => AdresKraj);
                }
            }
        }
        public IQueryable<KeyAndValue> AdresComboBoxItems
        {
            get
            {
                return
                (
                    from Adres in Db.Adres
                    select new KeyAndValue
                    {
                        Key = Adres.IdAdresu,
                        Value = Adres.Miejscowosc + " " + Adres.NumerDomu
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
        public IQueryable<KeyAndValue> KontaktComboBoxItems
        {
            get
            {
                return
                (
                    from Kontakt in Db.Kontakt
                    select new KeyAndValue
                    {
                        Key = Kontakt.IdKontaktu,
                        Value = Kontakt.Telefon1
                    }
                ).ToList().AsQueryable();
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
                if (name == "Imie")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Imie);
                }
                if (name == "Nazwisko")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Nazwisko);
                }
                if (name == "ImieMatki")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(ImieMatki);
                }
                if (name == "ImieOjca")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(ImieOjca);
                }
                if (name == "NazwiskoRodowe")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(NazwiskoRodowe);
                }
                if (name == "PESEL")
                {
                    komunikat = BusinessValidator.SprawdzPESEL(PESEL);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Imie"] == null && this["Nazwisko"] == null && this["ImieMatki"] == null && this["ImieOjca"] == null && this["NazwiskoRodowe"] == null && this["PESEL"] == null)
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
            Db.Pracownik.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void getWybranyAdres(AdresForAllView adresForAllView)
        {
            IdAdresu = adresForAllView.IdAdresu;
            AdresUlica = adresForAllView.Ulica;
            AdresKodPocztowy = adresForAllView.KodPocztowy;
            AdresPoczta = adresForAllView.Poczta;
            AdresNrDomu = adresForAllView.NumerDomu;
            AdresNrlokalu = adresForAllView.NumerLokalu;
            AdresMiejscowosc = adresForAllView.Miejscowosc;
            AdresKraj = adresForAllView.KrajNazwa;
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
