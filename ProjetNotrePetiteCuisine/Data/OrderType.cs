using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetNotrePetiteCuisine.Data
{
    [DataContract]
    public class OrderType : IComparable<OrderType>
    {
        [DataMember()]
        public Guid OrderID { get; set; } // Do not change after Object creation

        [DataMember()]
        public DateTime TheDate { get; set; }

        [DataMember()]
        public string Address { get; set; }

        [DataMember()]
        public string City { get; set; }

        [DataMember()]
        public string PostalCode { get; set; }

        [DataMember()]
        public Dictionary<Recipe, int> Recipes { get; } // key = Recipe, value = quantity | Do not change after Object creation

        // Original Private Constructor called by others
        private OrderType(Guid orderID, DateTime theDate, string address, string city, string postalCode, Dictionary<Recipe, int> recipes)
        {
            this.OrderID = orderID;
            this.TheDate = theDate;
            this.Address = address;
            this.City = city;
            this.PostalCode = postalCode;
            this.Recipes = recipes;
        }

        // C# Constructor
        public OrderType(string address, string city, string postalCode, Client client) :
            this(System.Guid.NewGuid(), DateTime.Now, address, city, postalCode, new Dictionary<Recipe, int>())
        { }

        // Database Constructor
        public OrderType(MySqlDataReader reader, Dictionary<Recipe, int> recipes) :
            this(reader.GetGuid("order_id"), //
                reader.GetDateTime("the_date"), //
                reader.GetString("address"), //
                reader.GetString("city"), //
                reader.GetString("postal_code"), //
                recipes)
        { }

        public override string ToString()
        {
            return this.GetType().Name + ": " + this.OrderID;
        } // Exemple : "OrderType: A0EEBC99-9C0B-4EF8-BB6D-6BB9BD380A11"

        public int CompareTo(OrderType other)
        {
            return this.OrderID.CompareTo(other.OrderID);
        }
    }
}
