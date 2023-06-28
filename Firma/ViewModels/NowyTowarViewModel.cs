using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.Models.Validators;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowyTowarViewModel:JedenViewModel<Towar>,IDataErrorInfo
    {
        #region Konstruktor
        public NowyTowarViewModel()
            : base("Towar")
        {
            Item = new Towar();   //pusty towar create
        }
        #endregion
        #region Properties
        public string Kod
        {
            get
            {
                return Item.Kod;
            }
            set
            {
                if (value != Item.Kod)
                {
                    Item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
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

        public string KodKreskowy
        {
            get
            {
                return Item.KodKreskowy;
            }
            set
            {
                if (value != Item.KodKreskowy)
                {
                    Item.KodKreskowy = value;
                    base.OnPropertyChanged(() => KodKreskowy);
                }
            }
        }

        public string NrKatalogowy
        {
            get
            {
                return Item.NrKatalogowy;
            }
            set
            {
                if (value != Item.NrKatalogowy)
                {
                    Item.NrKatalogowy = value;
                    base.OnPropertyChanged(() => NrKatalogowy);
                }
            }
        }

        public int IdJednostkiMiary
        {
            get
            {
                return Item.IdJednostkiMiary;
            }
            set
            {
                if (value != Item.IdJednostkiMiary)
                {
                    Item.IdJednostkiMiary = value;
                    base.OnPropertyChanged(() => IdJednostkiMiary);
                }
            }
        }
        public IQueryable<KeyAndValue> JednostkiMiaryComboBoxItems
        {
            get
            {
                return
                (
                    from JednostkaMiary in Db.JednostkaMiary
                    select new KeyAndValue
                    {
                        Key = JednostkaMiary.IdJednostkiMiary,
                        Value = JednostkaMiary.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }

        public string PKWiU
        {
            get
            {
                return Item.PKWiU;
            }
            set
            {
                if (value != Item.PKWiU)
                {
                    Item.PKWiU = value;
                    base.OnPropertyChanged(() => PKWiU);
                }
            }
        }
        public int IdTypuTowaru
        {
            get
            {
                return Item.IdTypuTowaru;
            }
            set
            {
                if (value != Item.IdTypuTowaru)
                {
                    Item.IdTypuTowaru = value;
                    base.OnPropertyChanged(() => IdTypuTowaru);
                }
            }
        }
        public IQueryable<KeyAndValue> TypTowaruComboBoxItems
        {
            get
            {
                return
                (
                    from TypTowaru in Db.TypTowaru
                    select new KeyAndValue
                    {
                        Key = TypTowaru.IdTypuTowaru,
                        Value = TypTowaru.Nazwa
                    }
                ).ToList().AsQueryable();
            }
        }

        public int? IdStawkiVATSprzedazy
        {
            get
            {
                return Item.IdStawkiVATSprzedazy;
            }
            set
            {
                if (value != Item.IdStawkiVATSprzedazy)
                {
                    Item.IdStawkiVATSprzedazy = value;
                    base.OnPropertyChanged(() => IdStawkiVATSprzedazy);
                }
            }
        }

        public int? IdStawkiVATZakupu
        {
            get
            {
                return Item.IdStawkiVATZakupu;
            }
            set
            {
                if (value != Item.IdStawkiVATZakupu)
                {
                    Item.IdStawkiVATZakupu = value;
                    base.OnPropertyChanged(() => IdStawkiVATZakupu);
                }
            }
        }

        public int? IdStawkiVATKaucji
        {
            get
            {
                return Item.IdStawkiVATKaucji;
            }
            set
            {
                if (value != Item.IdStawkiVATKaucji)
                {
                    Item.IdStawkiVATKaucji = value;
                    base.OnPropertyChanged(() => IdStawkiVATKaucji);
                }
            }
        }
        public IQueryable<KeyAndValue> StawkiVATComboBoxItems
        {
            get
            {
                return
                (
                    from RodzajVAT in Db.RodzajVAT
                    select new KeyAndValue
                    {
                        Key = RodzajVAT.IdRodzajuVAT,
                        Value = RodzajVAT.Nazwa + " " + RodzajVAT.Stawka
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
                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Nazwa);
                }
                if (name == "KodKreskowy")
                {
                    komunikat = BusinessValidator.SprawdzKodKreskowy(KodKreskowy);
                }
                if (name == "NrKatalogowy")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(NrKatalogowy);
                }
                if (name == "PKWiU")
                {
                    komunikat = BusinessValidator.SprawdzPKWiU(PKWiU);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["KodKreskowy"] == null && this["NrKatalogowy"] == null && this["PKWiU"] == null)
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
            Item.Kod = (Nazwa.Substring(0, 2)).ToUpper() + KodKreskowy.Substring(KodKreskowy.Length - 2);
            Item.KtoDodal = Environment.MachineName;
            Item.KiedyDodal = DateTime.Now;
            Db.Towar.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
