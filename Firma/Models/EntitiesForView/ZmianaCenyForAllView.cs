using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.EntitiesForView
{
    public class ZmianaCenyForAllView
    {
        #region Properties
        public int IdZmianyCeny { get; set; }
        public string TowarNazwa { get; set; }
        public string JednostkaMiaryNazwa { get; set; }
        public string CenaNetto { get; set; }
        public DateTime? DataObowiazywaniaOd { get; set; }
        public DateTime? DataObowiazywaniaDo { get; set; }
        public bool? CzyAktywny { get; set; }
        public DateTime? KiedyDodal { get; set; }
        public string KtoZmodyfikowal { get; set; }
        public DateTime? KiedyZmodyfikowal { get; set; }
        public string KtoUsunal { get; set; }
        public DateTime? KiedyUsunal { get; set; }
        #endregion
    }
}
