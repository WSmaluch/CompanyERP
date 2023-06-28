using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZlecenieSerwisoweForAllView
    {
        #region Properties
        public int IdZleceniaSerwisowego { get; set; }
        public string KontrahentaNazwa { get; set; }
        public string KategoriiSerwisuNazwa { get; set; }
        public string UrzadzeniaNazwa { get; set; }
        public string MagazynuNazwa { get; set; }
        public string SerwisantNazwisko { get; set; }
        public string Priorytet { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime? DataRealizacji { get; set; }
        public TimeSpan PlanowanyCzas { get; set; }
        public TimeSpan? RzeczywistyCzas { get; set; }
        public string Opis { get; set; }
        public string Status { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
