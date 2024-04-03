namespace DX_test_app.Views;
using DX_test_app.ViewModels;
using System.ComponentModel;
using DX_test_app.Models;
using System.Collections.ObjectModel;
using DevExpress.Maui.DataGrid;
using static DevExpress.Maui.Core.Internal.IDataGrid;

public partial class MarcoPage : ContentPage
{
    //Code-Behind Grid Generation:
    //In MarcoPage.xaml.cs, we dynamically created and configured each DataGridView instance.
    //For each DataGridViewModel in the ViewModel, we generated a DataGridView and added columns
    //based on the dynamic rows' dictionary keys.
    public MarcoPage()
    {
        InitializeComponent();
        var viewModel = new MarcoPageViewModel();
        this.BindingContext = viewModel;

        // Dynamically create and add columns after the viewModel is populated
        // Assuming that each DataGridView represents a Column, iterate and create grids.
        foreach (var gridModel in viewModel.DataGridModels)
        {
            var dataGrid = CreateDataGrid(gridModel);
            // Add the grid to a StackLayout or other container
            dataGridStackLayout.Children.Add(dataGrid); // Ensure you have a StackLayout named 'dataGridStackLayout' in your XAML
        }
    }

    private DevExpress.Maui.DataGrid.DataGridView CreateDataGrid(DataGridViewModel gridModel)
    {
        var dataGrid = new DevExpress.Maui.DataGrid.DataGridView();

        // Assume that the first item's keys represent the column headers for all items
        var firstRow = gridModel.Rows.FirstOrDefault() as IDictionary<string, Object>;
        if (firstRow != null)
        {
            foreach (var key in firstRow.Keys)
            {
                var column = new DevExpress.Maui.DataGrid.TextColumn
                {
                    FieldName = key, // This should match the dictionary keys
                    Caption = key
                };
                dataGrid.Columns.Add(column);
            }
        }

        dataGrid.ItemsSource = gridModel.Rows;
        return dataGrid;
    }
}