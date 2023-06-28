using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class DecimalValidator : Validator
    {
        public static string SprawdzCzyLiczba(decimal wartosc)
        {

            if (wartosc < 0)
            {
                return "Liczba jest ujemna.";
            }
            return null;
        }
        public static string SprawdzRabat(decimal wartosc)
        {
            if (wartosc < 0)
            {
                return "Liczba jest za mala.";
            }

            if (wartosc > 100)
            {
                return "Liczba jest za duza.";
            }
            return null;
        }
        public static string SprawdzRabat(decimal? wartosc)
        {
            if (wartosc < 0)
            {
                return "Liczba jest za mala.";
            }

            if (wartosc > 100)
            {
                return "Liczba jest za duza.";
            }
            return null;
        }
    }
}
