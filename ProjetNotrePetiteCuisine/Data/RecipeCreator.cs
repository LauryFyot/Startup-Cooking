using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data
{
    public class RecipeCreator : Client
    {

        public int CookBalance { get; set; }

        // C# Constructor
        public RecipeCreator(string username, //
            string password, //
            string firstName, //
            string lastName, //
            string phoneNumber, //
            string email, //
            bool canBeRecipeCreator = true) : base(username, password, firstName, lastName, phoneNumber, email, canBeRecipeCreator)
        {
            this.CookBalance = 0;
        }

        // C# Constructor | When Client become RecipeCreator
        public RecipeCreator(Client client) : base(client.ClientID, client.Username, client.Password, client.FirstName, client.LastName, client.PhoneNumber, client.Email,//
            client.CanBeRecipeCreator, //
            new List<OrderType>(), //
                new Dictionary<Recipe, int>())
        {
            this.CookBalance = 0;
        }

        // Database Constructor
        public RecipeCreator(MySqlDataReader reader, List<OrderType> orders, Dictionary<Recipe, int> cart) : base(reader, orders, cart)
        {
            this.CookBalance = reader.GetInt32("cook_balance");
        }

        public int TotalCartAfterDeduction()
        {
            return this.TotalCart() - this.CookBalance;
        }
    }
}
