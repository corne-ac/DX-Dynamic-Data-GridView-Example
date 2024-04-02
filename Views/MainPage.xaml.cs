



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
            form.populate();

            foreach (var recordList in form.RowList[0].ColumnList[0].RecordList)
            {
                foreach (var item in recordList.FieldList)
                {
                    if (datagrid.Columns.FirstOrDefault(c => c.FieldName == item.FieldLabel) == null)
                    {
                        datagrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel });
                    }
                }
            }
            
            datagrid.ItemsSource = form.RowList[0].ColumnList[0].datatablesetter();
        }
    }
}