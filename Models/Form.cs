using System;
using System.Collections.Generic;
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
