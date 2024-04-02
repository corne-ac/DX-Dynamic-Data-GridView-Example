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
                }
            });

            this.RowList[0].ColumnList[0].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
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
                    new Field
                    {
                        FieldId = 5,
                        FieldLabel = "Password",
                        Value = "piet@test.com"
                    }
                }
            });

            this.RowList[0].ColumnList[0].RecordList.Add(new Record()
            {
                FieldList = new List<Field>
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
                        Value = 72
                    },
                    new Field
                    {
                        FieldId = 4,
                        FieldLabel = "Email",
                        Value = "marco@test.com"
                    },
                    new Field
                    {
                        FieldId = 4,
                        FieldLabel = "Otherss",
                        Value = "dfsd@tesdtsdfsf.com"
                    }
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
            this.ColumnList.Add(new Column());
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

        public DataTable datatablesetter()
        {
            DataTable dt = new DataTable();

            // Add columns to the DataTable using the FieldLabel of the first field in the RecordList
            foreach (var record in RecordList)
            {
                foreach (var field in record.FieldList)
                {
                    if (!dt.Columns.Contains(field.FieldLabel))
                    {
                        dt.Columns.Add(field.FieldLabel);
                    }
                }
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
        //Attributes
        public List<Field> FieldList { get; set; }

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

       
    }

    public class Field
    {
        public long FieldId { get; set; }
        public string FieldLabel { get; set; }
        public object Value { get; set; }
    }

   

        
}
