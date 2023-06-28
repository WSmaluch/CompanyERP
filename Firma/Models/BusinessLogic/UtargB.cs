using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firma.Models.BusinessLogic
{
    public class UtargB : DatabaseClass
    {
        #region Konstruktor
        public UtargB(Projekt2Entities projekt2Entities) : base(projekt2Entities)
        {
        }
        #endregion
        #region Funkcje biznesowe
        public decimal? UtargOkresTowar(int IdTowaru, DateTime dataOd, DateTime dataDo)
        {
            try
            {
                var utarg = from pf in Projekt2Entities.PozycjaFaktury
                            join d in Projekt2Entities.Dokument on pf.IdDokumentu equals d.IdDokumentu
                            where pf.IdTowaru == IdTowaru &&
                            pf.CzyAktywny == true &&
                            d.DataWystawienia >= dataOd &&
                            d.DataWystawienia <= dataDo
                            select pf.Cena * pf.Ilosc;

                return Math.Round(utarg.Sum(),2);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nie można obliczyć utargu", "Uwaga!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
        #endregion
    }
}
