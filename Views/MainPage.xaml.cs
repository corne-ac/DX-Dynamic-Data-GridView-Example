using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using DX_test_app.ViewModels;

namespace DX_test_app
{
    public partial class MainPage : ContentPage
    {
        // List used to store each gridview created
        
        public List<Label> labels = new();

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            setupGrids(vm);
            addGridsToView(vm);
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
                    AutoGenerateColumnsMode = AutoGenerateColumnsMode.Auto,
                };

                //Add label with column name
                Label label = new()
                {
                    Text = col.ColumnName,
                    FontSize = 20,
                    FontAttributes = FontAttributes.Bold,
                    Margin = new Thickness(0, 5, 0, 10),
                };
                labels.Add(label);

                // Iterate through records and fields to add relevant column types to grid
                // Goes through all records in case some fields are not present in all records (ex. fields added later)
                // Iterate through fields to add relevant column types to grid
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


                            // Check data type and set column type accordingly
                            if (field.Value.GetType() == typeof(int))
                            {
                                grid.Columns.Add(new NumberColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                });
                            }
                            else if (field.Value.GetType() == typeof(DateTime))
                            {
                                grid.Columns.Add(new DateColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                });
                            }
                            else if (field.Value.GetType() == typeof(bool))
                            {
                                grid.Columns.Add(new CheckBoxColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                });
                            }
                            else if (field.Value.GetType() == typeof(decimal) || //All number types
                                     field.Value.GetType() == typeof(long) ||
                                     field.Value.GetType() == typeof(int) ||
                                     field.Value.GetType() == typeof(short) |
                                     field.Value.GetType() == typeof(float) ||
                                     field.Value.GetType() == typeof(double))
                            {
                                grid.Columns.Add(new NumberColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    BindingContext = col.RecordList[0],
                                });
                            }
                            else
                            {
                                grid.Columns.Add(new TextColumn()
                                {
                                    FieldName = field.FieldLabel,
                                    Caption = field.FieldLabel,
                                    MinWidth = width,
                                    BindingContext = col.RecordList[0].FieldList[0],

                                });
                            }
                        }
                    }
                }

                // Set Source
                //grid.ItemsSource = vm.getTable(col);
                grid.ItemsSource = col.RecordList;
                vm.GridList.Add(grid);
            } // foreach column 
        }

        private void addGridsToView(MainPageViewModel vm)
        {
            int c = 0;
            // Iterate through gridList and add each grid to the stack layout
            foreach (var grid in vm.GridList)
            {
                int i = 0;
                //Apply additional formatting to headers
                grid.Columns.ForEach(c =>
                {
                    c.HeaderFontSize = 17;
                    c.HeaderBackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255);
                    c.HeaderFontAttributes = FontAttributes.Bold;
                    //c.SetBinding(TitleProperty, "FieldList.Field.FieldLabel");
                    //c.SetBinding(ContentProperty, new Binding("Value"));
                    //c.SetBinding(TitleProperty, new Binding("FieldName"));
                    //c.SetBinding(GridColumn.BindingContextProperty, "FieldList.Value.Value");
                });
                stack.Children.Add(labels[c++]);
                stack.Children.Add(grid);
            }
 
        }

    } // Class
}