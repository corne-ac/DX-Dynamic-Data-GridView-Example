using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.Models
{
    public class Form
    {
        //Attributes
        public List<Row> RowList { get; set; }

        public Form()
        {
            this.RowList = new();
            this.RowList.Add(new Row());
        }

        //Method to populate with sample data
        public void populate()
        {
            this.RowList[0].ColumnList[0].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Name", Value = "Corne" },
                    new Field { FieldId = 2, FieldLabel = "Surname", Value = "Ackerman" },
                    new Field { FieldId = 3, FieldLabel = "Age", Value = 23 },
                    new Field { FieldId = 4, FieldLabel = "Email", Value = "corne@test.com" }
                }
            });

            this.RowList[0].ColumnList[0].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Name", Value = "Piet" },
                    new Field { FieldId = 2, FieldLabel = "Surname", Value = "Smirre" },
                    new Field { FieldId = 3, FieldLabel = "Age", Value = 7 },
                    new Field { FieldId = 4, FieldLabel = "Email", Value = "piet@test.com" }
                }
            });

            this.RowList[0].ColumnList[0].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Name", Value = "marco" },
                    new Field { FieldId = 2, FieldLabel = "Surname", Value = "mclaren" },
                    new Field { FieldId = 3, FieldLabel = "Age", Value = 72 },
                    new Field { FieldId = 4, FieldLabel = "Email", Value = "marco@test.com" },
                    new Field { FieldId = 5, FieldLabel = "Password", Value = "piet@test.com" }
                }
            });

            //second column
            this.RowList[0].ColumnList[1].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Product", Value = "MSI Raider" },
                    new Field { FieldId = 2, FieldLabel = "Product Category", Value = "Laptop" },
                    new Field { FieldId = 3, FieldLabel = "Price", Value = 20999.80 },
                    new Field { FieldId = 4, FieldLabel = "Seller", Value = "MSI" }
                }
            });

            this.RowList[0].ColumnList[1].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Product", Value = "Samsung S22" },
                    new Field { FieldId = 2, FieldLabel = "Product Category", Value = "Smartphone" },
                    new Field { FieldId = 3, FieldLabel = "Price", Value = 5699.50 },
                    new Field { FieldId = 4, FieldLabel = "Seller", Value = "Samsung" }
                }
            });

            this.RowList[0].ColumnList[1].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "Product", Value = "Acer G23789E" },
                    new Field { FieldId = 2, FieldLabel = "Product Category", Value = "Display" },
                    new Field { FieldId = 3, FieldLabel = "Price", Value = 5999.00 },
                    new Field { FieldId = 4, FieldLabel = "Seller", Value = "Lenovo" }
                }
            });

            //Third column
            this.RowList[0].ColumnList[2].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "IsActive", Value = true },
                    new Field { FieldId = 2, FieldLabel = "Emp Number", Value = "E1234" },
                    new Field { FieldId = 3, FieldLabel = "Role", Value = "Dev" },
                    new Field { FieldId = 4, FieldLabel = "Type", Value = "Full-Time" }
                }
            });

            this.RowList[0].ColumnList[2].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "IsActive", Value = false },
                    new Field { FieldId = 2, FieldLabel = "Emp Number", Value = "E1235" },
                    new Field { FieldId = 3, FieldLabel = "Role", Value = "Consultant" },
                    new Field { FieldId = 4, FieldLabel = "Type", Value = "Part-Time" }
                }
            });

            this.RowList[0].ColumnList[2].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "IsActive", Value = true },
                    new Field { FieldId = 2, FieldLabel = "Emp Number", Value = "E1236" },
                    new Field { FieldId = 3, FieldLabel = "Role", Value = "HR" },
                    new Field { FieldId = 4, FieldLabel = "Type", Value = "Full-Time" }
                }
            });

            this.RowList[0].ColumnList[2].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
                {
                    new Field { FieldId = 1, FieldLabel = "IsActive", Value = true },
                    new Field { FieldId = 2, FieldLabel = "Emp Number", Value = "E1237" },
                    new Field { FieldId = 3, FieldLabel = "Role", Value = "CEO" },
                    new Field { FieldId = 4, FieldLabel = "Type", Value = "Full-Time" }
                }
            });
        }
    }

    public class Row
    {
        //Attributes
        public List<Column> ColumnList { get; set; }

        public Row()
        {
            this.ColumnList = new();
            this.ColumnList.Add(new Column() { ColumnName = "Personal Details" });
            this.ColumnList.Add(new Column() { ColumnName = "Products" });
            this.ColumnList.Add(new Column() { ColumnName = "Employees" });
        }
    }

    public class Column
    {
        //Attributes
        public long ColumnId { get; set; }
        public string ColumnName { get; set; }
        public List<Record> RecordList { get; set; }

        public Column()
        {
            this.RecordList = new();
        }
    }

    public class Record 
    {
        //Attributes
        public List<Field> FieldList { get; set; }

        public Record()
        {
            this.FieldList = new();
        }

       
    }

    public class Field
    {
        public long FieldId { get; set; }
        public string FieldLabel { get; set; }
        public object Value { get; set; }
    }   
}
