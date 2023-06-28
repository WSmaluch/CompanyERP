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
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllVIew>
    {
        #region Properties
        bool add = false;
        private PracownikForAllVIew _WybranyPracownik;
        public PracownikForAllVIew WybranyPracownik
        {
            get
            {
                return _WybranyPracownik;
            }
            set
            {
                if (value != _WybranyPracownik)
                {
                    _WybranyPracownik = value;
                    Messenger.Default.Send(_WybranyPracownik);
                    if (add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        public WszyscyPracownicyViewModel() : base("Wszyscy pracownicy")
        {
        }
        public WszyscyPracownicyViewModel(bool _add) : base("Wszyscy pracownicy")
        {
            add = _add;
        }
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<PracownikForAllVIew>
               (
               from Pracownik in Projekt2Entities.Pracownik
               where Pracownik.CzyAktywny == true
               select new PracownikForAllVIew
               {
                   IdPracownika = Pracownik.IdPracownika,
                   Imie = Pracownik.Imie,
                   Nazwisko = Pracownik.Nazwisko,
                   PESEL = Pracownik.PESEL,
                   DataUrodzenia = Pracownik.DataUrodzenia,
                   ImieOjca = Pracownik.ImieOjca,
                   ImieMatki = Pracownik.ImieMatki,
                   NazwiskoRodowe = Pracownik.NazwiskoRodowe,
                   AdresMiejscowosc = Pracownik.Adres.Miejscowosc,
                   AdresUlica = Pracownik.Adres.Ulica,
                   AdresNrDomu = Pracownik.Adres.NumerDomu,
                   AdresNrLokalu = Pracownik.Adres.NumerLokalu,
                   KontaktNrTelefonu = Pracownik.Kontakt.Telefon1,
                   CzyAktywny = Pracownik.CzyAktywny,
                   KiedyDodal = Pracownik.KiedyDodal,
                   KtoZmodyfikowal = Pracownik.KtoZmodyfikowal,
                   KiedyZmodyfikowal = Pracownik.KiedyZmodyfikowal,
                   KtoUsunal = Pracownik.KtoUsunal,
                   KiedyUsunal = Pracownik.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwisko")
            {
                List = new ObservableCollection<PracownikForAllVIew>(List.OrderBy(Item => Item.Nazwisko));
            }
            if (SortField == "Miejscowosc")
            {
                List = new ObservableCollection<PracownikForAllVIew>(List.OrderBy(Item => Item.AdresMiejscowosc));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwisko", "Miejscowosc" };
        }
        public override void Find()
        {
            if (FindField == "Nazwisko")
            {
                List = new ObservableCollection<PracownikForAllVIew>(List.Where(Item => Item.Nazwisko != null && Item.Nazwisko.StartsWith(FindTextBox)));
            }
            if (FindField == "Miejscowosc")
            {
                List = new ObservableCollection<PracownikForAllVIew>(List.Where(Item => Item.AdresMiejscowosc != null && Item.AdresMiejscowosc.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwisko", "Miejscowosc" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Pracownik.Where(a => a.IdPracownika == WybranyPracownik.IdPracownika).FirstOrDefault();
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
