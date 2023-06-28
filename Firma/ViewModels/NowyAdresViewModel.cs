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
    public class NowyAdresViewModel : JedenViewModel<Adres>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyAdresViewModel()
        : base("Dodawanie nowego adresu")
        {
            Item = new Adres();
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
        public string Miejscowosc
        {
            get
            {
                return Item.Miejscowosc;
            }
            set
            {
                if (value != Item.Miejscowosc)
                {
                    Item.Miejscowosc = value;
                    base.OnPropertyChanged(() => Miejscowosc);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (value != Item.KodPocztowy)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return Item.Poczta;
            }
            set
            {
                if (value != Item.Poczta)
                {
                    Item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (value != Item.Ulica)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NumerDomu
        {
            get
            {
                return Item.NumerDomu;
            }
            set
            {
                if (value != Item.NumerDomu)
                {
                    Item.NumerDomu = value;
                    base.OnPropertyChanged(() => NumerDomu);
                }
            }
        }
        public string NumerLokalu
        {
            get
            {
                return Item.NumerLokalu;
            }
            set
            {
                if (value != Item.NumerLokalu)
                {
                    Item.NumerLokalu = value;
                    base.OnPropertyChanged(() => NumerLokalu);
                }
            }
        }
        public int IdKraju
        {
            get
            {
                return Item.IdKraju;
            }
            set
            {
                if (value != Item.IdKraju)
                {
                    Item.IdKraju = value;
                    base.OnPropertyChanged(() => IdKraju);
                }
            }
        }
        public IQueryable<KeyAndValue> KrajeComboBoxItems
        {
            get
            {
                return
                (
                    from Kraj in Db.Kraj
                    select new KeyAndValue
                    {
                        Key = Kraj.IdKraju,
                        Value = Kraj.Nazwa
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
                if (name == "Miejscowosc")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Miejscowosc);
                }
                if (name == "Poczta")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Poczta);
                }
                if (name == "Ulica")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Ulica);
                }
                if (name == "NumerDomu")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(NumerDomu);
                }
                if (name == "NumerLokalu")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(NumerLokalu);
                }
                if (name == "KodPocztowy")
                {
                    komunikat = StringValidator.SprawdzCzyNiePuste(KodPocztowy);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Miejscowosc"] == null && this["Poczta"] == null && this["Ulica"] == null && this["NumerDomu"] == null && this["NumerLokalu"] == null && this["KodPocztowy"] == null)
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
            Item.KiedyDodal = DateTime.Now;
            Item.KtoZmodyfikowal = Environment.MachineName;
            Item.Kod = Miejscowosc.Substring(0, Math.Min(3, Miejscowosc.Length)).ToUpper();
            Db.Adres.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
