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
    public class NowaPozycjaFakutyViewModel : JedenViewModel<PozycjaFaktury>, IDataErrorInfo
    {
        #region Commands
        private BaseCommand _ShowDokumentyCommand;
        public ICommand ShowDokumentyCommand
        {
            get
            {
                if (_ShowDokumentyCommand == null)
                {
                    _ShowDokumentyCommand = new BaseCommand(() => showDokumenty());
                }
                return _ShowDokumentyCommand;
            }
        }
        private void showDokumenty()
        {
            Messenger.Default.Send("DokumentyAll");
        }
        private BaseCommand _ShowTowarCommand;
        public ICommand ShowTowarCommand
        {
            get
            {
                if (_ShowTowarCommand == null)
                {
                    _ShowTowarCommand = new BaseCommand(() => showTowar());
                }
                return _ShowTowarCommand;
            }
        }
        private void showTowar()
        {
            Messenger.Default.Send("TowarAll");
        }
        #endregion
        #region Konstruktor
        public NowaPozycjaFakutyViewModel()
        : base("Nowa pozycja faktury")
        {
            Item = new PozycjaFaktury();
            Messenger.Default.Register<DokumentForAllView>(this, getWybranyDokument);
            Messenger.Default.Register<TowarForAllView>(this, getWybranyTowar);
        }
        #endregion
        #region Properties
        public int IdDokumentu
        {
            get
            {
                return Item.IdDokumentu;
            }
            set
            {
                if (value != Item.IdDokumentu)
                {
                    Item.IdDokumentu = value;
                    base.OnPropertyChanged(() => IdDokumentu);
                }
            }
        }
        private string _DokumentNumer;
        public string DokumentNumer
        {
            get
            {
                return _DokumentNumer;
            }
            set
            {
                if (value != _DokumentNumer)
                {
                    _DokumentNumer = value;
                    base.OnPropertyChanged(() => DokumentNumer);
                }
            }
        }
        private string _DokumentTyp;
        public string DokumentTyp
        {
            get
            {
                return _DokumentTyp;
            }
            set
            {
                if (value != _DokumentTyp)
                {
                    _DokumentTyp = value;
                    base.OnPropertyChanged(() => DokumentTyp);
                }
            }
        }
        private string _DokumentKontrahentNazwa;
        public string DokumentKontrahentNazwa
        {
            get
            {
                return _DokumentKontrahentNazwa;
            }
            set
            {
                if (value != _DokumentKontrahentNazwa)
                {
                    _DokumentKontrahentNazwa = value;
                    base.OnPropertyChanged(() => DokumentKontrahentNazwa);
                }
            }
        }
        public IQueryable<KeyAndValue> DokumentyComboBoxItems
        {
            get
            {
                return
                (
                    from Dokument in Db.Dokument
                    select new KeyAndValue
                    {
                        Key = Dokument.IdDokumentu,
                        Value = Dokument.Kontrahent.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public int IdTowaru
        {
            get
            {
                return Item.IdTowaru;
            }
            set
            {
                if (value != Item.IdTowaru)
                {
                    Item.IdTowaru = value;
                    base.OnPropertyChanged(() => IdTowaru);
                }
            }
        }
        private string _TowarNazwa;
        public string TowarNazwa
        {
            get
            {
                return _TowarNazwa;
            }
            set
            {
                if (value != _TowarNazwa)
                {
                    _TowarNazwa = value;
                    base.OnPropertyChanged(() => TowarNazwa);
                }
            }
        }
        private string _TowarKodKreskowy;
        public string TowarKodKreskowy
        {
            get
            {
                return _TowarKodKreskowy;
            }
            set
            {
                if (value != _TowarKodKreskowy)
                {
                    _TowarKodKreskowy = value;
                    base.OnPropertyChanged(() => TowarKodKreskowy);
                }
            }
        }
        private string _TowarJednostkaMiary;
        public string TowarJednostkaMiary
        {
            get
            {
                return _TowarJednostkaMiary;
            }
            set
            {
                if (value != _TowarJednostkaMiary)
                {
                    _TowarJednostkaMiary = value;
                    base.OnPropertyChanged(() => TowarJednostkaMiary);
                }
            }
        }
        private string _TowarStawkaVATSprzedazy;
        public string TowarStawkaVATSprzedazy
        {
            get
            {
                return _TowarStawkaVATSprzedazy;
            }
            set
            {
                if (value != _TowarStawkaVATSprzedazy)
                {
                    _TowarStawkaVATSprzedazy = value;
                    base.OnPropertyChanged(() => TowarStawkaVATSprzedazy);
                }
            }
        }
        private string _TowarStawkaVATZakupu;
        public string TowarStawkaVATZakupu
        {
            get
            {
                return _TowarStawkaVATZakupu;
            }
            set
            {
                if (value != _TowarStawkaVATZakupu)
                {
                    _TowarStawkaVATZakupu = value;
                    base.OnPropertyChanged(() => TowarStawkaVATZakupu);
                }
            }
        }
        private string _TowarStawkaVATKaucji;
        public string TowarStawkaVATKaucji
        {
            get
            {
                return _TowarStawkaVATKaucji;
            }
            set
            {
                if (value != _TowarStawkaVATKaucji)
                {
                    _TowarStawkaVATKaucji = value;
                    base.OnPropertyChanged(() => TowarStawkaVATKaucji);
                }
            }
        }
        public IQueryable<KeyAndValue> TowaryComboBoxItems
        {
            get
            {
                return
                (
                    from Towar in Db.Towar
                    select new KeyAndValue
                    {
                        Key = Towar.IdTowaru,
                        Value = Towar.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }
        public decimal Cena
        {
            get
            {
                return Item.Cena;
            }
            set
            {
                if (value != Item.Cena)
                {
                    Item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public int Ilosc
        {
            get
            {
                return Item.Ilosc;
            }
            set
            {
                if (value != Item.Ilosc)
                {
                    Item.Ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
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
                if (name == "Cena")
                {
                    komunikat = DecimalValidator.SprawdzCzyLiczba(Cena);
                }
                if (name == "Rabat")
                {
                    komunikat = DecimalValidator.SprawdzRabat(Rabat);
                }
                if (name == "Ilosc")
                {
                    komunikat = DecimalValidator.SprawdzCzyLiczba(Ilosc);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Cena"] == null && this["Rabat"] == null && this["Ilosc"] == null)
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
            Item.Rabat = (Rabat / 100);
            Item.KtoDodal = Environment.MachineName;
            Item.KiedyDodal = DateTime.Now;
            Db.PozycjaFaktury.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
        private void getWybranyDokument(DokumentForAllView dokumentForAllView)
        {
            IdDokumentu = dokumentForAllView.IdDokuemntu;
            DokumentNumer = dokumentForAllView.IdDokuemntu.ToString();
            DokumentKontrahentNazwa = dokumentForAllView.KontrahentNazwa;
            DokumentTyp = dokumentForAllView.KategoriaDokumentNazwa;
        }
        private void getWybranyTowar(TowarForAllView towarForAllView)
        {
            IdTowaru = towarForAllView.IdTowaru;
            TowarNazwa = towarForAllView.Nazwa;
            TowarKodKreskowy = towarForAllView.KodKreskowy;
            TowarJednostkaMiary = towarForAllView.JednostkiMiaryNazwa;
            TowarStawkaVATSprzedazy = towarForAllView.StawkaVATSprzedazyStawka;
            TowarStawkaVATZakupu = towarForAllView.StawkaVATZakupuStawka;
            TowarStawkaVATKaucji = towarForAllView.StawkaVATKaucjiStawka;
        }
        #endregion
    }
}
