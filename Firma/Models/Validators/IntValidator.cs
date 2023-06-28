using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class IntValidator
    {
        public static string SprawdzCzyLiczba(int wartosc)
        {

            if (wartosc < 0)
            {
                return "Liczba jest ujemna.";
            }
            return null;
        }
    }
}
