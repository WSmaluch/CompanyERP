using Firma.Helpers;
using Firma.Models;
using Firma.Models.Entities;
using Firma.Models.Validators;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NowyKrajViewModel : JedenViewModel<Kraj>, IDataErrorInfo
    {
        #region Konstruktor
        public NowyKrajViewModel()
            :base ("Dodawanie nowego kraju")
        {
            Item = new Kraj();
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
                if(value !=Item.Nazwa)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
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
                

                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Nazwa"] == null)
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
            Db.Kraj.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
