



using DX_test_app.ViewModels;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        async void OnOpenWebButtonClicked(System.Object sender, System.EventArgs e)
        {
            await Browser.OpenAsync("https://www.devexpress.com/maui/");
        }
    }
}