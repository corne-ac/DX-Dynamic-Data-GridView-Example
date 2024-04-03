using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {

        [ObservableProperty] public Form form = new Form();

        public MainPageViewModel()
        {         
            Form.populate();
        }

        //Creates a DataTable that will be used as a source for the DataGrid
        //Takes the Column as a parameter for which it will create the DataTable
        public DataTable getTable(Column col)
        {
            DataTable table = new DataTable();

            // Add columns to the DataTable using the FieldLabel of the first field in the RecordList
            foreach (var record in col.RecordList)
            {
                foreach (var field in record.FieldList)
                {
                    if (!table.Columns.Contains(field.FieldLabel)) //Only add if not already added
                        table.Columns.Add(field.FieldLabel, field.Value.GetType());
                }
            }

            // Add rows to the DataTable using the FieldLabel as the column name and the Value as the row data
            foreach (var record in col.RecordList)
            {
                DataRow row = table.NewRow();

                foreach (var field in record.FieldList)
                    row[field.FieldLabel] = field.Value;
                
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
