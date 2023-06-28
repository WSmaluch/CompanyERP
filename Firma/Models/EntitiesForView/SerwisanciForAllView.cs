using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class SerwisanciForAllView
    {
        #region Properties
        public int IdSerwisanta { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NazwaFirmy { get; set; }
        public string KategoriaSerwisuNazwa { get; set; }
        public decimal Koszt { get; set; }
        public bool? CzyAktywny { get; set; }
        public string KtoDodal { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
