using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class PracownikForAllVIew
    {
        #region Properties
        public int IdPracownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string ImieOjca { get; set; }
        public string ImieMatki { get; set; }
        public string NazwiskoRodowe { get; set; }
        public string AdresMiejscowosc { get; set; }
        public string AdresUlica { get; set; }
        public string AdresNrDomu { get; set; }
        public string AdresNrLokalu { get; set; }
        public string KontaktNrTelefonu { get; set; }
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
