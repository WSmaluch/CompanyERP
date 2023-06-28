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
    public class NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel : JedenViewModel<PozycjaPrzyjeciaZewnętrznegoTowaru>, IDataErrorInfo
    {

        #region Commands
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
        public NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel()
        : base("Nowa pozycja przyjecia zewnetrznego towaru")
        {
            Item = new PozycjaPrzyjeciaZewnętrznegoTowaru();
            Messenger.Default.Register<TowarForAllView>(this, getWybranyTowar);
        }
        #endregion
        #region Properties
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
        public string Ilosc
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
        public string CenaZakupuPierwotna
        {
            get
            {
                return Item.CenaZakupuPierwotna;
            }
            set
            {
                if (value != Item.CenaZakupuPierwotna)
                {
                    Item.CenaZakupuPierwotna = value;
                    base.OnPropertyChanged(() => CenaZakupuPierwotna);
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
                if (name == "Rabat")
                {
                    komunikat = DecimalValidator.SprawdzRabat(Rabat);
                }
                if (name == "CenaZakupuPierwotna")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(CenaZakupuPierwotna);
                }
                if (name == "Ilosc")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(Ilosc);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Rabat"] == null && this["CenaZakupuPierwotna"] == null && this["Ilosc"] == null)
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
            Item.Rabat = Rabat / 100;
            Item.KtoDodal = Environment.MachineName;
            Item.KiedyDodal = DateTime.Now;
            Item.IdJednostkiMiary = 3;
            Db.PozycjaPrzyjeciaZewnętrznegoTowaru.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
        #region Helpers
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
