using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class TowarForAllView
    {
        #region Properties
        public int IdTowaru { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string KodKreskowy { get; set; }
        public string NrKatalogowy { get; set; }
        public string JednostkiMiaryNazwa { get; set; }
        public string PKWiU { get; set; }
        public string TypTowaruNazwa { get; set; }
        public string StawkaVATSprzedazyStawka { get; set; }
        public string StawkaVATZakupuStawka { get; set; }
        public string StawkaVATKaucjiStawka { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
