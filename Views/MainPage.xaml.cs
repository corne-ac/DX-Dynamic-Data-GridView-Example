



using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using DX_test_app.ViewModels;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm; 
            setup(vm);
        }

        

        void setup(MainPageViewModel vm)
        {
            datagrid = vm.GetDataGrid(datagrid);
            
        }
    }
}