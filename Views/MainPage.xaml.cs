



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
            //datagrid = vm.GetDataGrid();
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
                        //Calculate width of column based on length of data and ColumnName
                        int width = item.Value.ToString().Length * 13;
                        int titleWidth = item.FieldLabel.ToString().Length * 13;
                        width = width < 100 ? 100 : width;
                        width = titleWidth > width ? titleWidth : width;

                        //Check data type and set column type accordingly
                        if (item.Value.GetType() == typeof(int))
                            datagrid.Columns.Add(new NumberColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel, MinWidth = width });
                        else if (item.Value.GetType() == typeof(string))
                            datagrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel, MinWidth = width });
                        else if (item.Value.GetType() == typeof(DateTime))
                            datagrid.Columns.Add(new DateColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel, MinWidth = width });
                        else if (item.Value.GetType() == typeof(bool))
                            datagrid.Columns.Add(new CheckBoxColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel, MinWidth = width });
                        else
                            datagrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel, MinWidth = width });

                    }
                }
            }

            datagrid.ItemsSource = form.RowList[0].ColumnList[0].datatablesetter();
        }
    }
}