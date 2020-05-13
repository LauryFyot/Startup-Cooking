using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data
{
    public class Client : IComparable<Client>
    {

        public Guid ClientID { get; } // Do not change after Object creation
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool CanBeRecipeCreator { get; set; }
        public List<OrderType> Orders { get; } // Do not change after Object creation
        public Dictionary<Recipe, int> Cart { get; } // key = Recipe, value = quantity

        // Original Private Constructor called by others
        protected Client(Guid clientID, //
            string username, //
            string password, //
            string firstName, //
            string lastName, //
            string phoneNumber, //
            string email, //
            bool canBeRecipeCreator, //
            List<OrderType> orders, //
            Dictionary<Recipe, int> cart)
        {
            this.ClientID = clientID;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.CanBeRecipeCreator = canBeRecipeCreator;
            this.Orders = orders;
            this.Cart = cart;
        }

        // C# Constructor
        public Client(string username, //
            string password, //
            string firstName, //
            string lastName, //
            string phoneNumber, //
            string email, //
            bool canBeRecipeCreator = true) :
            this(System.Guid.NewGuid(), //
                username, //
                password, //
                firstName, //
                lastName, //
                phoneNumber, //
                email, //
                canBeRecipeCreator, //
                new List<OrderType>(), //
                new Dictionary<Recipe, int>())
        { }

        // Database Constructor
        public Client(MySqlDataReader reader, List<OrderType> orders, Dictionary<Recipe, int> cart) :
            this(reader.GetGuid("client_id"), //
                reader.GetString("username"), //
                null, // No need do get password if client exists (SECURITY)
                reader.GetString("first_name"), //
                reader.GetString("last_name"), //
                reader.GetString("phone_number"), //
                reader.GetString("email"), //
                reader.GetBoolean("can_be_recipe_creator"), //
                orders, //
                cart)
        { }

        public override string ToString()
        {
            return this.GetType().Name + ": " + this.Username;
        } // Exemple : "Client: Jeanne78"

        public int CompareTo(Client other)
        {
            return this.ClientID.CompareTo(other.ClientID);
        }

        public int TotalCart()
        {
            int totalPrice=0;
            if (this.Cart != null && this.Cart.Count != 0)
            {
                foreach (KeyValuePair<Recipe, int> kvp in this.Cart)
                {
                    totalPrice += kvp.Key.Price * kvp.Value; //price * quantity
                }
            }
            return totalPrice;
        }
        
    }
}
