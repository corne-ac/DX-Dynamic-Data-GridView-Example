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

        public MainPageViewModel()
        {         
            var dynamicModel = new DynamicModel();
            entries = dynamicModel.GetFlattenedCollection();
        }

        DataGridView setUpGrid()
        {
            DataGridView grid = new DataGridView();
           // grid.Columns.Add();

            return new DataGridView();
        }

    }
}
