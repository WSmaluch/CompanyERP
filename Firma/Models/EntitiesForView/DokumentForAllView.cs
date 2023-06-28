using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class DokumentForAllView
    {
        #region Properties
        public int IdDokuemntu { get; set; }
        public string TypDokumentNazwa { get; set; }
        public string KontrahentNazwa { get; set; }
        public string KategoriaDokumentNazwa { get; set; }
        public string MagazynuNazwa { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public string FakturaLiczonaOd { get; set; }
        public decimal Rabat { get; set; }
        public string SposobuPlatnosciNazwa { get; set; }
        public DateTime Termin { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
