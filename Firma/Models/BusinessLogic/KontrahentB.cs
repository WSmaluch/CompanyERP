using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class KontrahentB : DatabaseClass
    {
        #region Konstruktor
        public KontrahentB(Projekt2Entities projekt2Entities) : base(projekt2Entities)
        {
        }
        #endregion
        #region Funkcje biznesowe

        public IQueryable<KeyAndValue> GetKontrahenci() 
        {
            return
               (
                   from kontrahent in Projekt2Entities.Kontrahent 
                    where kontrahent.CzyAktywny == true
                   select new KeyAndValue
                   {
                       Key = kontrahent.IdKontrahenta,
                       Value = kontrahent.Nazwa
                   }
               ).ToList().AsQueryable();
        }
        #endregion
    }
}