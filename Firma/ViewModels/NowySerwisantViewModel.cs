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
    public class NowySerwisantViewModel : JedenViewModel<Serwisanci>, IDataErrorInfo
    {
        #region Konstruktor
        public NowySerwisantViewModel()
        : base("Dodawanie nowego serwisanta")
        {
            Item = new Serwisanci();
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
        public string NazwaFirmy
        {
            get
            {
                return Item.NazwaFirmy;
            }
            set
            {
                if (value != Item.NazwaFirmy)
                {
                    Item.NazwaFirmy = value;
                    base.OnPropertyChanged(() => NazwaFirmy);
                }
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
                    from KategorieSerwisu in Db.KategorieSerwisu
                    select new KeyAndValue
                    {
                        Key = KategorieSerwisu.IdKategoriiSerwisu,
                        Value = KategorieSerwisu.NazwaUslugi
                    }
                ).ToList().AsQueryable();
            }
        }
        public decimal Koszt
        {
            get
            {
                return Item.Koszt;
            }
            set
            {
                if (value != Item.Koszt)
                {
                    Item.Koszt = value;
                    base.OnPropertyChanged(() => Koszt);
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
                if (name == "Imie")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Imie);
                }
                if (name == "Nazwisko")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Nazwisko);
                }
                if (name == "NazwaFirmy")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(NazwaFirmy);
                }
                if (name == "Koszt")
                {
                    komunikat = DecimalValidator.SprawdzCzyLiczba(Koszt);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["Opis"] == null && this["Typ"] == null)
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
            Db.Serwisanci.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
