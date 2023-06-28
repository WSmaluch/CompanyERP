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
    public class NoweUrzadzenieViewModel : JedenViewModel<Urzadzenie>, IDataErrorInfo
    {
        #region Konstruktor
        public NoweUrzadzenieViewModel()
        : base("Dodawanie nowego urzadzenia")
        {
            Item = new Urzadzenie();
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


                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null && this["Opis"] == null)
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
            Db.Urzadzenie.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
