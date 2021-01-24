using FACTURE.DB;
using FACTURE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FACTURE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactureDetailPage : ContentPage
    {
        public FactureDetailPage(FactureViewModel viewModel)
        {
            InitializeComponent();
            var factureStore = new SQLiteFacturStore(DependencyService.Get<ISQLiteDb>());
           var pageService = new PageService();
            Title = (viewModel.type_paiement == null) ? "New Facture" : "Edit Facture";
          // BindingContext = new FactureDetailViewModel(viewModel ?? new FactureViewModel(), factureStore, pageService);


        }
    }
}