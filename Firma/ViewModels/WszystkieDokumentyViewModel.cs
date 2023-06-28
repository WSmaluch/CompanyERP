using Firma.Models;
using Firma.Models.EntitiesForView;
using Firma.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firma.ViewModels
{
    public class WszystkieDokumentyViewModel : WszystkieViewModel<DokumentForAllView>
    {
        #region Properties
        bool add = false;
        private DokumentForAllView _WybranyDokument;
        public DokumentForAllView WybranyDokument
        {
            get
            {
                return _WybranyDokument;
            }
            set
            {
                if (value != _WybranyDokument)
                {
                    _WybranyDokument = value;
                    Messenger.Default.Send(_WybranyDokument);
                    if(add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszystkieDokumentyViewModel() : base("Wszystkie dokumenty")
        {
        }
        public WszystkieDokumentyViewModel(bool _add) : base("Wszystkie dokumenty")
        {
            add= _add;
        }
        #region Helpers
        public override void Load()
    {
        List = new ObservableCollection<DokumentForAllView>
           (
           from Dokument in Projekt2Entities.Dokument
           where Dokument.CzyAktywny == true
           select new DokumentForAllView
           {
               IdDokuemntu = Dokument.IdDokumentu,
               TypDokumentNazwa = Dokument.TypDokumentu.Nazwa,
               KontrahentNazwa = Dokument.Kontrahent.Nazwa,
               KategoriaDokumentNazwa = Dokument.KategoriaDokumentu.Nazwa,
               MagazynuNazwa = Dokument.Magazyn.Nazwa,
               DataWystawienia = Dokument.DataWystawienia,
               DataSprzedazy = Dokument.DataSprzedazy,
               FakturaLiczonaOd = Dokument.FakturaLiczonaOd,
               Rabat = Dokument.Rabat,
               SposobuPlatnosciNazwa = Dokument.SposobPlatnosci.Nazwa,
               Termin = Dokument.Termin,
               CzyAktywny = Dokument.CzyAktywny,
               KiedyDodal = Dokument.KiedyDodal,
               KtoZmodyfikowal = Dokument.KtoZmodyfikowal,
               KiedyZmodyfikowal = Dokument.KiedyZmodyfikowal,
               KtoUsunal = Dokument.KtoUsunal,
               KiedyUsunal = Dokument.KiedyUsunal
           }
           );
    }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.KontrahentNazwa));
            }
            if (SortField == "Typ dokumentu")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.TypDokumentNazwa));
            }
            if (SortField == "Kategoria dokumentu")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.KategoriaDokumentNazwa));
            }
            if (SortField == "Nazwa magazynu")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.MagazynuNazwa));
            }
            if (SortField == "Data wystawienia")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.DataWystawienia));
            }
            if (SortField == "Data sprzedazy")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.DataSprzedazy));
            }
            if (SortField == "Termin")
            {
                List = new ObservableCollection<DokumentForAllView>(List.OrderBy(Item => Item.Termin));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa kontrahenta", "Typ dokumentu", "Kategoria dokumentu", "Nazwa magazynu", "Data wystawienia", "Data sprzedazy", "Termin" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa kontrahenta")
            {
                List = new ObservableCollection<DokumentForAllView>(List.Where(Item => Item.KontrahentNazwa != null && Item.KontrahentNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Nazwa magazynu")
            {
                List = new ObservableCollection<DokumentForAllView>(List.Where(Item => Item.MagazynuNazwa != null && Item.MagazynuNazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Data wystawienia")
            {
                //List = new ObservableCollection<DokumentForAllView>(List.Where(Item => Item.DataWystawienia != null && Item.DataWystawienia.StartsWith(FindTextBox)));
            }
            if (FindField == "Data sprzedazy")
            {
                //List = new ObservableCollection<DokumentForAllView>(List.Where(Item => Item.DataSprzedazy != null && Item.DataSprzedazy.StartsWith(FindTextBox)));
            }
            if (FindField == "Termin")
            {
                //List = new ObservableCollection<DokumentForAllView>(List.Where(Item => Item.Termin != null && Item.Termin.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa kontrahenta", "Nazwa magazynu", "Data wystawienia", "Data sprzedazy", "Termin" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Dokument.Where(a => a.IdDokumentu == WybranyDokument.IdDokuemntu).FirstOrDefault();
                if (del != null)
                {
                    del.CzyAktywny = false;
                    del.KiedyUsunal = DateTime.Now;
                    del.KtoUsunal = Environment.MachineName;
                    Projekt2Entities.SaveChanges();
                    Load();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Proszę o zaznaczenie!", "Uwaga!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
