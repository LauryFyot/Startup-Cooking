using MySql.Data.MySqlClient;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data.Base
{
    public class ProtectedQueries
    {
        protected readonly string database_name;

        protected readonly string connectionString;

        protected ProtectedQueries(string domain, int port, string database_name, string username, string password)
        {
            this.database_name = database_name;

            this.connectionString = new StringBuilder("SERVER=") //
                .Append(domain) //
                .Append(";PORT=") //
                .Append(port) //
                .Append(";DATABASE=") //
                .Append(database_name) //
                .Append(";UID=") //
                .Append(username) //
                .Append(";PASSWORD=") //
                .Append(password) //
                .Append(";AllowUserVariables=True;OldGuids=True;ConnectionTimeout=500") //
                .ToString();
        }

        /* 
         * SELECT queries
        */
        // To get orders of a client 
        protected List<OrderType> GetOrdersOfClient(Guid client_id)
        {
            List<OrderType> orders = new List<OrderType>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM ORDERTYPE WHERE client_id = @client_id";
                command.Parameters.AddWithValue("@client_id", client_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Orders found
                {
                    Dictionary<Recipe, int> recipesOfOrder = this.GetRecipesOfOrder(reader.GetGuid("order_id"));
                    orders.Add(new OrderType(reader, recipesOfOrder));
                }
            } // Connection gets closed here

            return orders;
        }

        // To get cart of a client 
        protected Dictionary<Recipe, int> GetCartOfClient(Guid client_id)
        {
            Dictionary<Recipe, int> cart = new Dictionary<Recipe, int>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM IS_IN_CART_OF NATURAL JOIN RECIPE NATURAL JOIN CLIENT WHERE client_id = @client_id";
                command.Parameters.AddWithValue("@client_id", client_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Recipes found
                {
                    Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(reader.GetGuid("recipe_id"));
                    cart.Add(new Recipe(reader, productsOfRecipe), reader.GetInt32("quantity"));
                }
            } // Connection gets closed here

            return cart;
        }

        // To get recipes and quantity of an order
        protected Dictionary<Recipe, int> GetRecipesOfOrder(Guid order_id)
        {
            Dictionary<Recipe, int> recipes = new Dictionary<Recipe, int>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM IS_IN_ORDERTYPE NATURAL JOIN RECIPE NATURAL JOIN CLIENT WHERE order_id = @order_id";
                command.Parameters.AddWithValue("@order_id", order_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Recipes natural joigned IS_IN_ORDERTYPE (for quantity) found
                {
                    Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(reader.GetGuid("recipe_id"));
                    recipes.Add(new Recipe(reader, productsOfRecipe), reader.GetInt32("quantity"));
                }
            } // Connection gets closed here

            return recipes;
        }

        // To get products and quantity of a recipe
        protected Dictionary<Product, int> GetProductsOfRecipe(Guid recipe_id)
        {
            Dictionary<Product, int> products = new Dictionary<Product, int>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM PRODUCT NATURAL JOIN HAS_PRODUCT NATURAL JOIN SUPPLIER WHERE recipe_id = @recipe_id";
                command.Parameters.AddWithValue("@recipe_id", recipe_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Products natural joigned HAS_PRODUCT (for quantity) and SUPPLIER found
                {
                    products.Add(new Product(reader), reader.GetInt32("quantity"));
                }
            } // Connection gets closed here

            return products;
        }

        // To get a Recipe by recipe_id (throw CookingException if Recipe not found)
        protected Recipe GetRecipeByID(Guid recipe_id)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM RECIPE NATURAL JOIN CLIENT WHERE recipe_id = @recipe_id and client_id = recipe_creator_id";
                command.Parameters.AddWithValue("@recipe_id", recipe_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read()) // Check the Recipe exists
                {
                    throw new CookingException("Recipe not found !");
                }

                Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(recipe_id);

                return new Recipe(reader, productsOfRecipe);

            } // Connection gets closed here
        }

        // To get a RecipeCreator by recipe_creator_id (throw CookingException if RecipeCreator not found)
        protected RecipeCreator GetRecipeCreatorByID(Guid recipe_creator_id)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM CLIENT NATURAL JOIN RECIPE_CREATOR WHERE recipe_creator_id = @client_id and client_id = @client_id";
                command.Parameters.AddWithValue("@client_id", recipe_creator_id.ToString());

                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read()) // Check the Recipe exists
                {
                    throw new CookingException("RecipeCreator not found !");
                }

                List<OrderType> clientOrders = this.GetOrdersOfClient(recipe_creator_id);
                Dictionary<Recipe, int> clientCart = this.GetCartOfClient(recipe_creator_id);

                return new RecipeCreator(reader, clientOrders, clientCart);

            } // Connection gets closed here
        }
    }
}
