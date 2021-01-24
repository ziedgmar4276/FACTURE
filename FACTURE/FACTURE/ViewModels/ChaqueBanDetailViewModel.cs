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
   public  class ChaqueBanDetailViewModel
    {
        private readonly IChaqueBanStore _ChaqueBanStore;
        private readonly IPageService _pageService;
        public ChaqueBan chaqueBan { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ChaqueBanDetailViewModel(ChaqueBanViewModel viewModel, IChaqueBanStore chaqueBanStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _ChaqueBanStore = chaqueBanStore;
            SaveCommand = new Command(async () => await Save());
            chaqueBan = new ChaqueBan
            {
                Id_Ban = viewModel.Id_Ban,
                Nom_Ban = viewModel.Nom_Ban,
                Date_Ban = viewModel.Date_Ban,
               
            };
        }
        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(chaqueBan.Nom_Ban))
            {
                await _pageService.DisplayAlert("Error", "Please enter the name and  date.", "OK");
                return; 
            }
            if (chaqueBan.Id_Ban == 0)
            {
                await _ChaqueBanStore.AddChaqueBan(chaqueBan);
                MessagingCenter.Send(this, Events.ChaqueBanAdded, chaqueBan);
            }
            else
            {
                await _ChaqueBanStore.UpdateChaqueBan(chaqueBan);
                MessagingCenter.Send(this, Events.ChaqueBanUpdated, chaqueBan);
            }
            await _pageService.PopAsync();
        }
    }
}
