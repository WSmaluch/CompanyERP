using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class KontrahenciKontaktForAllView
    {
        //#region Properties
        //public int IdKontrahentKontakt { get; set; }
        //public int IdKontrahenta { get; set; }
        //public int IdKontaktu { get; set; }
        //public bool? CzyAktywny { get; set; }
        //public DateTime? KiedyDodal { get; set; }
        //public string KtoZmodyfikowal { get; set; }
        //public DateTime? KiedyZmodyfikowal { get; set; }
        //public string KtoUsunal { get; set; }
        //public DateTime? KiedyUsunal { get; set; }
        //#endregion
        #region Properties
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string NIP { get; set; }
        public string AdresZKRSMiejscowosc { get; set; }
       
        public string KontaktNazwaDzialu { get; set; }
        public string KontaktTelefon1 { get; set; }
        public string KontaktTelefon2 { get; set; }
        public string KontaktEmail1 { get; set; }
        public string KontaktEmail2 { get; set; }
        public string KontaktFax { get; set; }
        public string KontaktUwagi { get; set; }
      
        #endregion
    }
}
