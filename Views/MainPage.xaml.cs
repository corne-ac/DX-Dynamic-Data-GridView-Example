



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
            setup();
        }

        public Form form = new Form();

        void setup()
        {
            foreach (var item in form.RowList[0].ColumnList[0].RecordList[0].FieldList)
            {
                datagrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel });
            }

            datagrid.ItemsSource = form.RowList[0].ColumnList[0].datatablesetter();
            
        }
    }
}