using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class KrajB : DatabaseClass
    {
        #region Konstruktor
        public KrajB(Projekt2Entities projekt2Entities) : base(projekt2Entities)
        {
        }
        #endregion
        #region Funkcje biznesowe

        public IQueryable<KeyAndValue> GetKraje()
        {
            return
               (
                   from Kraj in Projekt2Entities.Kraj
                   where Kraj.CzyAktywny == true
                   select new KeyAndValue
                   {
                       Key = Kraj.IdKraju,
                       Value = Kraj.Nazwa
                   }
               ).ToList().AsQueryable();
        }
        #endregion
    }
}
