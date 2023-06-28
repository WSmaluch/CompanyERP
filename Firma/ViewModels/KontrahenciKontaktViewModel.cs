using Firma.Models.Entities;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Firma.ViewModels
{
    public class KontrahenciKontaktViewModel : WszystkieViewModel<KontrahenciKontaktForAllView>
    {
        public KontrahenciKontaktViewModel() : base("KontrahenciKontakt")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahenciKontaktForAllView>
               (
               from Kontrahent in Projekt2Entities.Kontrahent
               where Kontrahent.CzyAktywny == true
               select new KontrahenciKontaktForAllView
               {
                   IdKontrahenta = Kontrahent.IdKontrahenta,
                   Nazwa = Kontrahent.Nazwa,
                   NIP = Kontrahent.NIP,
                   AdresZKRSMiejscowosc = Kontrahent.Adres.Miejscowosc,
                   KontaktNazwaDzialu = Kontrahent.Kontakt.NazwaDzialu,
                   KontaktTelefon1 = Kontrahent.Kontakt.Telefon1,
                   KontaktTelefon2 = Kontrahent.Kontakt.Telefon2,
                   KontaktEmail1 = Kontrahent.Kontakt.Email1,
                   KontaktEmail2 = Kontrahent.Kontakt.Email2,
                   KontaktFax = Kontrahent.Kontakt.Fax,
                   KontaktUwagi = Kontrahent.Kontakt.Uwagi,
               }
               );
        }
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Miejscowosc")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.OrderBy(Item => Item.AdresZKRSMiejscowosc));
            }
            if (SortField == "Nazwa działu")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.OrderBy(Item => Item.KontaktNazwaDzialu));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Miejscowosc", "Nazwa działu" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Miejscowosc")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.Where(Item => Item.AdresZKRSMiejscowosc != null && Item.AdresZKRSMiejscowosc.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa działu")
            {
                List = new ObservableCollection<KontrahenciKontaktForAllView>(List.Where(Item => Item.KontaktNazwaDzialu != null && Item.KontaktNazwaDzialu.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Miejscowosc", "Nazwa działu" };
        }
        #endregion
        #endregion
    }
}
