using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FACTURE.DB;
using FACTURE.Models;
using FACTURE.Views;
using Xamarin.Forms;

namespace FACTURE.ViewModels
{
    public class ListeFacturesPageViewModel :BaseViewModel
    {
        private FactureViewModel _selectedFacture;
        private IFactureStore _factureStore;
        private IPageService _pageService;
        private bool _isDataLoaded;
        public ObservableCollection<FactureViewModel> ListeFactures { get; private set; }
           = new ObservableCollection<FactureViewModel>();

        public FactureViewModel SelectedFacture
        {
            get { return _selectedFacture; }
            set { SetValue(ref _selectedFacture, value); }
        }
        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddFactureCommand { get; private set; }
        public ICommand SelectFactureCommand { get; private set; }
        public ICommand DeleteFactureCommand { get; private set; }
       

        public ListeFacturesPageViewModel(IFactureStore factureStore, IPageService pageService)
        {
            _factureStore = factureStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddFactureCommand = new Command(async () => await AddFacture());
            SelectFactureCommand = new Command<FactureViewModel>(async p => await SelectFacture(p));
            DeleteFactureCommand = new Command<FactureViewModel> (async p => await DeleteFacture(p));

            MessagingCenter.Subscribe<FactureDetailViewModel, Facture>
                (this, Events.FactureAdded, OnFactureAdded);

            MessagingCenter.Subscribe<FactureDetailViewModel, Facture>
            (this, Events.FactureUpdated, OnFactureUpdated);
        }

        private void OnFactureAdded(FactureDetailViewModel source, Facture facture)
        {
            ListeFactures.Add(new FactureViewModel(facture));
        }

        private void OnFactureUpdated(FactureDetailViewModel source, Facture facture)
        {
            var factureInList = ListeFactures.Single(c => c.Id_Facture == facture.Id_Facture);

            factureInList.Id_Facture = facture.Id_Facture;
            factureInList.Montant_Facture = facture.Montant_Facture;
            factureInList.type_paiement = facture.type_paiement;

        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var listeFactures = await _factureStore.GetFacturesAsync();
            foreach (var facture in listeFactures)
                ListeFactures.Add(new FactureViewModel(facture));
        }

        private async Task AddFacture()
        {
            await _pageService.PushAsync(new FactureDetailPage(new FactureViewModel()));
        }


        private async Task SelectFacture(FactureViewModel facture)
        {
            if (facture == null)
                return;

            SelectedFacture = null;
            await _pageService.PushAsync(new FactureDetailPage(facture));
        }

        private async Task DeleteFacture(FactureViewModel factureViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {factureViewModel.Montant_Facture}?", "Yes", "No"))
            {
                ListeFactures.Remove(factureViewModel);

                var facture = await _factureStore.GetFacture(factureViewModel.Id_Facture);
                await _factureStore.DeleteFacture(facture);
            }
        }

       

       

      

     
    }
}
