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
        [ObservableProperty] public List<DataGridView> gridList = new();

        public MainPageViewModel()
        {         
            Form.populate();
        }

        [RelayCommand]
        void checkData()
        {
            foreach (var field in Form.RowList.SelectMany(row => row.ColumnList.SelectMany(column => column.RecordList.SelectMany(record => record.FieldList))))
                Console.WriteLine($"{field.FieldLabel} : {field.Value}");
        }
        [RelayCommand]
        void updatedata()
        {
            Form.RowList[0].ColumnList[0].RecordList[0].FieldList[0].Value = "Updated";
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

            // Handle the RowChanged event to update the original Form object
            table.RowChanged += (sender, e) =>
            {
                DataRow row = e.Row;
                foreach (var field in col.RecordList.SelectMany(record => record.FieldList))
                {
                    if (table.Columns.Contains(field.FieldLabel))
                    {
                        field.Value = row[field.FieldLabel];
                    }
                }
            };

            table.TableNewRow += (sender, e) =>
            {
                DataRow row = e.Row;
                Record record = new Record();
                foreach (DataColumn column in table.Columns)
                {
                    Field field = new Field { FieldLabel = column.ColumnName, Value = row[column] };
                    record.FieldList.Add(field);
                }
                col.RecordList.Add(record);
            };

            return table;
        }
    }
}
