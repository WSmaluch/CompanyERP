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
    public class NowyMagazynViewModel : JedenViewModel<Magazyn>, IDataErrorInfo
    {

        #region Kontstruktor
        public NowyMagazynViewModel()
            : base("Dodawanie nowego magazynu")
        {
            Item = new Magazyn();
        }
        #endregion
        #region Properties
        public string Symbol
        {
            get
            {
                return Item.Symbol;
            }
            set
            {
                if (value != Item.Symbol)
                {
                    Item.Symbol = value;
                    base.OnPropertyChanged(() => Symbol);
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
        public string Typ
        {
            get
            {
                return Item.Typ;
            }
            set
            {
                if (value != Item.Typ)
                {
                    Item.Typ = value;
                    base.OnPropertyChanged(() => Typ);
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
                if (name == "Opis")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Opis);
                }
                if (name == "Typ")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Typ);
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
            Db.Magazyn.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
