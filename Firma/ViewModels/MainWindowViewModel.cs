using Firma.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public  class MainWindowViewModel : BaseViewModel
    {
        //będzie zawierała kolekcje komend, które pojawiają się w menu lewym oraz kolekcje zakładek 
        #region Konstruktor
        public MainWindowViewModel()
        {
            Messenger.Default.Register<string>(this, open);
        }
        #endregion
        #region Komendy menu i paska narzedzi
        public ICommand NowyTowarCommand //ta komenda zostanie podpieta pod menu i pasek narzedzi
        { 
            get
            {
                return new BaseCommand(()=>createView(new NowyTowarViewModel()));//to jest komenda, która wyw. funkcję createTowar
            }
        }
        public ICommand WynagrodzeniaCommand
        {
            get
            {
                return new BaseCommand(showWynagrodzenia);
            }
        }
        public ICommand NowaFakturaCommand 
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFakturaViewModel()));
            }
        }
        public ICommand NowyKontrahentCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyKontrahentViewModel()));
            }
        }

        public ICommand NowyAdresCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyAdresViewModel()));
            }
        }

        public ICommand NowaJednostkaMiaryCommand
        {
            get
            {
                return new BaseCommand(showAddJednostkaMiary);
            }
        }

        public ICommand NowaKategoriaDokumentuCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaKategoriaDokumentuViewModel()));
            }
        }

        public ICommand NowaKategoriaKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAddKategoriaKontrahenta);
            }
        }

        public ICommand NowaKategoriaSerwisuCommand
        {
            get
            {
                return new BaseCommand(showAddKategoriaSerwisu);
            }
        }

        public ICommand NowyKontaktCommand
        {
            get
            {
                return new BaseCommand(showAddKontakt);
            }
        }

        public ICommand NowyKrajCommand
        {
            get
            {
                return new BaseCommand(showAddKraj);
            }
        }

        public ICommand NowyMagazynCommand
        {
            get
            {
                return new BaseCommand(showAddMagazyn);
            }
        }
        public ICommand NowaPozycjaFakturyCommand
        {
            get
            {
                return new BaseCommand(showAddPozycjaFaktury);
            }
        }

        public ICommand NowaPozycjaPrzyjeciaZewnetrznegoTowaruCommand
        {
            get
            {
                return new BaseCommand(showAddPozycjaPrzyjeciaZewnetrznegoTowaru);
            }
        }
        public ICommand NowaPozycjaWydaniaZewnetrznegoTowaruCommand
        {
            get
            {
                return new BaseCommand(showAddPozycjaWydaniaZewnetrznegoTowaru);
            }
        }
        public ICommand NowyPracownikCommand
        {
            get
            {
                return new BaseCommand(showAddPracownik);
            }
        }
        public ICommand NowePrzyjecieZewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAddPrzyjecieZewnetrzne);
            }
        }
        public ICommand NowyRodzajKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAddRodzajKontrahenta);
            }
        }
        public ICommand NowyRodzajVATCommand
        {
            get
            {
                return new BaseCommand(showAddRodzajVAT);
            }
        }

        public ICommand NowySerwisantCommand
        {
            get
            {
                return new BaseCommand(showAddSerwisant);
            }
        }

        public ICommand NowySposobPlatnosciCommand
        {
            get
            {
                return new BaseCommand(showAddSposobPlatnosci);
            }
        }

        public ICommand NowyTypDokumentuCommand
        {
            get
            {
                return new BaseCommand(showAddTypDokumentu);
            }
        }

        public ICommand NowyTypKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAddTypKontrahenta);
            }
        }

        public ICommand NowyTypTowaruCommand
        {
            get
            {
                return new BaseCommand(showAddTypTowaru);
            }
        }

        public ICommand NoweUrzadzenieCommand
        {
            get
            {
                return new BaseCommand(showAddUrzadzenie);
            }
        }
        public ICommand NoweWydanieZewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAddWydanieZewnetrzne);
            }
        }
        public ICommand NowaZmianaCenyCommand
        {
            get
            {
                return new BaseCommand(showAddZmianaCeny);
            }
        }

        public ICommand ZlecenieSerwisoweCommand
        {
            get
            {
                return new BaseCommand(() => createView(new ZlecenieSerwisoweViewModel()));
            }
        }

        public ICommand WszyscySerwisanciCommand
        {
            get
            {
                return new BaseCommand(showAllSerwisanci);
            }
        }

        public ICommand WszystkieAdresyCommand
        {
            get
            {
                return new BaseCommand(showAllAdresy);
            }
        }

        public ICommand WszystkieDokumentyCommand
        {
            get
            {
                return new BaseCommand(showAllDokumenty);
            }
        }

        public ICommand WszystkieJednostkiMiaryCommand
        {
            get
            {
                return new BaseCommand(showAllJednostkiMiary);
            }
        }

        public ICommand WszystkieKategorieDokumentuCommand
        {
            get
            {
                return new BaseCommand(showAllKategorieDokumentu);
            }
        }

        public ICommand WszystkieKategorieKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAllKategorieKontrahenta);
            }
        }

        public ICommand WszystkieKategorieSerwisuCommand
        {
            get
            {
                return new BaseCommand(showAllKategorieSerwisiu);
            }
        }
        public ICommand WszystkieKontaktyCommand
        {
            get
            {
                return new BaseCommand(showAllKontakty);
            }
        }

        public ICommand WszyscyKontrahenciCommand
        {
            get
            {
                return new BaseCommand(showAllKontrahenci);
            }
        }
        public ICommand WszystkieKrajeCommand
        {
            get
            {
                return new BaseCommand(showAllKraje);
            }
        }

        public ICommand WszystkieMagazynyCommand
        {
            get
            {
                return new BaseCommand(showAllMagazyny);
            }
        }

        public ICommand WszystkiePozycjeFakturyCommand
        {
            get
            {
                return new BaseCommand(showAllPozycjeFaktury);
            }
        }

        public ICommand WszystkiePozycjePrzyjeciaZewnetrznegoTowaruCommand
        {
            get
            {
                return new BaseCommand(showAllPozycjePrzyjeciaZewnetrznegoTowaru);
            }
        }
        public ICommand WszystkiePozycjeWydaniaZewnetrznegoTowaruCommand
        {
            get
            {
                return new BaseCommand(showAllPozycjeWydaniaZewnetrznegoTowaru);
            }
        }
        public ICommand WszyscyPracownicyCommand
        {
            get
            {
                return new BaseCommand(showAllPracownicy);
            }
        }

        public ICommand WszystkiePrzyjeciaZewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAllPrzyjeciaZewnetrzne);
            }
        }
        public ICommand WszystkieRodzajeKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAllRodzajeKontrahenta);
            }
        }
        public ICommand WszystkieSposobyPlatnosciCommand
        {
            get
            {
                return new BaseCommand(showAllSposobyPlatnosci);
            }
        }

        public ICommand WszystkieTowaryCommand
        {
            get
            {
                return new BaseCommand(showAllTowary);
            }
        }
        public ICommand WszystkieTypyDokumentowCommand
        {
            get
            {
                return new BaseCommand(showAllTypyDokumentow);
            }
        }

        public ICommand WszystkieTypyKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAllTypyKontrahentow);
            }
        }

        public ICommand WszystkieTypyTowarowCommand
        {
            get
            {
                return new BaseCommand(showAllTypyTowarow);
            }
        }
        public ICommand WszystkieUrzadzeniaCommand
        {
            get
            {
                return new BaseCommand(showAllUrzadzenia);
            }
        }
        public ICommand WszystkieWydaniaZewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAllWydaniaZewnetrzne);
            }
        }
        public ICommand WszystkieZleceniaSerwisoweCommand
        {
            get
            {
                return new BaseCommand(showAllZleceniaSerwisowe);
            }
        }
        public ICommand WszystkieZmianyCenyCommand
        {
            get
            {
                return new BaseCommand(showAllZmianyCeny);
            }
        }
        public ICommand WszystkieRodzajeVATCommand
        {
            get
            {
                return new BaseCommand(showAllRodzajeVAT);
            }
        }
        public ICommand KontrahenciKontaktCommand
        {
            get
            {
                return new BaseCommand(showKontrahenciKontakt);
            }
        }
        public ICommand RaportSprzedazyCommand
        {
            get
            {
                return new BaseCommand(showRaportSprzedazy);
            }
        }
        public ICommand NajpopularniejszyProduktCommand
        {
            get
            {
                return new BaseCommand(showNajpopularniejszyProdukt);
            }
        }
        public ICommand NajpopularniejszyProduktWKrajuCommand
        {
            get
            {
                return new BaseCommand(showNajpopularniejszyProduktWKraju);
            }
        }
        #endregion

        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands;//to jest kolekcja komend w emnu lewym
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get 
            { 
                if(_Commands == null)//sprawdzam czy przyciski z lewej strony menu nie zostały zainicjalizowane
                {
                    List<CommandViewModel> cmds = this.CreateCommands();//tworzę listę przyciskow za pomocą funkcji CreateCommands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);//tę listę przypisuje do ReadOnlyCollection (bo readOnlyCollection można tylko tworzyć, nie można do niej dodawać)
                }
                return _Commands; 
            }   
        }
        private List<CommandViewModel> CreateCommands()//tu decydujemy jakie przyciski są w lewym menu
        {
            
            return new List<CommandViewModel>
            {
                
                new CommandViewModel("Towar",new BaseCommand(()=>createView(new NowyTowarViewModel())), "pack://application:,,,/Views/Content/Icons/package-variant-closed.png",
                    "pack://application:,,,/Views/Content/Icons/package-variant-closed-plus.png"),
                new CommandViewModel("Faktura",new BaseCommand(()=>createView(new NowaFakturaViewModel())), "pack://application:,,,/Views/Content/Icons/file-document-outline.png",
                    "pack://application:,,,/Views/Content/Icons/file-document-plus-outline.png"),
                new CommandViewModel("Kontrahent",new BaseCommand(()=>createView(new NowyKontrahentViewModel())), "pack://application:,,,/Views/Content/Icons/account.png",
                    "pack://application:,,,/Views/Content/Icons/account-plus.png"),
                new CommandViewModel("Serwis",new BaseCommand(()=>createView(new ZlecenieSerwisoweViewModel())),"pack://application:,,,/Views/Content/Icons/manage_accounts_FILL0_wght400_GRAD0_opsz48.png",
                "pack://application:,,,/Views/Content/Icons/engineering_FILL0_wght400_GRAD0_opsz48.png"),
                new CommandViewModel("Wynagrodzenia",new BaseCommand(showWynagrodzenia), "pack://application:,,,/Views/Content/Icons/payments.png",
                    "pack://application:,,,/Views/Content/Icons/price_check.png"), //to tworzy pierwszy przycisk o nazwie Towary, który pokaże zakładkę wszystkie towary
                new CommandViewModel("Raport sprzedazy",new BaseCommand(showRaportSprzedazy), "pack://application:,,,/Views/Content/Icons/payments.png",
                    "pack://application:,,,/Views/Content/Icons/price_check.png"),
                new CommandViewModel("Najpopularniejszy produkt",new BaseCommand(showNajpopularniejszyProdukt), "pack://application:,,,/Views/Content/Icons/payments.png",
                    "pack://application:,,,/Views/Content/Icons/price_check.png"),
            };
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get 
            {
                if(_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion
        #region Funkcje pomocnicze
        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }

        private void showAddAdres()
        {
            NowyAdresViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyAdresViewModel) as NowyAdresViewModel;
            if (workspace == null)
            {
                workspace = new NowyAdresViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddJednostkaMiary()
        {
            NowaJednostkaMiary workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaJednostkaMiary) as NowaJednostkaMiary;
            if (workspace == null)
            {
                workspace = new NowaJednostkaMiary();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddKategoriaDokuemntu()
        {
            NowaKategoriaDokumentuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaKategoriaDokumentuViewModel) as NowaKategoriaDokumentuViewModel;
            if (workspace == null)
            {
                workspace = new NowaKategoriaDokumentuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddKategoriaKontrahenta()
        {
            NowaKategoriaKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaKategoriaKontrahentaViewModel) as NowaKategoriaKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new NowaKategoriaKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddKategoriaSerwisu()
        {
            NowaKategoriaSerwisuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaKategoriaSerwisuViewModel) as NowaKategoriaSerwisuViewModel;
            if (workspace == null)
            {
                workspace = new NowaKategoriaSerwisuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddKontakt()
        {
            NowyKontaktViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyKontaktViewModel) as NowyKontaktViewModel;
            if (workspace == null)
            {
                workspace = new NowyKontaktViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddKraj()
        {
            NowyKrajViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyKrajViewModel) as NowyKrajViewModel;
            if (workspace == null)
            {
                workspace = new NowyKrajViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddMagazyn()
        {
            NowyMagazynViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyMagazynViewModel) as NowyMagazynViewModel;
            if (workspace == null)
            {
                workspace = new NowyMagazynViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddPozycjaFaktury()
        {
            NowaPozycjaFakutyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaPozycjaFakutyViewModel) as NowaPozycjaFakutyViewModel;
            if (workspace == null)
            {
                workspace = new NowaPozycjaFakutyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddPozycjaPrzyjeciaZewnetrznegoTowaru()
        {
            NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel) as NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel;
            if (workspace == null)
            {
                workspace = new NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddPozycjaWydaniaZewnetrznegoTowaru()
        {
            NowaPozycjaWydaniaZewnetrznegoTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaPozycjaWydaniaZewnetrznegoTowaruViewModel) as NowaPozycjaWydaniaZewnetrznegoTowaruViewModel;
            if (workspace == null)
            {
                workspace = new NowaPozycjaWydaniaZewnetrznegoTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddPracownik()
        {
            NowyPracownikViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyPracownikViewModel) as NowyPracownikViewModel;
            if (workspace == null)
            {
                workspace = new NowyPracownikViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddPrzyjecieZewnetrzne()
        {
            NowePrzyjecieZewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowePrzyjecieZewnetrzneViewModel) as NowePrzyjecieZewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new NowePrzyjecieZewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddRodzajKontrahenta()
        {
            NowyRodzajKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyRodzajKontrahentaViewModel) as NowyRodzajKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new NowyRodzajKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddRodzajVAT()
        {
            NowyRodzajVATViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyRodzajVATViewModel) as NowyRodzajVATViewModel;
            if (workspace == null)
            {
                workspace = new NowyRodzajVATViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddSerwisant()
        {
            NowySerwisantViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowySerwisantViewModel) as NowySerwisantViewModel;
            if (workspace == null)
            {
                workspace = new NowySerwisantViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddSposobPlatnosci()
        {
            NowySposobPlatnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowySposobPlatnosciViewModel) as NowySposobPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new NowySposobPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddTypDokumentu()
        {
            NowyTypDokumentuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyTypDokumentuViewModel) as NowyTypDokumentuViewModel;
            if (workspace == null)
            {
                workspace = new NowyTypDokumentuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddTypKontrahenta()
        {
            NowyTypKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyTypKontrahentaViewModel) as NowyTypKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new NowyTypKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddTypTowaru()
        {
            NowyTypTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowyTypTowaruViewModel) as NowyTypTowaruViewModel;
            if (workspace == null)
            {
                workspace = new NowyTypTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddUrzadzenie()
        {
            NoweUrzadzenieViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NoweUrzadzenieViewModel) as NoweUrzadzenieViewModel;
            if (workspace == null)
            {
                workspace = new NoweUrzadzenieViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAddWydanieZewnetrzne()
        {
            NoweWydanieZewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NoweWydanieZewnetrzneViewModel) as NoweWydanieZewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new NoweWydanieZewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAddZmianaCeny()
        {
            NowaZmianaCenyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NowaZmianaCenyViewModel) as NowaZmianaCenyViewModel;
            if (workspace == null)
            {
                workspace = new NowaZmianaCenyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllSerwisanci()
        {
            WszyscySerwisanciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscySerwisanciViewModel) as WszyscySerwisanciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscySerwisanciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllAdresy()
        {
            WszystkieAdresyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel) as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllDokumenty()
        {
            WszystkieDokumentyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieDokumentyViewModel) as WszystkieDokumentyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieDokumentyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllJednostkiMiary()
        {
            WszystkieJednostkiMiaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieJednostkiMiaryViewModel) as WszystkieJednostkiMiaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieJednostkiMiaryViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKategorieDokumentu()
        {
            WszystkieKategorieDokumentuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKategorieDokumentuViewModel) as WszystkieKategorieDokumentuViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKategorieDokumentuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKategorieKontrahenta()
        {
            WszystkieKategorieKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKategorieKontrahentaViewModel) as WszystkieKategorieKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKategorieKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKategorieSerwisiu()
        {
            WszystkieKategorieSerwisuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKategorieSerwisuViewModel) as WszystkieKategorieSerwisuViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKategorieSerwisuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKontakty()
        {
            WszystkieKontaktyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKontaktyViewModel) as WszystkieKontaktyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKontaktyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllKontrahenci()
        {
            WszyscyKontrahenciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontrahenciViewModel) as WszyscyKontrahenciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontrahenciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllKraje()
        {
            WszystkieKrajeViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKrajeViewModel) as WszystkieKrajeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKrajeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllMagazyny()
        {
            WszystkieMagazynyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieMagazynyViewModel) as WszystkieMagazynyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieMagazynyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllPozycjeFaktury()
        {
            WszystkiePozycjeFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePozycjeFakturyViewModel) as WszystkiePozycjeFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePozycjeFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllPozycjePrzyjeciaZewnetrznegoTowaru()
        {
            WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel) as WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePozycjePrzyjeciaZewnetrznegoTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllPozycjeWydaniaZewnetrznegoTowaru()
        {
            WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel) as WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePozycjeWydaniaZewnetrznegoTowaruViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllPracownicy()
        {
            WszyscyPracownicyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel) as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllPrzyjeciaZewnetrzne()
        {
            WszystkiePrzyjeciaZewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePrzyjeciaZewnetrzneViewModel) as WszystkiePrzyjeciaZewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePrzyjeciaZewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllRodzajeKontrahenta()
        {
            WszystkieRodzajeKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeKontrahentaViewModel) as WszystkieRodzajeKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllSposobyPlatnosci()
        {
            WszystkieSposobyPlatnosciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyPlatnosciViewModel) as WszystkieSposobyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllTowary()
        {
            WszystkieTowaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTowaryViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllTypyDokumentow()
        {
            WszystkieTypyDokumentowViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyDokumentowViewModel) as WszystkieTypyDokumentowViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyDokumentowViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllTypyKontrahentow()
        {
            WszystkieTypyKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyKontrahentaViewModel) as WszystkieTypyKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllTypyTowarow()
        {
            WszystkieTypyTowarowViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTypyTowarowViewModel) as WszystkieTypyTowarowViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieTypyTowarowViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllUrzadzenia()
        {
            WszystkieUrzadzeniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieUrzadzeniaViewModel) as WszystkieUrzadzeniaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUrzadzeniaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllWydaniaZewnetrzne()
        {
            WszystkieWydaniaZewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieWydaniaZewnetrzneViewModel) as WszystkieWydaniaZewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieWydaniaZewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllZleceniaSerwisowe()
        {
            WszystkieZleceniaSerwisoweViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieZleceniaSerwisoweViewModel) as WszystkieZleceniaSerwisoweViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieZleceniaSerwisoweViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllZmianyCeny()
        {
            WszystkieZmianyCenyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieZmianyCenyViewModel) as WszystkieZmianyCenyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieZmianyCenyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllRodzajeVAT()
        {
            WszystkieRodzajeVATViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeVATViewModel) as WszystkieRodzajeVATViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeVATViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showKontrahenciKontakt()
        {
            KontrahenciKontaktViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is KontrahenciKontaktViewModel) as KontrahenciKontaktViewModel;
            if (workspace == null)
            {
                workspace = new KontrahenciKontaktViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showRaportSprzedazy()
        {
            RaportSprzedazyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is RaportSprzedazyViewModel) as RaportSprzedazyViewModel;
            if (workspace == null)
            {
                workspace = new RaportSprzedazyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showNajpopularniejszyProdukt()
        {
            NajpopularniejszyProduktViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NajpopularniejszyProduktViewModel) as NajpopularniejszyProduktViewModel;
            if (workspace == null)
            {
                workspace = new NajpopularniejszyProduktViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showNajpopularniejszyProduktWKraju()
        {
            NajpopularniejszyProduktWKrajuViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is NajpopularniejszyProduktWKrajuViewModel) as NajpopularniejszyProduktWKrajuViewModel;
            if (workspace == null)
            {
                workspace = new NajpopularniejszyProduktWKrajuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        //to jest funkcja, która otwiera nową zakładke Towar
        //za każdym tworzy nową NOWĄ zakładkę do dodawania towaru
        //private void createTowar()
        //{
        //    //tworzy zakładke NowyTowar (VM)
        //    NowyTowarViewModel workspace=new NowyTowarViewModel();
        //    //dodajmy ją do kolkcji aktywnych zakładek
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}
        //to jest funkcja, która otwiera zakładke ze wszystkimi towarami
        //za każdym razem sprawdza czy zakladka z towarami jest juz otwarta, jak jest to ja aktywuje, ajk nie ma to tworzy 
        private void showWynagrodzenia()
        {
            //sz....
            WynagrodzeniaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WynagrodzeniaViewModel) as WynagrodzeniaViewModel;
            //jezeli ....
            if(workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace=new WynagrodzeniaViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        private void open(string name)
        {
            if (name == "Wszyscy kontrahenciAdd")
            {
                createView(new NowyKontrahentViewModel());
            }
            if (name == "Wszyscy pracownicyAdd")
            {
                createView(new NowyPracownikViewModel());
            }
            if (name == "Wszyscy serwisanciAdd")
            {
                createView(new NowySerwisantViewModel());
            }
            if (name == "Wszystkie adresyAdd")
            {
                createView(new NowyAdresViewModel());
            }
            if (name == "Wszystkie dokumentyAdd")
            {
                createView(new NowaFakturaViewModel());
            }
            if (name == "Wszystkie jednostki miaryAdd")
            {
                createView(new NowaJednostkaMiary());
            }
            if (name == "Wszystkie kategorie dokumnetuAdd")
            {
                createView(new NowaKategoriaDokumentuViewModel());
            }
            if (name == "Wszystkie kategorie kontrahentaAdd")
            {
                createView(new NowaFakturaViewModel());
            }
            if (name == "Wszystkie kategorie serwisuAdd")
            {
                createView(new NowaKategoriaSerwisuViewModel());
            }
            if (name == "Wszystkie kontaktyAdd")
            {
                createView(new NowyKontaktViewModel());
            }
            if (name == "Wszystkie krajeAdd")
            {
                createView(new NowyKrajViewModel());
            }
            if (name == "Wszystkie magazynyAdd")
            {
                createView(new NowyMagazynViewModel());
            }
            if (name == "Wszystkie pozycje fakturyAdd")
            {
                createView(new NowaPozycjaFakutyViewModel());
            }
            if (name == "Wszystkie pozycje przyjecia zewnetrznego towaruAdd")
            {
                createView(new NowaPozycjaPrzyjeciaZewnetrznegoTowaruViewModel());
            }
            if (name == "Wszystkie pozycje wydania zewnetrznego towaruAdd")
            {
                createView(new NowaPozycjaWydaniaZewnetrznegoTowaruViewModel());
            }
            if (name == "Wszystkie przyjecia zewnetrzneAdd")
            {
                createView(new NowePrzyjecieZewnetrzneViewModel());
            }
            if (name == "Wszystkie rodzaje kontrahentaAdd")
            {
                createView(new NowyRodzajKontrahentaViewModel());
            }
            if (name == "Wszystkie sposoby platnosciAdd")
            {
                createView(new NowySposobPlatnosciViewModel());
            }
            if (name == "Wszystkie towaryAdd")
            {
                createView(new NowyTowarViewModel());
            }
            if (name == "Wszystkie typy dokumentowAdd")
            {
                createView(new NowyTypDokumentuViewModel());
            }
            if (name == "Wszystkie typy kontrahentaAdd")
            {
                createView(new NowyTypKontrahentaViewModel());
            }
            if (name == "Wszystkie typy towarowAdd")
            {
                createView(new NowyTypTowaruViewModel());
            }
            if (name == "Wszystkie urzadzeniaAdd")
            {
                createView(new NoweUrzadzenieViewModel());
            }
            if (name == "Wszystkie wydania zewnetrzneAdd")
            {
                createView(new NoweWydanieZewnetrzneViewModel());
            }
            if (name == "Wszystkie zlecenia serwisoweAdd")
            {
                createView(new ZlecenieSerwisoweViewModel());
            }
            if (name == "Wszystkie zmiany cenyAdd")
            {
                createView(new NowaZmianaCenyViewModel());
            }
            if (name == "Wszystkie rodzaje VATAdd")
            {
                createView(new NowyRodzajVATViewModel());
            }
            //to jest potrzebne do trzech kropek
            if (name == "KontrahenciAll")
            {
                createView(new WszyscyKontrahenciViewModel(true));
            }
            if (name == "AdresyAll")
            {
                createView(new WszystkieAdresyViewModel(true));
            }
            if (name == "KontaktyAll")
            {
                createView(new WszystkieKontaktyViewModel(true));
            }
            if (name == "DokumentyAll")
            {
                createView(new WszystkieDokumentyViewModel(true));
            }
            if (name == "TowarAll")
            {
                createView(new WszystkieTowaryViewModel(true));
            }
            if (name == "SerwisantAll")
            {
                createView(new WszyscySerwisanciViewModel(true));
            }

        }
        #endregion
    }
}
