using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region Entities
        public Projekt2Entities Projekt2Entities { get; set; }
        #endregion
        #region Konstruktor
        public DatabaseClass(Projekt2Entities projekt2Entities)
        {
            this.Projekt2Entities = projekt2Entities;
        }
        #endregion

    }
}
