using Android.Graphics;
using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using DX_test_app.ViewModels;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {
        // List used to store each gridview created
        public List<DataGridView> gridList = new();

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            setupGrids(vm);
            addGridsToView();
        }

        // Set up columns, iterate through fieldLists and use fieldName as column name
        // Goes through all records to ensure all columns are added
        // Functions without this and only using the DataTable, but this enables the use of custom column types
        void setupGrids(MainPageViewModel vm)
        {
            // Iterate through columns
            foreach (var col in vm.Form.RowList[0].ColumnList)
            {
                // Create new grid with default properties
                DataGridView grid = new()
                {
                    ReduceHeightToContent = true,
                    Margin = new Thickness(0, 0, 0, 20),
                    BorderThickness = new Thickness(2),
                    EditorShowMode = EditorShowMode.DoubleTap,
                    AllowDragDropRows = true,
                };

                // Iterate through records and fields to add relevant column types to grid
                // Goes through all records in case some fields are not present in all records (ex. fields added later)
                foreach (var recordList in col.RecordList)
                {
                    // Iterate through fields
                    foreach (var field in recordList.FieldList)
                    {
                        // Check if column hasn't been added yet
                        if (grid.Columns.FirstOrDefault(c => c.FieldName == field.FieldLabel) == null)
                        {
                            // Calculate width of column based on length of data and ColumnName
                            int width = field.Value.ToString().Length * 13;
                            int titleWidth = field.FieldLabel.ToString().Length * 13;
                            width = width < 100 ? 100 : width;
                            width = titleWidth > width ? titleWidth : width;
                            int headerSize = 17;
                            Microsoft.Maui.Graphics.Color headerColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255);

                            // Check data type and set column type accordingly
                            if (field.Value.GetType() == typeof(int))
                                grid.Columns.Add(new NumberColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    HeaderFontSize = headerSize,
                                    HeaderBackgroundColor = headerColor,
                                    HeaderFontAttributes = FontAttributes.Bold
                                });
                            else if (field.Value.GetType() == typeof(DateTime))
                                grid.Columns.Add(new DateColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    HeaderFontSize = headerSize,
                                    HeaderBackgroundColor = headerColor,
                                    HeaderFontAttributes = FontAttributes.Bold
                                });
                            else if (field.Value.GetType() == typeof(bool))
                                grid.Columns.Add(new CheckBoxColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    HeaderFontSize = headerSize,
                                    HeaderBackgroundColor = headerColor,
                                    HeaderFontAttributes = FontAttributes.Bold
                                });
                            else if (field.Value.GetType() == typeof(decimal) || //All number types
                                     field.Value.GetType() == typeof(long) ||
                                     field.Value.GetType() == typeof(int) ||
                                     field.Value.GetType() == typeof(short) |
                                     field.Value.GetType() == typeof(float) ||
                                     field.Value.GetType() == typeof(double))
                                grid.Columns.Add(new NumberColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    HeaderFontSize = headerSize,
                                    HeaderBackgroundColor = headerColor,
                                    HeaderFontAttributes = FontAttributes.Bold
                                });
                            else
                                grid.Columns.Add(new TextColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    HeaderFontSize = headerSize,
                                    HeaderBackgroundColor = headerColor,
                                    HeaderFontAttributes = FontAttributes.Bold
                                });
                        } // if
                    } // foreach field
                } // foreach record

                // Set Source
                grid.ItemsSource = vm.getTable(col);
                gridList.Add(grid);
            } // foreach column 
        }

        private void addGridsToView()
        {
            // Iterate through gridList and add each grid to the stack layout
            foreach (var grid in gridList)
                stack.Children.Add(grid);
            
        }

    } // Class
}