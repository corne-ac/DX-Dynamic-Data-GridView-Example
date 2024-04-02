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

        [ObservableProperty]
        ObservableCollection<flattenedEntry> entries;

        [ObservableProperty]
        ObservableCollection<String[,]> data;

        public Form form = new Form();
        
        public MainPageViewModel()
        {         
            var dynamicModel = new DynamicModel();
            entries = dynamicModel.GetFlattenedCollection();
            
        }

        //This doesnt seem to work, returns empty or missing values to successfully display in datagrid
        public DataGridView GetDataGrid()
        {
            //Set columsn by itterating through first fieldList and using fieldName as column name
            var dataGrid = new DataGridView();
            form.populate();

            foreach (var recordList in form.RowList[0].ColumnList[0].RecordList)
            {
                foreach (var item in recordList.FieldList)
                {
                    if (dataGrid.Columns.FirstOrDefault(c => c.FieldName == item.FieldLabel) == null)
                    {
                        dataGrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel });
                    }
                }
            }

            dataGrid.ItemsSource = form.RowList[0].ColumnList[0].datatablesetter();

            return dataGrid;
        }

    }
}
