using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DX_test_app.Models
{
    public class DynamicModel
    { 
        public DynamicModel() { 
            this.PopulateDictionary(dynamicData);
        }

        public Dictionary<string, List<Dictionary<string, object>>> dynamicData = new Dictionary<string, List<Dictionary<string, object>>>();

        public void PopulateDictionary(Dictionary<string, List<Dictionary<string, object>>> dictionary)
        {
            // Example data
            dictionary["Personal Details"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "1232", "Corne" } },
                new Dictionary<string, object> { { "1224", "Ackerman" } },
                new Dictionary<string, object> { { "1225", 2 } },
                new Dictionary<string, object> { { "1226", true } },
            };

            dictionary["bank Details"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "1233", "FNB" } },
                new Dictionary<string, object> { { "1324", "23489084" } },
                new Dictionary<string, object> { { "1235", 2205 } },
                new Dictionary<string, object> { { "1326", "Savings" } },
                new Dictionary<string, object> { { "1237", "JCB Ackerman" } },
                new Dictionary<string, object> { { "128", false } },
                new Dictionary<string, object> { { "129", null } }
            };

            dictionary["Invoice"] = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "1243", "ND0000233" } },
                new Dictionary<string, object> { { "13234", "24/03/20" } },
                new Dictionary<string, object> { { "12235", 234.34 } },
                new Dictionary<string, object> { { "13246", 23423 } },
                new Dictionary<string, object> { { "12637", null } }
            };
        }

        public ObservableCollection<flattenedEntry> GetFlattenedCollection()
        {
            ObservableCollection<flattenedEntry> collection = new ObservableCollection<flattenedEntry>();

            foreach (var outerEntry in dynamicData)
            {
                foreach (var innerDictionary in outerEntry.Value)
                {
                    foreach (var innerEntry in innerDictionary)
                    {
                        collection.Add(new flattenedEntry
                        {
                            Group = outerEntry.Key,
                            Field = innerEntry.Key,
                            Data = innerEntry.Value
                        });
                    }
                }
            }

            return collection;
        }


        //[
        //  [ "ColumnId11", "1232", "dat" ],
        //  [ "ColumnId11", "1224", 23 ],  // Integer remains an integer
        //  [ "ColumnId11", "1225", true ],  // Boolean remains a boolean
        //  [ "ColumnId11", "1226", "sdfsdf" ],
        //  [ "ColumnId2", "1233", "sdf" ],
        //  [ "ColumnId2", "1324", true ],  // Boolean remains a boolean
        //  [ "ColumnId2", "1235", 234.34 ],  // Double remains a double
        //  [ "ColumnId2", "1326", 23423 ],  // Integer remains an integer
        //  [ "ColumnId2", "1237", null ],  // Null value remains null
        //  [ "ColumnId2", "128", false ],  // Boolean remains a boolean
        //  [ "ColumnId2", "129", null ]  // Null value remains null
        //]

    }

    public class flattenedEntry
    {
        public string Group { get; set; }
        public string Field { get; set; }
        public object Data { get; set; }

        


    }

}
