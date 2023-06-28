using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class UrzadzenieForAllView
    {
        #region Properties
        public int IdUrzadzenia { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Uwagi { get; set; }
        public string KategoriaSerwisuNzawa { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
