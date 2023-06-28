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
    public class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahentForAllView>
    {

        #region Properties
        bool add = false;
        private KontrahentForAllView _WybranyKontrahent;
        public KontrahentForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (value != _WybranyKontrahent)
                {
                    _WybranyKontrahent = value;
                    Messenger.Default.Send(_WybranyKontrahent);
                    if(add)
                    {
                        OnRequestClose();
                    }
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszyscyKontrahenciViewModel() : base("Wszyscy kontrahenci")
        {
        }
        public WszyscyKontrahenciViewModel(bool _add) : base("Wszyscy kontrahenci")
        {
            add = _add;
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahentForAllView>
               (
               from Kontrahent in Projekt2Entities.Kontrahent
               where Kontrahent.CzyAktywny == true
               select new KontrahentForAllView
               {
                   IdKontrahenta = Kontrahent.IdKontrahenta,
                   Nazwa = Kontrahent.Nazwa,
                   NIP = Kontrahent.NIP,
                   PodatnikVAT = Kontrahent.PodatnikVAT,
                   PESEL = Kontrahent.PESEL,
                   REGON = Kontrahent.REGON,
                   KRS = Kontrahent.KRS,
                   GLN = Kontrahent.GLN,
                   AdresZKRSMiejscowosc = Kontrahent.Adres.Miejscowosc,
                   AdresZKRSUlica = Kontrahent.Adres.Ulica,
                   AdresZKRSNrDomu = Kontrahent.Adres.NumerDomu,
                   AdresuSiedzibyMiejscowosc = Kontrahent.Adres.Miejscowosc,
                   AdresuSiedzibyUlica = Kontrahent.Adres.Ulica,
                   AdresuSiedzibyNrDomu = Kontrahent.Adres.NumerDomu,
                   AdresuKontaktowegoMiejscowosc = Kontrahent.Adres.Miejscowosc,
                   AdresuKontaktowegoUlica = Kontrahent.Adres.Ulica,
                   AdresuKontaktowegoNrDomu = Kontrahent.Adres.NumerDomu,
                   IdKontaktu=Kontrahent.IdKontaktu,
                   TypKontrahentaNazwa = Kontrahent.TypKontrahenta.Nazwa,
                   RodzajuKontrahentaNazwa = Kontrahent.RodzajKontrahenta.Nazwa,
                   KategoriaKontrahentaNazwa = Kontrahent.KategoriaKontrahenta.Nazwa,
                   CzyAktywny = Kontrahent.CzyAktywny,
                   KiedyDodal = Kontrahent.KiedyDodal,
                   KtoZmodyfikowal = Kontrahent.KtoZmodyfikowal,
                   KiedyZmodyfikowal = Kontrahent.KiedyZmodyfikowal,
                   KtoUsunal = Kontrahent.KtoUsunal,
                   KiedyUsunal = Kontrahent.KiedyUsunal
               }
               );
        }
        #endregion
        #region SortAndFind
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(Item => Item.Nazwa));
            }
            if (SortField == "Miejscowosc - adres kontaktowy")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.OrderBy(Item => Item.AdresuKontaktowegoMiejscowosc));
            }
        }
        public override List<string> GetComboBoxSortList()
        {
            return new List<string> { "Nazwa", "Miejscowosc - adres kontaktowy" };
        }
        public override void Find()
        {
            if(FindField == "Nazwa")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.Where(Item => Item.Nazwa != null && Item.Nazwa.StartsWith(FindTextBox)));
            }
            if (FindField == "Miejscowosc - adres kontaktowy")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.Where(Item => Item.AdresuKontaktowegoMiejscowosc != null && Item.AdresuKontaktowegoMiejscowosc.StartsWith(FindTextBox)));
            }
            if (FindField == "KRS")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.Where(Item => Item.KRS != null && Item.KRS.StartsWith(FindTextBox)));
            }
            if (FindField == "REGON")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.Where(Item => Item.REGON != null && Item.REGON.StartsWith(FindTextBox)));
            }
            if (FindField == "NIP")
            {
                List = new ObservableCollection<KontrahentForAllView>(List.Where(Item => Item.NIP != null && Item.NIP.StartsWith(FindTextBox)));
            }
        }
        public override List<string> GetComboBoxFindList()
        {
            return new List<string> { "Nazwa", "Miejscowosc - adres kontaktowy", "KRS", "REGON", "NIP" };
        }
        #endregion
        #region Functions
        public override void delete()
        {
            try
            {
                var del = Projekt2Entities.Kontrahent.Where(a => a.IdKontrahenta == WybranyKontrahent.IdKontrahenta).FirstOrDefault();
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
