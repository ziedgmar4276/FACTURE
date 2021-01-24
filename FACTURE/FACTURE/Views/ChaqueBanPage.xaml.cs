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
    public partial class ChaqueBanPage : ContentPage
    {  
        public ChaqueBanPage(ChaqueBanViewModel viewModel)
        {
            InitializeComponent();
            var chaqueBanStore = new SQLiteChaqueBanStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Nom_Ban == null) ? "New Chaque Banque" : "Edit Chaque Banque";
            BindingContext = new ChaqueBanDetailViewModel(viewModel ?? new ChaqueBanViewModel(), chaqueBanStore, pageService);
        }
        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

           // if (selectedIndex != -1)
           // {
           //     monkeyNameLabel.Text = picker.Items[selectedIndex];
           // }
        }
    }
  
}