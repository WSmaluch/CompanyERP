using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.Validators
{
    public class BusinessValidator : Validator
    {
        public static string SprawdzVAT(decimal? wartosc)
        {
            if (wartosc < 0 || wartosc > 100)
            {
                return "VAT powinien byc z przedzialu 0-100";
            }
            return null;
        }
        public static string SprawdzCene(decimal? wartosc)
        {
            if (wartosc < 0)
            {
                return "Cena nie moze byc mniejsza od zera";
            }
            return null;
        }
        public static string SprawdzMarze(decimal? wartosc)
        {
            if (wartosc > 100)
            {
                return "Marza nie moze byc wieksza od 100";
            }
            return null;
        }
        public static string SprawdzREGON(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    int length = wartosc.Length;
                    if (length != 9 && length != 14)
                    {
                        return "REGON musi mieć 9 lub 14 znaków";
                    }
                    int[] weights;
                    if (length == 9)
                    {
                        weights = new int[] { 8, 9, 2, 3, 4, 5, 6, 7 };
                    }
                    else
                    {
                        weights = new int[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
                    }
                    int sum = 0;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        sum += weights[i] * Convert.ToInt32(wartosc[i].ToString());
                    }
                    int checkDigit = sum % 11;
                    if (checkDigit == 10)
                    {
                        checkDigit = 0;
                    }
                    if (Convert.ToInt32(wartosc[length - 1].ToString()) != checkDigit)
                    {
                        return "Nieprawidłowy REGON";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string SprawdzPESEL(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 11)
                    {
                        return "PESEL musi mieć 11 znaków";
                    }
                    int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                    int sum = 0;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        sum += weights[i] * Convert.ToInt32(wartosc[i].ToString());
                    }
                    int checkDigit = (10 - (sum % 10)) % 10;
                    if (Convert.ToInt32(wartosc[10].ToString()) != checkDigit)
                    {
                        return "Nieprawidłowy PESEL";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string SprawdzNIP(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 10)
                    {
                        return "NIP musi mieć 10 znaków";
                    }
                    int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
                    int sum = 0;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        sum += weights[i] * Convert.ToInt32(wartosc[i].ToString());
                    }
                    int checkDigit = sum % 11;
                    if (checkDigit == 10)
                    {
                        checkDigit = 0;
                    }
                    if (Convert.ToInt32(wartosc[9].ToString()) != checkDigit)
                    {
                        return "Nieprawidłowy NIP";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string SprawdzKRS(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 10)
                    {
                        return "KRS musi mieć 10 znaków";
                    }
                    int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    int sum = 0;
                    for (int i = 0; i < weights.Length; i++)
                    {
                        sum += weights[i] * Convert.ToInt32(wartosc[i].ToString());
                    }
                    int checkDigit = sum % 11;
                    if (checkDigit == 10)
                    {
                        return "Nieprawidłowy KRS";
                    }
                    if (Convert.ToInt32(wartosc[9].ToString()) != checkDigit)
                    {
                        return "Nieprawidłowy KRS";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        public static string SprawdzGLN(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 13)
                    {
                        return "GLN musi składać się z 13 cyfr";
                    }
                    else
                    {
                        long temp;
                        if (!long.TryParse(wartosc, out temp))
                        {
                            return "GLN musi składać się z cyfr";
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string SprawdzStawkeVAT(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    double temp;
                    if (!double.TryParse(wartosc, out temp))
                    {
                        return "Stawka VAT musi być liczbą";
                    }
                    else if (temp < 0 || temp > 100)
                    {
                        return "Stawka VAT musi zawierać się w przedziale od 0 do 100";
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string SprawdzKodKreskowy(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 13)
                    {
                        return "Kod kreskowy musi składać się z 13 cyfr";
                    }
                    else
                    {
                        long temp;
                        if (!long.TryParse(wartosc, out temp))
                        {
                            return "Kod kreskowy musi składać się z cyfr";
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string SprawdzPKWiU(string wartosc)
        {
            try
            {
                if (!string.IsNullOrEmpty(wartosc))
                {
                    if (wartosc.Length != 7)
                    {
                        return "Numer PKWiU musi składać się z 7 znaków";
                    }
                    else
                    {
                        long temp;
                        if (!long.TryParse(wartosc, out temp))
                        {
                            return "Numer PKWiU musi składać się z cyfr";
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static string SprawdzEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }

            try
            {
                MailAddress mailAddress = new MailAddress(email);
            }
            catch (FormatException)
            {
                return "Niepoprawny format adresu e-mail.";
            }

            return null;
        }

    }
}
