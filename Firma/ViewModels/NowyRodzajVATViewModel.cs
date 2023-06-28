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
    public class NowyRodzajVATViewModel : JedenViewModel<RodzajVAT>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyRodzajVATViewModel()
        : base("Dodawanie nowego rodzaju VAT")
        {
            Item = new RodzajVAT();
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
        public string Stawka
        {
            get
            {
                return Item.Stawka;
            }
            set
            {
                if (value != Item.Stawka)
                {
                    Item.Stawka = value;
                    base.OnPropertyChanged(() => Stawka);
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
                if (name == "Stawka")
                {
                    komunikat = BusinessValidator.SprawdzStawkeVAT(Stawka);
                }
                if (name == "Opis")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(Opis);
                }

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["Stawka"] == null && this["Opis"] == null)
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
            Db.RodzajVAT.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
