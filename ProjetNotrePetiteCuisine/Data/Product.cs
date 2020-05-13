using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data
{
    [DataContract]
    public class Product : IComparable<Product>
    {
        [DataMember()]
        public Guid ProductID { get; set; } // Do not change after Object creation

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public string Category { get; set; }

        [DataMember()]
        public string Unit { get; set; }

        [DataMember()]
        public int Quantity { get; set; }

        [DataMember()]
        public int MinQuantity { get; set; }

        [DataMember()]
        public int MaxQuantity { get; set; }

        [DataMember()]
        public Supplier Supplier { get; set; }

        // Original Private Constructor called by others
        private Product(Guid productID, string name, string category, string unit, Supplier supplier, int quantity, int minQuantity, int maxQuantity)
        {
            this.ProductID = productID;
            this.Name = name;
            this.Category = category;
            this.Unit = unit;
            this.Quantity = quantity;
            this.MinQuantity = minQuantity;
            this.MaxQuantity = maxQuantity;
            this.Supplier = supplier;
        }

        // C# Constructor
        public Product(string name, string category, string unit, Supplier supplier, int quantity = 200, int minQuantity = 100, int maxQuantity = 300) :
            this(System.Guid.NewGuid(), name, category, unit, supplier, quantity, minQuantity, maxQuantity)
        { }

        // Database Constructor
        public Product(MySqlDataReader reader) :
            this(reader.GetGuid("product_id"), //
                reader.GetString("product_name"), //
                reader.GetString("category"), //
                reader.GetString("unit"), //
                new Supplier(reader), //
                reader.GetInt32("product_quantity"), //
                reader.GetInt32("min_quantity"), //
                reader.GetInt32("max_quantity"))
        { }

        public int CompareTo(Product other)
        {
            return this.ProductID.CompareTo(other.ProductID);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
