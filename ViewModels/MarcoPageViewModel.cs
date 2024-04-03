using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Maui.Core.Internal;
using DX_test_app.Models;
using DX_test_app.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;

namespace DX_test_app.ViewModels
{
    //ViewModel Creation:
    //In MarcoPageViewModel,
    //we constructed an ObservableCollection<DataGridViewModel>
    //to hold a collection of data grid models.Each DataGridViewModel
    //was intended to represent a dynamic grid in the UI.
    public class MarcoPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DataGridViewModel> DataGridModels { get; set; }

        public MarcoPageViewModel()
        {
            DataGridModels = new ObservableCollection<DataGridViewModel>();
            Form form = new Form();

            foreach (var row in form.RowList)
            {
                foreach (var column in row.ColumnList)
                {
                    // Instantiate DataGridViewModel by passing the column object to the constructor.
                    var dataGridModel = new DataGridViewModel(column);

                    // The Rows will be populated within the DataGridViewModel constructor.
                    DataGridModels.Add(dataGridModel);
                }
            }
        }

        //Dynamic Binding Workaround:
       //Because DevExpress DataGrid did not support direct dictionary binding,
       //we implemented a workaround by using ExpandoObject, a dynamic type that allows for runtime binding.
       //This enabled us to bind dictionary keys as properties, which the DataGrid could understand and display.
        private object ConvertDictionaryToDynamic(Dictionary<string, object> dictionary)
    {
        var expandoObj = new ExpandoObject() as IDictionary<string, Object>;
        foreach (var keyValuePair in dictionary)
        {
            expandoObj.Add(keyValuePair.Key, keyValuePair.Value);
        }
        return expandoObj;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }


}

