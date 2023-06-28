using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PozycjaWydaniaZewnetrznegoTowaruForAllView
    {
        #region Properties
        public int IdPozycjaWydaniaZewnetrznegoTowaru { get; set; }
        public string TowarNazwa { get; set; }
        public string Ilosc { get; set; }
        public string JednostkiMiaryNazwa { get; set; }
        public string CenaZakupuPierwotna { get; set; }
        public decimal Rabat { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
