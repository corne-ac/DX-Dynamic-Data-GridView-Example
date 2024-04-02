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

            //Set Ui datagrid to the getdatagrid method result

           

           // var data = form.RowList[0].ColumnList[0].GetFlattenedData();
        }

        DataGridView GetDataGrid()
        {
            //Set columsn by itterating through first fieldList and using fieldName as column name
            var dataGrid = new DataGridView();
            foreach (var item in form.RowList[0].ColumnList[0].RecordList[0].FieldList)
            {
                dataGrid.Columns.Add(new TextColumn() { FieldName = item.FieldLabel, Caption = item.FieldLabel });
            }
           
            return dataGrid;
        }

    }
}
