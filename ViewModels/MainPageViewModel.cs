using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {

        [ObservableProperty] public Form form = new Form();
        [ObservableProperty] public List<DataGridView> lstDatagrid = new List<DataGridView>();
        
        public MainPageViewModel()
        {         
            form.populate();
        }

        //This doesnt seem to work, returns empty or missing values to successfully display in datagrid
        public DataGridView GetDataGrid(DataGridView datagrid)
        {
            
            //Set up columns, itterate through fieldLists and use fieldName as column name
            //Goes through all records to ensure all columns are added
            //This part helps if wanting to customise each column
            foreach (var recordList in Form.RowList[0].ColumnList[0].RecordList)
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
                    }
                }


            }

            //Set Data
            datagrid.ItemsSource = Form.RowList[0].ColumnList[0].datatablesetter();
             //Maybe have an observable lsit of the datagrids inside the VM, that is then used on the View side to loop through and add each grid to the UI
            return datagrid;
        }

        //WIP
        public DataGridView GetDataGridDynamic()
        {
            DataGridView dataGrid = new DataGridView();
            //Set up columns, itterate through fieldLists and use fieldName as column name
            //Goes through all records to ensure all columns are added
            //This part helps if wanting to customise each column
            foreach (var recordList in Form.RowList[0].ColumnList[0].RecordList)
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
                    }
                }


            }

            //Set Data
            datagrid.ItemsSource = Form.RowList[0].ColumnList[0].datatablesetter();
            //Maybe have an observable lsit of the datagrids inside the VM, that is then used on the View side to loop through and add each grid to the UI
            return datagrid;
        }

    }
}
