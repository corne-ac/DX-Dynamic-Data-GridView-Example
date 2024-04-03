



using DX_test_app.ViewModels;
using DX_test_app.Views;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        //Navigate to Marco Page
        private async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MarcoPage));
        }
    }
}