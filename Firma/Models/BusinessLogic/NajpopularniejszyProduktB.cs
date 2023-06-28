using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class NajpopularniejszyProduktB : DatabaseClass
    {
        #region Konstruktor
        public NajpopularniejszyProduktB(Projekt2Entities projekt2Entities) : base(projekt2Entities)
        {
        }
        #endregion
        #region Funkcje biznesowe
        public string NajpopularniejszyTowarOkres(int IdKontrahenta, DateTime dataOd, DateTime dataDo)
        {
            var najpopularniejszy = 
               (
               from pf in Projekt2Entities.PozycjaFaktury
               join d in Projekt2Entities.Dokument on pf.IdDokumentu equals d.IdDokumentu
               join t in Projekt2Entities.Towar on pf.IdTowaru equals t.IdTowaru
               where d.IdKontrahenta == IdKontrahenta && d.DataSprzedazy >= dataOd && d.DataSprzedazy <= dataDo
               group t by t.Nazwa into g
               orderby g.Count() descending
               select g.Key
               ).FirstOrDefault();

            if (najpopularniejszy == null )
            {
                return "Nie znaleziono towaru";
            }
            return najpopularniejszy;
        }
        #endregion
    }
}
