using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PozycjaFakturyForAllView
    {
        #region Properties
        public int IdPozycjiFaktury { get; set; }
        public int DokumentNumer { get; set; }
        public string TowarNazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
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
