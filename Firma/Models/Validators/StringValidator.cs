using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string SprawdzCzyNiePuste(string wartosc)
        {
            if (string.IsNullOrEmpty(wartosc))
            {
                return "Wartość nie może być pusta.";
            }

            return null;
        }
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!Char.IsUpper(wartosc, 0)) 
                {
                    return "Rozpocznij duzą litera";
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string SprawdzCzyLiczba(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    double temp;
                    if (!double.TryParse(wartosc, out temp))
                    {
                        return "Musi być liczbą";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        
    }
}
