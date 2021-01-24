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
    public partial class ListeFacturesPage : ContentPage
    {
        public ListeFacturesPage()
        {
            InitializeComponent();
            var factureStore = new SQLiteFacturStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new ListeFacturesPageViewModel(factureStore, pageService);
           
        }
        public ListeFacturesPageViewModel ViewModel
        {
            get { return BindingContext as ListeFacturesPageViewModel; }
            set { BindingContext = value; }
        }
        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        void OnFactureSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectFactureCommand.Execute(e.SelectedItem);
        }

    }
}