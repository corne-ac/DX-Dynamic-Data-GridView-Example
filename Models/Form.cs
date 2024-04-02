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
        public Form()
        {
            this.RowList = new();
            this.RowList.Add(new Row());
        }

        public List<Row> RowList { get; set; }

        //Method to populate with sample data
        public void populate()
        {
            this.RowList[0].ColumnList[0].RecordList[0].FieldList = new()
            {
                new Field
                {
                    FieldId = 1,
                    FieldLabel = "Name",
                    Value = "Piet"
                },
                new Field
                {
                    FieldId = 2,
                    FieldLabel = "Surname",
                    Value = "Smirre"
                },
                new Field
                {
                    FieldId = 3,
                    FieldLabel = "Age",
                    Value = 7
                },
                new Field
                {
                    FieldId = 4,
                    FieldLabel = "Email",
                    Value = "piet@test.com"
                }
            };

            this.RowList[0].ColumnList[0].RecordList[1].FieldList = new()
            {
                new Field
                {
                    FieldId = 1,
                    FieldLabel = "Name",
                    Value = "Corne"
                },
                new Field
                {
                    FieldId = 2,
                    FieldLabel = "Surname",
                    Value = "Ackerman"
                },
                new Field
                {
                    FieldId = 3,
                    FieldLabel = "Age",
                    Value = 23
                },
                new Field
                {
                    FieldId = 4,
                    FieldLabel = "Email",
                    Value = "corne@test.com"
                }
            };

            this.RowList[0].ColumnList[0].RecordList[1].FieldList = new()
            {
                new Field
                {
                    FieldId = 1,
                    FieldLabel = "Name",
                    Value = "marco"
                },
                new Field
                {
                    FieldId = 2,
                    FieldLabel = "Surname",
                    Value = "mclaren"
                },
                new Field
                {
                    FieldId = 3,
                    FieldLabel = "Age",
                    Value = 25
                },
                new Field
                {
                    FieldId = 4,
                    FieldLabel = "Email",
                    Value = "marco@test.com"
                }
            };
        }
    }

    public class Row
    {
        public Row()
        {
            this.ColumnList = new();
            this.ColumnList.Add(new Column());
        }

        public List<Column> ColumnList { get; set; }
    }

    public class Column
    {
        public Column()
        {
            this.RecordList = new();
            this.RecordList.Add(new Record());
            this.RecordList.Add(new Record());
            this.RecordList.Add(new Record());
            this.RecordList.Add(new Record());
            this.RecordList.Add(new Record());
            this.RecordList.Add(new Record());
        }

        public long ColumnId { get; set; }
        public string ColumnName { get; set; }
        public List<Record> RecordList { get; set; }

        /// <summary>
        /// Converts the fields in the RecordList to a DataTable.
        /// Each field's FieldLabel is used as a column name, and the field's Value is used as the row data.
        /// </summary>
        /// <returns>The converted DataTable.</returns>
        public DataTable datatablesetter()
        {
            DataTable dt = new DataTable();

            // Add columns to the DataTable using the FieldLabel of the first field in the RecordList
            foreach (var item in RecordList[0].FieldList)
            {
                dt.Columns.Add(item.FieldLabel);
            }

            // Add rows to the DataTable using the FieldLabel as the column name and the Value as the row data
            foreach (var record in RecordList)
            {
                DataRow dr = dt.NewRow();
                foreach (var field in record.FieldList)
                {
                    dr[field.FieldLabel] = field.Value;
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

    }

    public class Record 
    {
        public Record()
        {
            this.FieldList = new()
            { 
                new Field 
                {
                    FieldId = 1,
                    FieldLabel = "Name",
                    Value = "Piet"
                },
                new Field
                {
                    FieldId = 2,
                    FieldLabel = "Surname",
                    Value = "Smirre"
                },
                new Field
                {
                    FieldId = 3,
                    FieldLabel = "Age",
                    Value = 7
                },
                new Field
                {
                    FieldId = 4,
                    FieldLabel = "Email",
                    Value = "piet@test.com"
                },

            };
        }

        public List<Field> FieldList { get; set; }
    }

    public class Field
    {
        public long FieldId { get; set; }
        public string FieldLabel { get; set; }
        public object Value { get; set; }
    }

   

        
}
