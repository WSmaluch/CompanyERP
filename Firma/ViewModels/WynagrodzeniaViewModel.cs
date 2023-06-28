using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WynagrodzeniaViewModel: WorkspaceViewModel //bo wszystkie zakładki dziedzicza po WorkspaceViewModel
    {
        #region Konstruktor
        public WynagrodzeniaViewModel()
        {
            base.DisplayName = "Wynagrodzenia";//tu ustawiamy nazwę zakładki
        }
        #endregion

    }
}
