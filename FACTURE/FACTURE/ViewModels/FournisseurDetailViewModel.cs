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
    public class FournisseurDetailViewModel
    {
        private readonly IFournisseurStore _FournisseurStore;
        private readonly IPageService _pageService;
        public Fournisseur fournisseur { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public FournisseurDetailViewModel(FournisseurViewModel viewModel, IFournisseurStore fournisseurStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _FournisseurStore = fournisseurStore;
            SaveCommand = new Command(async () => await Save());
            fournisseur = new Fournisseur
            {
                Id_Fournisseur = viewModel.Id_Fournisseur,
                Nom_Fournisseur = viewModel.Nom_Fournisseur,
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(fournisseur.Nom_Fournisseur))
            {
                await _pageService.DisplayAlert("Error", "Please enter the nom .", "OK");
                return;
            }
            if (fournisseur.Id_Fournisseur == 0)
            {
                await _FournisseurStore.AddFournisseur(fournisseur);
                MessagingCenter.Send(this, Events.FournisseurAdded, fournisseur);
            }
            else
            {
                await _FournisseurStore.UpdateFournisseur(fournisseur);
                MessagingCenter.Send(this, Events.FournisseurUpdated, fournisseur);

                await _pageService.PopAsync();
            }
        }
    }
}

