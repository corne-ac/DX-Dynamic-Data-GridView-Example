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
                grid.ColumnHeaderAppearance = new()
                {
                   FontSize = 17,
                   FontAttributes = FontAttributes.Bold,
                   BackgroundColor = Microsoft.Maui.Graphics.Color.FromRgba(173, 216, 230, 255),
                   
                };


                //Implement Custom Column that will have button controls
                grid.Columns.Add(new TemplateColumn()
                {
                       UnboundType = DevExpress.Maui.Core.UnboundDataType.Object,
                       FieldName = "FieldList",
                    DisplayTemplate = new DataTemplate(() =>
                    {
                        var stack = new StackLayout();
                        stack.Orientation = StackOrientation.Horizontal;
                        stack.Spacing = 10;
                        stack.Padding = new Thickness(10, 5, 10, 5);

                        var editButton = new Button();
                        editButton.Text = "✎";
                        editButton.Clicked += (sender, e) =>
                        {
                            //Print to console
                            Console.WriteLine("Edit Button Clicked");
                        };
                        stack.Children.Add(editButton);

                        var deleteButton = new Button();
                        deleteButton.Text = "🗑";
                        deleteButton.Clicked += (sender, e) =>
                        {
                            //Print to console
                            Console.WriteLine("Delete Button Clicked");
                            
                        };
                        stack.Children.Add(deleteButton);

                        return stack;
                    }),

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

                // Set Source
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
                });
                stack.Children.Add(labels[c++]);
                stack.Children.Add(grid);
            }

        }

    } // Class
}