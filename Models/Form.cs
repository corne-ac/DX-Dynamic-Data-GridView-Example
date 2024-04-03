using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.Models
{
    //Step 1: In Form.cs, we created a nested model structure with Form, Row, Column,
    //and Record classes to represent a dynamic data set.
    //This model mimicked the variable structure of data we might receive from an external source.

    public class Form
    {
        public Form()
        {
            this.RowList = new();
            this.RowList.Add(new Row());
        }

        public List<Row> RowList { get; set; }
    }

    public class Row
    {
        public Row()
        {
            this.ColumnList = new List<Column>();

            // Existing Personal Information column
            var personalInfoColumn = new Column
            {
                ColumnId = 1,
                ColumnName = "Personal Information",
                RecordList = new List<Record>
            {
                new Record
                {
                    FieldList = new List<Field>
                    {
                        new Field { FieldId = 1, FieldLabel = "Name", Value = "Piet" },
                        new Field { FieldId = 2, FieldLabel = "Surname", Value = "Smirre" },
                        new Field { FieldId = 2, FieldLabel = "Cellphone", Value = "43232323" },
                        // Add other personal info fields...
                    }
                }
            }
            };

            // Additional Work Information column
            var workInfoColumn = new Column
            {
                ColumnId = 2,
                ColumnName = "Work Information",
                RecordList = new List<Record>
            {
                new Record
                {
                    FieldList = new List<Field>
                    {
                        new Field { FieldId = 6, FieldLabel = "Occupation", Value = "Developer" },
                        new Field { FieldId = 7, FieldLabel = "Company", Value = "DevTech" },
                        // Add other work info fields...
                    }
                }
            }
            };

            // Add the columns to the ColumnList of the row
            this.ColumnList.Add(personalInfoColumn);
            this.ColumnList.Add(workInfoColumn);
        }

        public List<Column> ColumnList { get; set; }
    }

    public class Column
    {
        public Column()
        {
            this.RecordList = new();
            this.RecordList.Add(new Record());
        }

        public long ColumnId { get; set; }
        public string ColumnName { get; set; }
        public List<Record> RecordList { get; set; }
    }

    public class Record 
    {     
        public List<Field> FieldList { get; set; }
    }

    public class Field
    {
        public long FieldId { get; set; }
        public string FieldLabel { get; set; }
        public object Value { get; set; }
    }
}
