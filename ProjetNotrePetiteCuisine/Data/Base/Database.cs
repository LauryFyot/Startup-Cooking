using MySql.Data.MySqlClient;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data.Base
{

    public class Database : ProtectedQueries
    {

        public Database(string domain, int port, string database_name, string username, string password) : base (domain, port, database_name, username, password)
        { }

        /* 
         * Queries Initialization
        */
        public bool TablesExist()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "select COUNT(*) AS nb from INFORMATION_SCHEMA.TABLES WHERE (table_name='DASHBOARD' "
                                        + "or table_name = 'HAS_PRODUCT' or table_name = 'PRODUCT' or table_name = 'SUPPLIER' "
                                        + "or table_name = 'IS_IN_ORDERTYPE' or table_name = 'RECIPE' or table_name = 'ORDERTYPE' "
                                        + "or table_name = 'ADMIN' or table_name = 'RECIPE_CREATOR' or table_name = 'CLIENT' or table_name = 'IS_IN_CART_OF') "
                                        + "and table_schema = @database_name";
                command.Parameters.AddWithValue("@database_name", this.database_name);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new CookingException("MysqlDataReader is empty !");
                }

                return reader.GetInt32("nb") == 11; // Check the 11 tables already exist

            } // Connection gets closed here
        }

        public bool TriggersExist()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "select COUNT(*) AS nb from INFORMATION_SCHEMA.TRIGGERS WHERE (trigger_name='AFTER_ORDERTYPE_INSERT' or trigger_name = 'AFTER_RECIPE_DELETE' "
                                        + "or trigger_name = 'BEFORE_RECIPE_UPDATE' or trigger_name = 'AFTER_IS_IN_ORDERTYPE_INSERT') "
                                        + "and trigger_schema = @database_name";
                command.Parameters.AddWithValue("@database_name", this.database_name);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new CookingException("MysqlDataReader is empty !");
                }

                return reader.GetInt32("nb") == 4; // Check the 5 triggers already exist

            } // Connection gets closed here
        }

        public bool EventsExist()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "select COUNT(*) AS nb from INFORMATION_SCHEMA.EVENTS WHERE event_name='PRODUCT_STOCK_MANAGER' "
                                        + "and event_schema = @database_name";
                command.Parameters.AddWithValue("@database_name", this.database_name);
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    throw new CookingException("MysqlDataReader is empty !");
                }

                return reader.GetInt32("nb") == 1; // Check the 1 event already exist

            } // Connection gets closed here
        }

        public int DropThenCreateTables()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandTimeout = 60; // Increase Command Timeout for this sql script execution
                command.CommandText = Properties.Resources.CREATE_TABLES.ToString(); // Get sql script to CREATE tables
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int DropThenCreateTriggers()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandTimeout = 60; // Increase Command Timeout for this sql script execution
                command.CommandText = Properties.Resources.CREATE_TRIGGERS.ToString(); // Get sql script to CREATE triggers
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int DropThenCreateEvents()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandTimeout = 60; // Increase Command Timeout for this sql script execution
                command.CommandText = Properties.Resources.CREATE_EVENTS.ToString(); // Get sql script to CREATE events
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public bool TestConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                return true;

            } // Connection gets closed here
        }

        /* 
         * SELECT queries
        */
        // To login the Client/RecipeCreator/Admin (throw CookingException if Client not found)
        public Client Login(string username, string password)
        {
            Client client = null;

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM CLIENT LEFT JOIN ADMIN ON client_id = admin_id LEFT JOIN RECIPE_CREATOR ON client_id = recipe_creator_id WHERE username = @username and password = SHA1(@password)";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password); // The Password is in the Database => SHA1(@password) !

                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read()) // If Client doesn't exist throw Exception
                {
                    throw new CookingException("Client not found !");
                }

                Guid client_id = reader.GetGuid("client_id");
                List<OrderType> clientOrders = this.GetOrdersOfClient(client_id);
                Dictionary<Recipe, int> clientCart = this.GetCartOfClient(client_id);
                
                if (reader["admin_id"] != DBNull.Value) //(reader.GetString("admin_id") != null) // If he is an Admin
                {
                    client = new Admin(reader, clientOrders, clientCart);
                }
                else if (reader["recipe_creator_id"] != DBNull.Value) // If he is a RecipeCreator
                {
                    client = new RecipeCreator(reader, clientOrders, clientCart);
                }
                else // else he's only a Client
                {
                    client = new Client(reader, clientOrders, clientCart);
                }
            } // Connection gets closed here

            return client;
        }

        public List<Recipe> GetValidRecipesOrderByName()
        {
            List<Recipe> recipes = new List<Recipe>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM RECIPE NATURAL JOIN CLIENT WHERE is_validated = 1 and client_id = recipe_creator_id ORDER BY name";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Recipes
                {
                    Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(reader.GetGuid("recipe_id"));
                    recipes.Add(new Recipe(reader, productsOfRecipe));
                }
            } // Connection gets closed here

            return recipes;
        }

        public List<Recipe> GetNotValidRecipesOrderByName()
        {
            List<Recipe> recipes = new List<Recipe>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM RECIPE NATURAL JOIN CLIENT WHERE is_validated = 0 and client_id = recipe_creator_id ORDER BY name";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Recipes
                {
                    Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(reader.GetGuid("recipe_id"));
                    recipes.Add(new Recipe(reader, productsOfRecipe));
                }
            } // Connection gets closed here

            return recipes;
        }  

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM PRODUCT NATURAL JOIN SUPPLIER ORDER BY product_name";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Products
                {
                    products.Add(new Product(reader));
                }
            } // Connection gets closed here

            return products;
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM CLIENT";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Clients
                {
                    Guid client_id = reader.GetGuid("client_id");
                    List<OrderType> clientOrders = this.GetOrdersOfClient(client_id);
                    Dictionary<Recipe, int> clientCart = this.GetCartOfClient(client_id);
                    clients.Add(new Client(reader, clientOrders, clientCart));
                }
            } // Connection gets closed here

            return clients;
        }

        public List<RecipeCreator> GetAllRC()
        {
            List<RecipeCreator> clients = new List<RecipeCreator>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM CLIENT JOIN RECIPE_CREATOR on CLIENT.client_id = RECIPE_CREATOR.recipe_creator_id";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all RecipeCreators
                {
                    Guid client_id = reader.GetGuid("client_id");
                    List<OrderType> clientOrders = this.GetOrdersOfClient(client_id);
                    Dictionary<Recipe, int> clientCart = this.GetCartOfClient(client_id);
                    clients.Add(new RecipeCreator(reader, clientOrders, clientCart));
                }
            } // Connection gets closed here

            return clients;
        }

        public Dashboard GetDashboard()
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM DASHBOARD";
                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read()) // If Dashboard doesn't exist throw Exception
                {
                    throw new CookingException("Dashboard not found !");
                }

                return new Dashboard(//
                    reader["best_recipe_creator_id_of_week"] == DBNull.Value ? null : this.GetRecipeCreatorByID(reader.GetGuid("best_recipe_creator_id_of_week")), //
                    reader["first_recipe_id"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("first_recipe_id")), //
                    reader["second_recipe_id"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("second_recipe_id")), //
                    reader["third_recipe_id"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("third_recipe_id")), //
                    reader["fourth_recipe_id"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("fourth_recipe_id")), //
                    reader["fifth_recipe_id"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("fifth_recipe_id")), //
                    reader["best_recipe_creator_id"] == DBNull.Value ? null : this.GetRecipeCreatorByID(reader.GetGuid("best_recipe_creator_id")),
                    reader["first_recipe_id_of_best_rc"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("first_recipe_id_of_best_rc")), //
                    reader["second_recipe_id_of_best_rc"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("second_recipe_id_of_best_rc")), //
                    reader["third_recipe_id_of_best_rc"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("third_recipe_id_of_best_rc")), //
                    reader["fourth_recipe_id_of_best_rc"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("fourth_recipe_id_of_best_rc")), //
                    reader["fifth_recipe_id_of_best_rc"] == DBNull.Value ? null : this.GetRecipeByID(reader.GetGuid("fifth_recipe_id_of_best_rc")));

            } // Connection gets closed here
        }

        public List<OrderType> GetAllOrdersOfLastWeek()
        {
            List<OrderType> orders = new List<OrderType>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM ORDERTYPE WHERE the_date >= (CURRENT_TIMESTAMP - INTERVAL 1 WEEK) ORDER BY the_date";
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Orders
                {
                    Dictionary<Recipe, int> orderRecipes = this.GetRecipesOfOrder(reader.GetGuid("order_id"));
                    orders.Add(new OrderType(reader, orderRecipes));
                }
            } // Connection gets closed here

            return orders;
        }

        public List<Recipe> GetRecipeOfRecipeCreator(Client recipeCreator) // Here we write Client to avoid cast Exceptions
        {
            List<Recipe> recipes = new List<Recipe>();

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "SELECT * FROM RECIPE NATURAL JOIN CLIENT WHERE client_id = recipe_creator_id and recipe_creator_id = @recipe_creator_id ORDER BY name";
                command.Parameters.AddWithValue("@recipe_creator_id", recipeCreator.ClientID.ToString());
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) // Iterate all Recipes
                {
                    Dictionary<Product, int> productsOfRecipe = this.GetProductsOfRecipe(reader.GetGuid("recipe_id"));
                    recipes.Add(new Recipe(reader, productsOfRecipe));
                }
            } // Connection gets closed here

            return recipes;
        }
 

        /* 
         * INSERT queries
        */
        public int InsertClient(Client client)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO CLIENT(client_id, username, password, first_name, last_name, phone_number, email, can_be_recipe_creator) "
                                        + "VALUES(@client_id, @username, SHA1(@password), @first_name, @last_name, @phone_number, @email, @can_be_recipe_creator)";
                command.Parameters.AddWithValue("@client_id", client.ClientID.ToString());
                command.Parameters.AddWithValue("@username", client.Username);
                command.Parameters.AddWithValue("@password", client.Password); // The Password is in the Database => SHA1(@password) !
                command.Parameters.AddWithValue("@first_name", client.FirstName);
                command.Parameters.AddWithValue("@last_name", client.LastName);
                command.Parameters.AddWithValue("@phone_number", client.PhoneNumber);
                command.Parameters.AddWithValue("@email", client.Email);
                command.Parameters.AddWithValue("@can_be_recipe_creator", client.CanBeRecipeCreator);
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertClientAsAdmin(Admin admin)
        {
            int res = this.InsertClient(admin); // First Insert the Admin as a Client (If client already exist => No problem, he just going to be updated !)

            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO ADMIN(admin_id) VALUES(@admin_id)";
                command.Parameters.AddWithValue("@admin_id", admin.ClientID.ToString());
                return res + command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertClientAsRecipeCreator(RecipeCreator recipeCreator)
        {
            return this.InsertClient(recipeCreator) // First Insert the RecipeCreator as a Client
                + this.InsertOnlyRecipeCreator(recipeCreator); // Then Insert the RecipeCreator as a RecipeCreator
        }

        public int InsertOnlyRecipeCreator(RecipeCreator recipeCreator)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO RECIPE_CREATOR(recipe_creator_id) VALUES(@recipe_creator_id)";
                command.Parameters.AddWithValue("@recipe_creator_id", recipeCreator.ClientID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertRecipe(Recipe recipe)
        {
            int res = 0;
            
            // First INSERT the Recipe
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO RECIPE(recipe_id, name, description, type, price, difficulty_level, for_nb_person, nb_step, creation_date, modification_date, is_validated, recipe_creator_id) "
                                        + "VALUES(@recipe_id, @name, @description, @type, @price, @difficulty_level, @for_nb_person, nb_step, @creation_date, @modification_date, @is_validated, @recipe_creator_id)";
                command.Parameters.AddWithValue("@recipe_id", recipe.RecipeID.ToString());
                command.Parameters.AddWithValue("@name", recipe.Name);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Parameters.AddWithValue("@type", recipe.Type);
                command.Parameters.AddWithValue("@price", recipe.Price);
                command.Parameters.AddWithValue("@difficulty_level", recipe.DifficultyLevel);
                command.Parameters.AddWithValue("@for_nb_person", recipe.ForNbPerson);
                command.Parameters.AddWithValue("@nb_step", recipe.NbStep);
                command.Parameters.AddWithValue("@creation_date", recipe.CreationDate);
                command.Parameters.AddWithValue("@modification_date", recipe.ModificationDate);
                command.Parameters.AddWithValue("@is_validated", recipe.IsValidated);
                command.Parameters.AddWithValue("@recipe_creator_id", recipe.RecipeCreatorID.ToString());
                res += command.ExecuteNonQuery();

            } // Connection gets closed here

            // Now link Products to the Recipe through => INSERT all HAS_PRODUCT
            foreach (KeyValuePair<Product, int> e in recipe.Products) // key = Product, value = quantity
            {
                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO HAS_PRODUCT(recipe_id, product_id, quantity) VALUES(@recipe_id, @product_id, @quantity)";
                    command.Parameters.AddWithValue("@recipe_id", recipe.RecipeID.ToString());
                    command.Parameters.AddWithValue("@product_id", e.Key.ProductID.ToString());
                    command.Parameters.AddWithValue("@quantity", e.Value);
                    res += command.ExecuteNonQuery();

                } // Connection gets closed here
            }

            return res;
        }

        public int InsertProduct(Product product)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO PRODUCT(product_id, product_name, category, unit, supplier_id) VALUES(@product_id, @product_name, @category, @unit, @supplier_id)";
                command.Parameters.AddWithValue("@product_id", product.ProductID.ToString());
                command.Parameters.AddWithValue("@product_name", product.Name);
                command.Parameters.AddWithValue("@category", product.Category);
                command.Parameters.AddWithValue("@unit", product.Unit);
                command.Parameters.AddWithValue("@supplier_id", product.Supplier.SupplierID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertSupplier(Supplier supplier)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO SUPPLIER(supplier_id, supplier_name, phone_number) VALUES(@supplier_id, @supplier_name, @phone_number)";
                command.Parameters.AddWithValue("@supplier_id", supplier.SupplierID.ToString());
                command.Parameters.AddWithValue("@supplier_name", supplier.Name);
                command.Parameters.AddWithValue("@phone_number", supplier.PhoneNumber);
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "INSERT INTO IS_IN_CART_OF(client_id, recipe_id, quantity) VALUES(@client_id, @recipe_id, @quantity)";
                command.Parameters.AddWithValue("@client_id", buyer.ClientID.ToString());
                command.Parameters.AddWithValue("@recipe_id", e.Key.RecipeID.ToString());
                command.Parameters.AddWithValue("@quantity", e.Value);
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int InsertOrder(Client buyer, OrderType order)
        {
            try
            {
                int res = 0;

                using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                using (MySqlCommand command = connection.CreateCommand())
                {
                    connection.Open();

                    command.CommandText = "INSERT INTO ORDERTYPE(order_id, the_date, address, city, postal_code, client_id) VALUES(@order_id, @the_date, @address, @city, @postal_code, @client_id)";
                    command.Parameters.AddWithValue("@order_id", order.OrderID.ToString());
                    command.Parameters.AddWithValue("@the_date", order.TheDate);
                    command.Parameters.AddWithValue("@address", order.Address);
                    command.Parameters.AddWithValue("@city", order.City);
                    command.Parameters.AddWithValue("@postal_code", order.PostalCode);
                    command.Parameters.AddWithValue("@client_id", buyer.ClientID.ToString());
                    res += command.ExecuteNonQuery();

                } // Connection gets closed here

                // Now link Recipes to the Order through => INSERT all IS_IN_ORDERTYPE
                foreach (KeyValuePair<Recipe, int> e in order.Recipes) // key = Recipe, value = quantity
                {
                    using (MySqlConnection connection = new MySqlConnection(this.connectionString))
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        command.CommandText = "INSERT INTO IS_IN_ORDERTYPE(order_id, recipe_id, quantity) VALUES(@order_id, @recipe_id, @quantity)";
                        command.Parameters.AddWithValue("@order_id", order.OrderID.ToString());
                        command.Parameters.AddWithValue("@recipe_id", e.Key.RecipeID.ToString());
                        command.Parameters.AddWithValue("@quantity", e.Value);
                        res += command.ExecuteNonQuery();

                    } // Connection gets closed here
                }
                return res;
            } catch (MySqlException e)
            {
                if (e.Number == 1690)
                {
                    throw new CookingException("Product quantity too low for your order !");
                }
                throw e;
            }
            
        }

        /* 
         * UPDATE queries
        */
        public int UpdateClient(Client client) // If password is not changed (i.e equals Null) => No problems, we don't update it thanks IFNULL
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "UPDATE CLIENT SET username = @username, password = IFNULL(SHA1(@password), password), first_name = @first_name, last_name = @last_name,  "
                                        + "phone_number = @phone_number, email = @email, can_be_recipe_creator = @can_be_recipe_creator WHERE client_id = @client_id";
                command.Parameters.AddWithValue("@username", client.Username);
                command.Parameters.AddWithValue("@password", client.Password);
                command.Parameters.AddWithValue("@first_name", client.FirstName);
                command.Parameters.AddWithValue("@last_name", client.LastName);
                command.Parameters.AddWithValue("@phone_number", client.PhoneNumber);
                command.Parameters.AddWithValue("@email", client.Email);
                command.Parameters.AddWithValue("@can_be_recipe_creator", client.CanBeRecipeCreator);
                command.Parameters.AddWithValue("@client_id", client.ClientID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int UpdateRecipe(Recipe recipe)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "UPDATE RECIPE SET name = @name, description = @description, type = @type, price = @price, is_validated = @is_validated, "
                                            + "difficulty_level = @difficulty_level, for_nb_person = @for_nb_person, nb_step = @nb_step WHERE recipe_id = @recipe_id;";
                command.Parameters.AddWithValue("@name", recipe.Name);
                command.Parameters.AddWithValue("@description", recipe.Description);
                command.Parameters.AddWithValue("@type", recipe.Type);
                command.Parameters.AddWithValue("@price", recipe.Price);
                command.Parameters.AddWithValue("@is_validated", recipe.IsValidated);
                command.Parameters.AddWithValue("@difficulty_level", recipe.DifficultyLevel);
                command.Parameters.AddWithValue("@for_nb_person", recipe.ForNbPerson);
                command.Parameters.AddWithValue("@nb_step", recipe.NbStep);
                command.Parameters.AddWithValue("@recipe_id", recipe.RecipeID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int UpdateRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "UPDATE IS_IN_CART_OF SET quantity = @quantity WHERE client_id = @client_id and recipe_id = @recipe_id";
                command.Parameters.AddWithValue("@quantity", e.Value);
                command.Parameters.AddWithValue("@client_id", buyer.ClientID.ToString());
                command.Parameters.AddWithValue("@recipe_id", e.Key.RecipeID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }


        /* 
         * DELETE queries
        */
        public int DeleteRecipe(Recipe recipe)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM RECIPE WHERE recipe_id = @recipe_id";
                command.Parameters.AddWithValue("@recipe_id", recipe.RecipeID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int DeleteRecipeInCartOf(Client buyer, Recipe recipe)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM IS_IN_CART_OF WHERE client_id = @client_id and recipe_id = @recipe_id";
                command.Parameters.AddWithValue("@client_id", buyer.ClientID.ToString());
                command.Parameters.AddWithValue("@recipe_id", recipe.RecipeID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int DeleteClient(Client client)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM CLIENT WHERE client_id = @client_id";
                command.Parameters.AddWithValue("@client_id", client.ClientID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

        public int DeleteCartOf(Client client)
        {
            using (MySqlConnection connection = new MySqlConnection(this.connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = "DELETE FROM IS_IN_CART_OF WHERE client_id = @client_id";
                command.Parameters.AddWithValue("@client_id", client.ClientID.ToString());
                return command.ExecuteNonQuery();

            } // Connection gets closed here
        }

    }
}
