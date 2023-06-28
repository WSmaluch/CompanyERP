using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class WydanieZewnetrzneForAllView
    {
        #region Properties
        public int IdWydaniaZewnetrznego { get; set; }
        public string NumerPrzyjecia { get; set; }
        public string KontrahentNazwa { get; set; }
        public string MagazynNazwa { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public decimal? Rabat { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
