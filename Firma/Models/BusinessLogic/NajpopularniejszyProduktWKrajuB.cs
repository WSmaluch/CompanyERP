using Firma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class NajpopularniejszyProduktWKrajuB : DatabaseClass
    {
        #region Konstruktor
        public NajpopularniejszyProduktWKrajuB(Projekt2Entities projekt2Entities) : base(projekt2Entities)
        {
        }
        #endregion
        #region Funkcje biznesowe
        public string NajpopularniejszyTowarKraj(int IdKraju, DateTime dataOd, DateTime dataDo)
        {
            var popularnyProdukt = (from pf in Projekt2Entities.PozycjaFaktury
                                    join d in Projekt2Entities.Dokument on pf.IdDokumentu equals d.IdDokumentu
                                    join t in Projekt2Entities.Towar on pf.IdTowaru equals t.IdTowaru
                                    join k in Projekt2Entities.Kontrahent on d.IdKontrahenta equals k.IdKontrahenta
                                    join a in Projekt2Entities.Adres on k.IdAdresuZKRS equals a.IdAdresu
                                    join kr in Projekt2Entities.Kraj on a.IdKraju equals kr.IdKraju
                                    where kr.IdKraju == IdKraju && d.DataWystawienia >= dataOd && d.DataWystawienia <= dataDo
                                    group t by t.Nazwa into g
                                    orderby g.Count() descending
                                    select g.Key).FirstOrDefault();

            if (popularnyProdukt == null)
            {
                return "Nie znaleziono towaru";
            }
            return popularnyProdukt;
        }

        #endregion
    }
}
