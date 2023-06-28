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
    public class NowaKategoriaSerwisuViewModel : JedenViewModel<KategorieSerwisu>, IDataErrorInfo
    {
        #region Konstruktor
        public NowaKategoriaSerwisuViewModel()
                : base("Dodawanie nowej kategorii serwisu")
        {
            Item = new KategorieSerwisu();
        }
        #endregion
        #region Properties
        public string NazwaUslugi
        {
            get
            {
                return Item.NazwaUslugi;
            }
            set
            {
                if (value != Item.NazwaUslugi)
                {
                    Item.NazwaUslugi = value;
                    base.OnPropertyChanged(() => NazwaUslugi);
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
                if (name == "NazwaUslugi")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDuzej(NazwaUslugi);
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
            if (this["NazwaUslugi"] == null && this["Opis"] == null)
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
            Item.KiedyDodal = (DateTime.Now).ToString();
            Db.KategorieSerwisu.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
