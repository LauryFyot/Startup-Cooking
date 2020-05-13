using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Runtime.Serialization;

namespace ProjetNotrePetiteCuisine.Data
{
    [DataContract]
    public class Supplier : IComparable<Supplier>
    {
        [DataMember()]
        public Guid SupplierID { get; set; } // Do not change after Object creation

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public string PhoneNumber { get; set; }

        // Original Private Constructor called by others
        private Supplier(Guid supplierID, string name, string phoneNumber)
        {
            this.SupplierID = supplierID;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        // C# Constructor
        public Supplier(string name, string phoneNumber) : this(System.Guid.NewGuid(), name, phoneNumber) { }

        // Database Constructor
        public Supplier(MySqlDataReader reader) :
            this(reader.GetGuid("supplier_id"), //
                reader.GetString("supplier_name"), //
                reader.GetString("phone_number"))
        { }

        public override string ToString()
        {
            return this.GetType().Name + ": " + this.Name;
        } // Exemple : "Supplier: Jean"

        public int CompareTo(Supplier other)
        {
            return this.SupplierID.CompareTo(other.SupplierID);
        }
    }
}
