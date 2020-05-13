using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data.Base
{
    public class Admin : Client
    {
        // C# Constructor
        public Admin(string username, string password, string firstName, string lastName, string phoneNumber, string email, bool canBeRecipeCreator = true) :
            base(username, password, firstName, lastName, phoneNumber, email, canBeRecipeCreator)
        { }

        // Database Constructor
        public Admin(MySqlDataReader reader, List<OrderType> orders, Dictionary<Recipe, int> cart) : base(reader, orders, cart) { }
    }
}
