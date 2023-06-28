using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class WszystkieZmianyCenyViewModel : WszystkieViewModel<ZmianaCenyForAllView>
    {
        public WszystkieZmianyCenyViewModel() : base("Wszystkie zmiany ceny")
        {
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZmianaCenyForAllView>
               (
               from ZmianaCeny in Projekt2Entities.ZmianaCeny
               where ZmianaCeny.CzyAktywny == true
               select new ZmianaCenyForAllView
               {
                   IdZmianyCeny = ZmianaCeny.IdZmianyCeny,
                   TowarNazwa = ZmianaCeny.Towar.Nazwa,
                   JednostkaMiaryNazwa = ZmianaCeny.JednostkaMiary.Nazwa,
                   CenaNetto = ZmianaCeny.CenaNetto,
                   DataObowiazywaniaOd = ZmianaCeny.DataObowiazywaniaOd,
                   DataObowiazywaniaDo = ZmianaCeny.DataObowiazywaniaDo,
                   CzyAktywny = ZmianaCeny.CzyAktywny,
                   KiedyDodal = ZmianaCeny.KiedyDodal,
                   KtoZmodyfikowal = ZmianaCeny.KtoZmodyfikowal,
                   KiedyZmodyfikowal = ZmianaCeny.KiedyZmodyfikowal,
                   KtoUsunal = ZmianaCeny.KtoUsunal,
                   KiedyUsunal = ZmianaCeny.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Towar")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.OrderBy(Item => Item.TowarNazwa));
            }
            if (SortField == "Jednostka miary")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.OrderBy(Item => Item.JednostkaMiaryNazwa));
            }
            if (SortField == "Cena netto")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.OrderBy(Item => Item.CenaNetto));
            }
            if (SortField == "Data obowiazywania od")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.OrderBy(Item => Item.DataObowiazywaniaOd));
            }
            if (SortField == "Data obowiazywania do")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.OrderBy(Item => Item.DataObowiazywaniaDo));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Towar", "Jednostka miary" , "Cena netto" , "Data obowiazywania od", "Data obowiazywania do" };
        }
        public override void Find()
        {
            if (SortField == "Towar")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.Where(Item => Item.TowarNazwa != null && Item.TowarNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Jednostka miary")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.Where(Item => Item.JednostkaMiaryNazwa != null && Item.JednostkaMiaryNazwa.StartsWith(FindTextBox)));
            }
            if (SortField == "Cena netto")
            {
                List = new ObservableCollection<ZmianaCenyForAllView>(List.Where(Item => Item.CenaNetto != null && Item.CenaNetto.StartsWith(FindTextBox)));
            }
            if (SortField == "Data obowiazywania od")
            {
                //List = new ObservableCollection<ZmianaCenyForAllView>(List.Where(Item => Item.DataObowiazywaniaOd != null && Item.DataObowiazywaniaOd.StartsWith(FindTextBox)));
            }
            if (SortField == "Data obowiazywania do")
            {
                //List = new ObservableCollection<ZmianaCenyForAllView>(List.Where(Item => Item.DataObowiazywaniaDo != null && Item.DataObowiazywaniaDo.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Towar", "Jednostka miary", "Cena netto", "Data obowiazywania od", "Data obowiazywania do" };
        }
        #endregion
    }
}
