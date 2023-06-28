using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Models.BusinessLogic
{
    public class TowarB : DatabaseClass
    {
        #region Konstruktor
        public TowarB(Projekt2Entities projekt2Entities) : base(projekt2Entities) 
        {
        }
        #endregion
        #region Funkcje biznesowe
        //ta funkcja pobiera wszystkie aktywne towary z bazy danych
        //bedzie zwraca liste zawierajaca nazwie i id towaru
        public IQueryable<KeyAndValue> GetAktywneTowary() // ta funkcja zwroci kolekcje KeyAndValue dla comboboxa wyswietlajacego wszystkie aktywne towary
        {
             return
                (
                    from towar in Projekt2Entities.Towar //dla kazdego towaru z bazy danych towarow
                    where towar.CzyAktywny == true
                    select new KeyAndValue
                    {
                        Key = towar.IdTowaru,
                        Value = towar.Nazwa
                    }
                ).ToList().AsQueryable();
        }

        #endregion
    }
}
