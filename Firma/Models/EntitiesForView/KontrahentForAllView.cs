using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class KontrahentForAllView
    {
        #region Properties
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string NIP { get; set; }
        public bool PodatnikVAT { get; set; }
        public string PESEL { get; set; }
        public string REGON { get; set; }
        public string KRS { get; set; }
        public string GLN { get; set; }
        public string AdresZKRSMiejscowosc { get; set; }
        public string AdresZKRSUlica { get; set; }
        public string AdresZKRSNrDomu { get; set; }
        public string AdresuSiedzibyMiejscowosc { get; set; }
        public string AdresuSiedzibyUlica { get; set; }
        public string AdresuSiedzibyNrDomu { get; set; }
        public string AdresuKontaktowegoMiejscowosc { get; set; }
        public string AdresuKontaktowegoUlica { get; set; }
        public string AdresuKontaktowegoNrDomu { get; set; }
        public int? IdKontaktu { get; set; }
        public string TypKontrahentaNazwa { get; set; }
        public string RodzajuKontrahentaNazwa { get; set; }
        public string KategoriaKontrahentaNazwa { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
