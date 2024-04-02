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

        //Method to convert the fields to a datatable, where the field.fieldlabel is a column name, and the field.value is the row data
        public DataTable datatablesetter()
        {
            DataTable dt = new DataTable();
            foreach (var item in RecordList[0].FieldList)
            {
                dt.Columns.Add(item.FieldLabel);
            }
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

        //Method that returns an ObservableCollection<string[,]> that can be set on my UI, the method will also set the columns based on the fields inside the fieldlist, each field.fieldlabel is a column name, and the field.value is the row
        public string[,] GetFlattenedData()
        {
            var flattenedData = new string[RecordList.Count, RecordList[0].FieldList.Count];
            for (int i = 0; i < RecordList.Count; i++)
            {
                for (int j = 0; j < RecordList[i].FieldList.Count; j++)
                {
                    flattenedData[i, j] = RecordList[i].FieldList[j].Value.ToString();
                }
            }
            return flattenedData;
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
                new Field
                {
                    FieldId = 4,
                    FieldLabel = "df",
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
