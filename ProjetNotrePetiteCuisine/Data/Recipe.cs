using MySql.Data.MySqlClient;
using ProjetNotrePetiteCuisine.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ProjetNotrePetiteCuisine.Data
{
    [DataContract]
    public class Recipe : IComparable<Recipe>
    {
        [DataMember()]
        public Guid RecipeID { get; set; } // Do not change after Object creation

        [DataMember()]
        public string Name { get; set; }

        [DataMember()]
        public string Description { get; set; }

        [DataMember()]
        public string Type { get; set; }

        [DataMember()]
        public int Price { get; set; }

        [DataMember()]
        public int DifficultyLevel { get; set; }

        [DataMember()]
        public int ForNbPerson { get; set; }

        [DataMember()]
        public int NbStep { get; set; }

        [DataMember()]
        public int NbSolded { get; set; }

        [DataMember()]
        public int RecipeCreatorFees { get; set; }

        [DataMember()]
        public DateTime CreationDate { get; set; } // Do not change after Object creation

        [DataMember()]
        public DateTime ModificationDate { get; set; }

        [DataMember()]
        public bool IsValidated { get; set; }

        [DataMember()]
        public Guid RecipeCreatorID { get; set; } // Do not change after Object creation

        [DataMember()]
        public string RecipeCreatorUsername { get; set; } // Do not change after Object creation

        [DataMember()]
        public Dictionary<Product, int> Products { get; } // key = Product, value = quantity | Do not change after Object creation

        // Original Private Constructor called by others
        private Recipe(Guid recipeID, //
            string name, //
            string description, //
            string type, //
            int price, //
            int difficultyLevel, //
            int forNbPerson, //
            int nbStep, //
            int nbSolded, //
            int recipeCreatorFees, //
            DateTime creationDate, //
            DateTime modificationDate, //
            bool isValidated, //
            Guid recipeCreatorID, //
            string recipeCreatorUsername, //
            Dictionary<Product, int> products)
        {
            this.RecipeID = recipeID;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Price = price;
            this.DifficultyLevel = difficultyLevel;
            this.ForNbPerson = forNbPerson;
            this.NbStep = nbStep;
            this.NbSolded = nbSolded;
            this.RecipeCreatorFees = recipeCreatorFees;
            this.CreationDate = creationDate;
            this.ModificationDate = modificationDate;
            this.IsValidated = isValidated;
            this.RecipeCreatorID = recipeCreatorID;
            this.RecipeCreatorUsername = recipeCreatorUsername;
            this.Products = products;
        }

        // C# Constructor
        public Recipe(string name, //
            string description, //
            string type, //
            int price, //
            int difficultyLevel, //
            int forNbPerson, //
            int nbStep, //
            RecipeCreator recipeCreator, //
            int nbSolded = 0, //
            int recipeCreatorFees = 2, //
            bool isValidated = false) : //
            this(System.Guid.NewGuid(), //
                name, //
                description, //
                type, //
                price, //
                difficultyLevel, //
                forNbPerson, //
                nbStep, //
                nbSolded, // 
                recipeCreatorFees, //
                DateTime.Now, // creationDate
                DateTime.Now, // modificationDate
                isValidated, //
                recipeCreator.ClientID, //
                recipeCreator.Username, //
                new Dictionary<Product, int>())
        {
            //To have an understandable error
            if (this.Price < 10 || this.Price > 40)
            {
                throw new CookingException("Price must be between 10 and 40 !");
            }
            if (this.DifficultyLevel < 0 || this.DifficultyLevel > 5) 
            {
                throw new CookingException("Difficulty level must be between 0 and 5 !");
            }
            if (this.ForNbPerson <= 0)
            {
                throw new CookingException("The recipe must be for at least one person !");
            }
            if (this.NbStep <= 0)
            {
                throw new CookingException("The recipe must have at least one step !");
            }
        }

        // Database Constructor
        public Recipe(MySqlDataReader reader, Dictionary<Product, int> products) :
            this(
                reader.GetGuid("recipe_id"), //
                reader.GetString("name"), //
                reader.GetString("description"), //
                reader.GetString("type"), //
                reader.GetInt32("price"), //
                reader.GetInt32("difficulty_level"), //
                reader.GetInt32("for_nb_person"), //
                reader.GetInt32("nb_step"), //
                reader.GetInt32("nb_solded"), //
                reader.GetInt32("recipe_creator_fees"), //
                reader.GetDateTime("creation_date"), //
                reader.GetDateTime("modification_date"), //
                reader.GetBoolean("is_validated"), //
                reader.GetGuid("client_id"), // equals to recipe_creator_id
                reader.GetString("username"), //
                products)
        { }


        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(Recipe other)
        {
            return this.RecipeID.CompareTo(other.RecipeID);
        }
    }
}
