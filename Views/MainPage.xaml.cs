using DevExpress.Entity.Model;
using DevExpress.Maui.DataGrid;
using DX_test_app.Models;
using DX_test_app.ViewModels;
using System.Data;

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
                    AutoGenerateColumnsMode = AutoGenerateColumnsMode.Add,
                };

                //Customise headers

                //int width = field.Value.ToString().Length * 13;
                //int titleWidth = field.FieldLabel.ToString().Length * 13;
                //width = width < 100 ? 100 : width;
                //width = titleWidth > width ? titleWidth : width;
                grid.ColumnHeaderAppearance = new()
                {
                   FontSize = 17,
                   FontAttributes = FontAttributes.Bold,
                   BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255),
                   
                };

                grid.Columns.Add(new TemplateColumn()
                {
                       UnboundType = DevExpress.Maui.Core.UnboundDataType.Object,
                       FieldName = "FieldList",
                });

                //grid.
                //Add two labels to the template column from above
                var CellTemplate = new DataTemplate(() =>
                {
                    StackLayout stack = new();
                    stack.Children.Add(new Label()
                    {
                        Text = "FieldLabel",
                        FontSize = 17,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255),
                    });
                    stack.Children.Add(new Label()
                    {
                        Text = "Value",
                        FontSize = 17,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255),
                    });
                    return stack;
                });


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
                    
                }

                //// Iterate through fields
                //foreach (var field in col.RecordList[0].FieldList)
                //{
                //    // Check if column hasn't been added yet
                //    if (grid.Columns.FirstOrDefault(c => c.FieldName == field.Value.ToString()) == null)
                //    {
                //        // Calculate width of column based on length of data and ColumnName
                //        int width = field.Value.ToString().Length * 13;
                //        int titleWidth = field.FieldLabel.ToString().Length * 13;
                //        width = width < 100 ? 100 : width;
                //        width = titleWidth > width ? titleWidth : width;

                //        //grid.Columns.Add(new TextColumn()
                //        //{
                //        //    FieldName = "Value",
                //        //    Caption = field.FieldLabel,
                //        //    MinWidth = width,
                //        //    BindingContext = field,
                //        //});
                //    }
                //}

                // Set Source
                //grid.ItemsSource = vm.getTable(col);
                grid.ItemsSource = vm.getTable(col);
                vm.GridList.Add(grid);
            } // foreach column 
        }

        private void addGridsToView(MainPageViewModel vm)
        {
            int c = 0;
            // Iterate through gridList and add each grid to the stack layout
            foreach (var grid in vm.GridList)
            {
                //Apply additional formatting to headers
                grid.Columns.ForEach(c =>
                {
                    c.HeaderFontSize = 17;
                    c.HeaderBackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255);
                    c.HeaderFontAttributes = FontAttributes.Bold;
                    //c.SetBinding(TitleProperty, "FieldList.Field.FieldLabel");
                    //c.SetBinding(ContentProperty, new Binding("FieldList[*].Value"));
                    //c.SetBinding(TitleProperty, new Binding("FieldName"));
                    //c.SetBinding(GridColumn.BindingContextProperty, "FieldList.Value.Value");
                });
                stack.Children.Add(labels[c++]);
                stack.Children.Add(grid);
            }

        }

    } // Class
}