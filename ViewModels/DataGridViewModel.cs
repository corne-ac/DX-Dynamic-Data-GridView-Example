using DX_test_app.Models;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static DevExpress.Maui.Core.Internal.IDataGrid;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DX_test_app.ViewModels
{
    //Dynamic Row Conversion:
    //We introduced the DataGridViewModel class to transform each Column's Record into dynamic rows.
    // The conversion involved creating a dictionary for each Record that mapped field labels to values,
    // which would serve as our dynamic columns and rows in the grid.


    //Dynamic DataGrid Creation and Binding:
    //For each DataGridViewModel in our ViewModel, we created a corresponding DataGridView in the UI.
    //We programmatically added columns to each grid by iterating over the keys of the first dynamic row object,
    //setting up the FieldName property to match the dynamic object's properties. The ItemsSource was bound to the
    //collection of dynamic rows, ensuring that each grid would display its unique set of data.

    public class DataGridViewModel
    {
        public string ColumnName { get; set; }
        public ObservableCollection<object> Rows { get; set; }

        public DataGridViewModel(Column column)
        {
            ColumnName = column.ColumnName;
            Rows = new ObservableCollection<object>();

            // Here you're converting each Record in the column into a dynamic row.
            foreach (var record in column.RecordList)
            {
                var row = new ExpandoObject() as IDictionary<string, object>;
                foreach (var field in record.FieldList)
                {
                    row.Add(field.FieldLabel, field.Value);
                }
                Rows.Add(row);
            }
        }
    }
}
