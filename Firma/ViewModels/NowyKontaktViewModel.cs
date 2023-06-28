using Firma.Models.Entities;
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
    public class NowyKontaktViewModel : JedenViewModel<Kontakt>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyKontaktViewModel()
                : base("Dodawanie nowego kontaktu")
        {
            Item = new Kontakt();
        }
        #endregion
        #region Properties
        public string NazwaDzialu
        {
            get
            {
                return Item.NazwaDzialu;
            }
            set
            {
                if (value != Item.NazwaDzialu)
                {
                    Item.NazwaDzialu = value;
                    base.OnPropertyChanged(() => NazwaDzialu);
                }
            }
        }
        public string Telefon1
        {
            get
            {
                return Item.Telefon1;
            }
            set
            {
                if (value != Item.Telefon1)
                {
                    Item.Telefon1 = value;
                    base.OnPropertyChanged(() => Telefon1);
                }
            }
        }
        public string Telefon2
        {
            get
            {
                return Item.Telefon2;
            }
            set
            {
                if (value != Item.Telefon2)
                {
                    Item.Telefon2 = value;
                    base.OnPropertyChanged(() => Telefon2);
                }
            }
        }
        public string Email1
        {
            get
            {
                return Item.Email1;
            }
            set
            {
                if (value != Item.Email1)
                {
                    Item.Email1 = value;
                    base.OnPropertyChanged(() => Email1);
                }
            }
        }
        public string Email2
        {
            get
            {
                return Item.Email2;
            }
            set
            {
                if (value != Item.Email2)
                {
                    Item.Email2 = value;
                    base.OnPropertyChanged(() => Email2);
                }
            }
        }
        public string Fax
        {
            get
            {
                return Item.Fax;
            }
            set
            {
                if (value != Item.Fax)
                {
                    Item.Fax = value;
                    base.OnPropertyChanged(() => Fax);
                }
            }
        }
        public string Uwagi
        {
            get
            {
                return Item.Uwagi;
            }
            set
            {
                if (value != Item.Uwagi)
                {
                    Item.Uwagi = value;
                    base.OnPropertyChanged(() => Uwagi);
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
                if (name == "NazwaDzialu")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(NazwaDzialu);
                }
                if (name == "Telefon1")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(Telefon1);
                }
                if (name == "Telefon1")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(Telefon1);
                }
                if (name == "Fax")
                {
                    komunikat = StringValidator.SprawdzCzyLiczba(Fax);
                }
                if (name == "Email1")
                {
                    komunikat = BusinessValidator.SprawdzEmail(Email1);
                }
                if (name == "Email2")
                {
                    komunikat = BusinessValidator.SprawdzEmail(Email2);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["NazwaDzialu"] == null && this["Telefon1"] == null && this["Telefon1"] == null && this["Fax"] == null && this["Email1"] == null && this["Email2"] == null)
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
            Db.Kontakt.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
