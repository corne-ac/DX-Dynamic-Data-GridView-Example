



using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using DX_test_app.ViewModels;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {

        public List<DataGridView> gridList = new(); //TODO: Itterate through grid list to add multiple grids to UI

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            setupGrids(vm);
           // addGridsToView();
        }

       

        void setupGrids(MainPageViewModel vm)
        {
            //Set up columns, itterate through fieldLists and use fieldName as column name
            //Goes through all records to ensure all columns are added
            //This part helps if wanting to customise each column
            foreach (var recordList in vm.Form.RowList[0].ColumnList[0].RecordList)
            {
                foreach (var field in recordList.FieldList)
                {
                    if (datagrid.Columns.FirstOrDefault(c => c.FieldName == field.FieldLabel) == null)
                    {
                        //Calculate width of column based on length of data and ColumnName
                        int width = field.Value.ToString().Length * 13;
                        int titleWidth = field.FieldLabel.ToString().Length * 13;
                        width = width < 100 ? 100 : width;
                        width = titleWidth > width ? titleWidth : width;

                        //Check data type and set column type accordingly
                        if (field.Value.GetType() == typeof(int))
                            datagrid.Columns.Add(new NumberColumn() { FieldName = field.FieldLabel, Caption = field.FieldLabel, MinWidth = width });
                        else if (field.Value.GetType() == typeof(DateTime))
                            datagrid.Columns.Add(new DateColumn() { FieldName = field.FieldLabel, Caption = field.FieldLabel, MinWidth = width });
                        else if (field.Value.GetType() == typeof(bool))
                            datagrid.Columns.Add(new CheckBoxColumn() { FieldName = field.FieldLabel, Caption = field.FieldLabel, MinWidth = width });
                        else
                            datagrid.Columns.Add(new TextColumn() { FieldName = field.FieldLabel, Caption = field.FieldLabel, MinWidth = width });
                    }//If
                }//foreach
            }//foreach

            datagrid.ItemsSource = vm.Table;
        }
    }
}