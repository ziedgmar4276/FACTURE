using FACTURE.DB;
using FACTURE.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FACTURE.ViewModels
{
    public class FactureDetailViewModel
    {

        private readonly IFactureStore _factureStore;
        private readonly IPageService _pageService;
        public Facture facture { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public FactureDetailViewModel(FactureViewModel viewModel, IFactureStore factureStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _factureStore = factureStore;
            SaveCommand = new Command(async () => await Save());
            facture = new Facture
            {
                Id_Facture = viewModel.Id_Facture,
                Montant_Facture = viewModel.Montant_Facture,
                type_paiement =viewModel.type_paiement,

            };
        }
        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(facture.type_paiement))
            {
                await _pageService.DisplayAlert("Error", "Please enter the montant and type paiement.", "OK");
                return;
            }
            if (facture.Id_Facture == 0)
            {
                await _factureStore.AddFacture(facture);
                MessagingCenter.Send(this, Events.FactureAdded, facture);
            }
            else
            {
                await _factureStore.UpdateFacture(facture);
                MessagingCenter.Send(this, Events.FactureUpdated, facture);
            }
            await _pageService.PopAsync();
        }


    }
}
