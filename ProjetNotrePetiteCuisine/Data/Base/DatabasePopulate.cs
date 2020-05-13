using NUnit.Framework;
using ProjetNotrePetiteCuisine.GUI.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetNotrePetiteCuisine.Data.Base
{
    public class DatabasePopulate
    {
        public static void Initialize(Database database, DatabasePopulateProgressBar progressBar, bool populateDatabase)
        {
            Console.WriteLine("\nCheck if Tables, Triggers, Events are created and Database is populated...");
            progressBar.ChangeStepTitle("Check if Tables, Triggers, Events are created and Database is populated...");
            if (populateDatabase) // If some Sql objects is missing or If user want to Clean then Populate Database
            {
                DatabasePopulate.CleanThenPopulate(database, progressBar);
            }
                else
            {
                Console.WriteLine("The database is already configured !\n");
                progressBar.ChangeStepTitle("The database is already configured !");
            }
            progressBar.ReportMaxProgress();
        }

        public static void CleanThenPopulate(Database database, DatabasePopulateProgressBar progressBar) // Catch Exceptions from this method in Popup !
        {
            Console.WriteLine("\nStart to populate Database and run Unit Tests !");
            progressBar.ChangeStepTitle("Start to populate Database and run Unit Tests !");

            // Initialize Database
            Console.WriteLine(" - Drop then Create tables...");
            progressBar.ChangeStepTitle("Drop then Create tables...");
            database.DropThenCreateTables();
            Console.WriteLine(" - Tables successfuly created !");
            progressBar.ChangeStepTitle("Tables successfuly created !");

            Console.WriteLine(" - Drop then Create triggers...");
            progressBar.ChangeStepTitle("Drop then Create triggers...");
            database.DropThenCreateTriggers();
            Console.WriteLine(" - Triggers successfuly created !");
            progressBar.ChangeStepTitle("Triggers successfuly created !");

            Console.WriteLine(" - Drop then Create events...");
            progressBar.ChangeStepTitle("Drop then Create events...");
            database.DropThenCreateEvents();
            Console.WriteLine(" - Events successfuly created !");
            progressBar.ChangeStepTitle("Events successfuly created !");

            // Test SELECT on empty Recipe table
            Console.WriteLine(" - Test SELECT on empty Recipe table...");
            progressBar.ChangeStepTitle("Test SELECT on empty Recipe table...");
            Assert.AreEqual(0, database.GetValidRecipesOrderByName().Count);
            Console.WriteLine(" - GetValidRecipesOrderByName() is OK on empty Table !");
            progressBar.ChangeStepTitle("GetValidRecipesOrderByName() is OK on empty Table !");

            // Test SELECT on empty Product table
            Console.WriteLine(" - Test SELECT on empty Product table...");
            progressBar.ChangeStepTitle("Test SELECT on empty Product table...");
            Assert.AreEqual(0, database.GetAllProducts().Count);
            Console.WriteLine(" - GetAllProducts() is OK on empty Table !");
            progressBar.ChangeStepTitle("GetAllProducts() is OK on empty Table !");

            // Test SELECT on Dashboard table
            Console.WriteLine(" - SELECT on Dashboard table...");
            progressBar.ChangeStepTitle("SELECT on Dashboard table...");
            Dashboard dashboard1 = database.GetDashboard();
            Assert.IsNotNull(dashboard1);
            Console.WriteLine(" - GetDashboard() is OK !");
            progressBar.ChangeStepTitle("GetDashboard() is OK !");

            /*
             * INSERT
             */
            // Create Admin
            Admin root = new Admin("root", "root", "root", "root", "0600000000", "");
            Console.WriteLine(" - Test INSERT Admin...");
            progressBar.ChangeStepTitle("Test INSERT Admin...");
            int adminInserted = database.InsertClientAsAdmin(root);
            Assert.AreEqual(2, adminInserted); // Here we check the number of ADMIN inserted is OK !
            Console.WriteLine(" - InsertAdmin(Admin admin) is Ok ! Number of ADMIN inserted {0}", adminInserted);
            progressBar.ChangeStepTitle("InsertAdmin(Admin admin) is Ok ! Number of ADMIN inserted " + adminInserted);

            // Create RecipeCreators
            Console.WriteLine(" - INSERT some RECIPE_CREATOR...");
            progressBar.ChangeStepTitle("INSERT some RECIPE_CREATOR...");
            RecipeCreator recipeCreator1 = new RecipeCreator("Laury", "Laury", "Laury", "Fyot-Tamadon", "0654897512", "lauryf@mail.com");
            RecipeCreator recipeCreator2 = new RecipeCreator("Yani", "Yani", "Yani", "Ferhaoui", "0654478921", "yanif@mail.com");
            RecipeCreator recipeCreator3 = new RecipeCreator("Alexandre", "Alexandre", "Alexandre", "Petit", "0659781423", "alexpetit@mail.com");
            RecipeCreator recipeCreator4 = new RecipeCreator("Antoine", "Antoine", "Antoine", "Legendre", "0632157437", "antoineleg@mail.com");
            RecipeCreator recipeCreator5 = new RecipeCreator("Remy", "Remy", "Remy", "Grandin", "0659781235", "remygrandinh@mail.com");
            RecipeCreator recipeCreator6 = new RecipeCreator("Mark23", "Mark23", "Mark", "Gerard", "0623231473", "markoiu@mail.com");
            RecipeCreator recipeCreator7 = new RecipeCreator("Lisa77", "Lisa77", "Lisa", "Boutille", "0689914535", "lisaboutille@mail.com");
            RecipeCreator recipeCreator8 = new RecipeCreator("Fathia75", "Fathia75", "Fathia", "Ferhaoui", "0675481265", "fathiaret@mail.com");
            RecipeCreator recipeCreator9 = new RecipeCreator("Emilie", "Emilie", "Emilie", "Laillot", "0623061504", "mymy@mail.com");
            RecipeCreator recipeCreator10 = new RecipeCreator("André94", "André94", "André", "Laillot", "0603459890", "adretar@mail.com");
            RecipeCreator recipeCreator11 = new RecipeCreator("Roberto", "Roberto", "Robert", "Boulanger", "0697450232", "robertboulanger@mail.com");
            RecipeCreator recipeCreator12 = new RecipeCreator("Christine", "Christine", "Christine", "Fenouille", "0632030332", "christinefen@mail.com");
            RecipeCreator recipeCreator13 = new RecipeCreator("Jean-BaptisteLR", "Jean-BaptisteLR", "Jean-Baptiste", "Le Roi", "0687542160", "jbleroi@mail.com");

            int recipeCreatorInserted = database.InsertClientAsRecipeCreator(recipeCreator1);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator2);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator3);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator4);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator5);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator6);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator7);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator8);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator9);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator10);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator11);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator12);
            recipeCreatorInserted += database.InsertClientAsRecipeCreator(recipeCreator13);
            Assert.AreEqual(26, recipeCreatorInserted); // Here we check the number of RECIPE_CREATOR inserted is OK !
            Console.WriteLine(" - InsertRecipeCreator(RecipeCreator recipeCreator) is Ok ! Number of RECIPE_CREATOR inserted {0}", recipeCreatorInserted);
            progressBar.ChangeStepTitle("InsertRecipeCreator(RecipeCreator recipeCreator) is Ok ! Number of RECIPE_CREATOR inserted " + recipeCreatorInserted);

            // Create Clients
            Console.WriteLine(" - INSERT some CLIENT...");
            progressBar.ChangeStepTitle("INSERT some CLIENT...");
            Client client1 = new Client("Pascalou", "Pascal", "Pascal", "Ferhaoui", "0654789523", "pasclou@mail.com");
            Client client2 = new Client("Romainou", "Romain", "Romain", "François", "0654712032", "raminf@mail.com");
            Client client3 = new Client("Manon23", "Manon23", "Manon", "Lapinte", "0632785142", "manonlapintte@mail.com");
            Client client4 = new Client("Cyrilo", "Cyrilo", "Cyril", "Feraudet", "0632427584", "cferaudet@mail.com");
            Client client5 = new Client("Diana75", "Diana75", "Diana", "Zeller", "0632568972", "dianaz@mail.com");
            Client client6 = new Client("Max", "Max", "Max", "Shiman", "0645725158", "maxsh@mail.com");
            Client client7 = new Client("Anna", "Anna", "Anna", "Petit", "0632147898", "annapetit@mail.com");
            Client client8 = new Client("Julia15", "Julia15", "Julia", "Ledoc", "0745239581", "julialed@mail.com");
            Client client9 = new Client("Julie", "Julie", "Julie", "Louer", "0632148695", "julielouer@mail.com");
            Client client10 = new Client("Chicken456", "Chicken456", "Jules", "Nérisson", "0632020212", "julesnerisson@mail.com");
            Client client11 = new Client("Jules", "Jules", "Jules", "Mayet", "0632011489", "julesmay@mail.com");
            Client client12 = new Client("Morgan12", "Morgan12", "Morgan", "Le Mouel", "0623780426", "molemou@mail.com");
            Client client13 = new Client("Maxime", "Maxime", "Maxime", "Rimbault", "0623054526", "maxrimb@mail.com");
            Client client14 = new Client("Lorris89", "Lorris89", "Lorris", "Shiffler", "0623158910", "lorrissh@mail.com");
            Client client15 = new Client("Martin", "Martin", "Martin", "Fourcade", "0651230215", "martinfourcade@mail.com");
            Client client16 = new Client("Ashleigh", "Ashleigh", "Ashleigh", "Barty", "0232568915", "ashbarty@mail.com");
            Client client17 = new Client("Simona", "Simona", "Simona", "Halep", "0623560215", "simonahalep@mail.com");
            Client client18 = new Client("Karolina", "Karolina", "Karolina", "Pliskova", "0615897441", "karo@mail.com");
            Client client19 = new Client("Sofia75", "Sofia", "Sofia", "Kenin", "0745261519", "sofiakenin@mail.com");
            Client client20 = new Client("Elina", "Elina", "Elina", "Svitolina", "0745125689", "elinasvet@mail.com");

            int clientInserted = database.InsertClient(client1);
            clientInserted += database.InsertClient(client2);
            clientInserted += database.InsertClient(client3);
            clientInserted += database.InsertClient(client4);
            clientInserted += database.InsertClient(client5);
            clientInserted += database.InsertClient(client6);
            clientInserted += database.InsertClient(client7);
            clientInserted += database.InsertClient(client8);
            clientInserted += database.InsertClient(client9);
            clientInserted += database.InsertClient(client10);
            clientInserted += database.InsertClient(client11);
            clientInserted += database.InsertClient(client12);
            clientInserted += database.InsertClient(client13);
            clientInserted += database.InsertClient(client14);
            clientInserted += database.InsertClient(client15);
            clientInserted += database.InsertClient(client16);
            clientInserted += database.InsertClient(client17);
            clientInserted += database.InsertClient(client18);
            clientInserted += database.InsertClient(client19);
            clientInserted += database.InsertClient(client20);
            Assert.AreEqual(20, clientInserted); // Here we check the number of CLIENT inserted is OK !
            Console.WriteLine(" - InsertClient(Client client) is Ok ! Number of CLIENT inserted {0}", clientInserted);
            progressBar.ChangeStepTitle("InsertClient(Client client) is Ok ! Number of CLIENT inserted " + clientInserted);

            // Create Suppliers
            Console.WriteLine(" - INSERT some SUPPLIER...");
            progressBar.ChangeStepTitle("INSERT some SUPPLIER...");
            Supplier supplier1 = new Supplier("Metro", "0605378110");
            Supplier supplier2 = new Supplier("CDiscount", "0605378110");
            Supplier supplier3 = new Supplier("Alibaba", "0605378110");
            Supplier supplier4 = new Supplier("Amazon", "0605378110");

            int supplierInserted = database.InsertSupplier(supplier1);
            supplierInserted += database.InsertSupplier(supplier2);
            supplierInserted += database.InsertSupplier(supplier3);
            supplierInserted += database.InsertSupplier(supplier4);
            Assert.AreEqual(4, supplierInserted); // Here we check the number of SUPPLIER inserted is OK !
            Console.WriteLine(" - InsertSupplier(Supplier supplier) is Ok ! Number of SUPPLIER inserted {0}", supplierInserted);
            progressBar.ChangeStepTitle("InsertSupplier(Supplier supplier) is Ok ! Number of SUPPLIER inserted " + supplierInserted);

            // Create Products
            Console.WriteLine(" - INSERT some PRODUCT...");
            progressBar.ChangeStepTitle("INSERT some PRODUCT...");
            Product product1 = new Product("Pâtes", "sec", "gramme", supplier1);
            Product product2 = new Product("Fromage", "frais", "gramme", supplier1);
            Product product3 = new Product("Aubergine", "frais", "gramme", supplier1);
            Product product4 = new Product("Tomates", "frais", "gramme", supplier1);
            Product product5 = new Product("Salade", "frais", "pièce", supplier1);
            Product product6 = new Product("Courgette", "frais", "pièce", supplier1);
            Product product7 = new Product("Banane", "frais", "gramme", supplier1);
            Product product8 = new Product("Pomme", "frais", "gramme", supplier2);
            Product product9 = new Product("Avocat", "frais", "gramme", supplier2);
            Product product10 = new Product("Sardine", "sec", "gramme", supplier2);
            Product product11 = new Product("Beurre", "frais", "gramme", supplier2);
            Product product12 = new Product("Huile", "sec", "gramme", supplier2);
            Product product13 = new Product("Epices", "sec", "gramme", supplier2);
            Product product14 = new Product("Poulet", "frais", "gramme", supplier2);
            Product product15 = new Product("Boeuf", "frais", "gramme", supplier3);
            Product product16 = new Product("Porc", "frais", "gramme", supplier3);
            Product product17 = new Product("Fraise", "frais", "gramme", supplier3);
            Product product18 = new Product("Lentille", "sec", "gramme", supplier3);
            Product product19 = new Product("Pomme de Terre", "sec", "gramme", supplier3);
            Product product20 = new Product("Haricots verts", "sec", "gramme", supplier3);
            Product product21 = new Product("Farine", "sec", "gramme", supplier3);
            Product product22 = new Product("Semoule", "sec", "gramme", supplier4);
            Product product23 = new Product("Olive", "sec", "gramme", supplier4);
            Product product24 = new Product("Riz", "sec", "gramme", supplier4);
            Product product25 = new Product("Sucre", "sec", "gramme", supplier4);
            Product product26 = new Product("Sel", "sec", "gramme", supplier4);
            Product product27 = new Product("Poivre", "sec", "gramme", supplier4);
            Product product28 = new Product("Vinaigre", "sec", "gramme", supplier4);

            int productInserted = database.InsertProduct(product1);
            productInserted += database.InsertProduct(product2);
            productInserted += database.InsertProduct(product3);
            productInserted += database.InsertProduct(product4);
            productInserted += database.InsertProduct(product5);
            productInserted += database.InsertProduct(product6);
            productInserted += database.InsertProduct(product7);
            productInserted += database.InsertProduct(product8);
            productInserted += database.InsertProduct(product9);
            productInserted += database.InsertProduct(product10);
            productInserted += database.InsertProduct(product11);
            productInserted += database.InsertProduct(product12);
            productInserted += database.InsertProduct(product13);
            productInserted += database.InsertProduct(product14);
            productInserted += database.InsertProduct(product15);
            productInserted += database.InsertProduct(product16);
            productInserted += database.InsertProduct(product17);
            productInserted += database.InsertProduct(product18);
            productInserted += database.InsertProduct(product19);
            productInserted += database.InsertProduct(product20);
            productInserted += database.InsertProduct(product21);
            productInserted += database.InsertProduct(product22);
            productInserted += database.InsertProduct(product23);
            productInserted += database.InsertProduct(product24);
            productInserted += database.InsertProduct(product25);
            productInserted += database.InsertProduct(product26);
            productInserted += database.InsertProduct(product27);
            productInserted += database.InsertProduct(product28);
            Assert.AreEqual(28, productInserted); // Here we check the number of PRODUCT inserted is OK !
            Console.WriteLine(" - InsertProduct(Product product) is Ok ! Number of PRODUCT inserted {0}", productInserted);
            progressBar.ChangeStepTitle("InsertProduct(Product product) is Ok ! Number of PRODUCT inserted " +  productInserted);

            // Create Recipes
            Console.WriteLine(" - INSERT some RECIPE...");
            progressBar.ChangeStepTitle("INSERT some RECIPE...");
            Recipe recipe1 = new Recipe("Chili Con Carne", "Une recette bien parfumée aux épices, originaire du sud des Etats-Unis, du Texas. Ce plat permet de voyager sans bouger de chez soi.",
                "Plat", 25, 3, 4, 4, recipeCreator1, 0, 2, true);
            Recipe recipe2 = new Recipe("Mafé de légumes", "Découvrez la version vegan du fleuron de la cuisine sénégalaise.",
                "Plat", 20, 3, 2, 5, recipeCreator1, 0, 2, true);
            Recipe recipe3 = new Recipe("Pot-au-Feu", "Quoi de plus réconfortant et de plus convivial que ce cultissime assortiment de viandes et de légumes du marché ?",
                "Plat", 27, 4, 4, 6, recipeCreator1, 0, 2, true);
            Recipe recipe4 = new Recipe("Blanquette de Veau", "Découvrez la recette de la Blanquette de veau traditionnelle, un classique du terroir qui fait l'unanimité à chaque bouchée. Servir avec de bonnes pâtes fraîches ou du riz blanc.",
                "Plat", 28, 4, 4, 7, recipeCreator1, 0, 2, true);
            Recipe recipe5 = new Recipe("Mug Cake", "Gateau minute et rapide",
                "Dessert", 10, 1, 1, 2, recipeCreator2, 0, 2, true);
            Recipe recipe6 = new Recipe("Crumble aux pommes", "Grand classique des dessert aux pommes foncdantes.",
                "Dessert", 12, 2, 4, 5, recipeCreator2, 0, 2, true);
            Recipe recipe7 = new Recipe("Crevettes sautées à la Vodka", "Une entrée originale, que pour les grands !",
                "Entrée", 17, 2, 1, 7, recipeCreator2, 0, 2, true);
            Recipe recipe8 = new Recipe("Velouté de Champignons", "Délicieuse soupe chaude et réconfortante pour réchauffer vos soirées !",
                "Entrée", 20, 2, 2, 8, recipeCreator2, 0, 2, true);
            Recipe recipe9 = new Recipe("Lapin au cidre", "Une recette classique de lapin. Un plat gouteux pour le bonheur de tous",
                "Plat", 29, 4, 4, 12, recipeCreator3, 0, 2, true);
            Recipe recipe10 = new Recipe("Chaussons thon tomate mozzarella", "Découvrez de délicieux chausson tout juste dorés. D'une facilité déconcertante.",
                "Entrée", 17, 2, 4, 5, recipeCreator3, 0, 2, true);
            Recipe recipe11 = new Recipe("Gratin de chou-fleur tradition", "Le grand classique du gratin pour les amoureux de choux-fleurs",
                "Plat", 20, 1, 4, 4, recipeCreator3, 0, 2, true);
            Recipe recipe12 = new Recipe("Cookies moelleux aux pépites de chocolat", "Trop bon ! Aucune chance de résister à la tentation. ",
                "Dessert", 15, 1, 2, 6, recipeCreator3, 0, 2, true);
            Recipe recipe13 = new Recipe("Riz à l'espagnole", "Le meilleur riz à l'espagnole.",
                "Plat", 25, 2, 2, 5, recipeCreator4, 0, 2, true);
            Recipe recipe14 = new Recipe("Riz au lait ", "Découvrez la recette de riz au lait, une recette parfumée, bien crémeuse et facile à faire pour faire chavirer les papilles de vos convives qui en redemanderont.",
                "Dessert", 20, 3, 4, 6, recipeCreator4, 0, 2, true);
            Recipe recipe15 = new Recipe("Pâtes carbonara", "La vraie recette italienne de la pasta alla carbonara, c'est-à-dire sans crème et... très crémeuse, au demeurant ! Miam, à table !",
                "Plat", 15, 1, 4, 4, recipeCreator4, 0, 2, true);
            Recipe recipe16 = new Recipe("Accras ", "Le grand classique de la cuisine portugaise !",
                "Entrée", 20, 2, 4, 12, recipeCreator4, 0, 2, true);
            Recipe recipe17 = new Recipe("Béchamel rapide et facile", "Pour accompagner tous vos gratins !",
                "Plat", 15, 4, 4, 7, recipeCreator5, 0, 2, true);
            Recipe recipe18 = new Recipe("Boeuf bourguignon", "Découvrez cette recette de boeuf bourguignon facile à préparer en cocotte.",
                "Plat", 28, 5, 4, 15, recipeCreator5, 0, 2, true);
            Recipe recipe19 = new Recipe("Aligot à l'ancienne", "Le solide plat d'hiver !",
                "Plat", 22, 2, 4, 13, recipeCreator5, 0, 2, true);
            Recipe recipe20 = new Recipe("Asperges blanches à la Flamande", "Petit retour en enfance chaque fois que je prépare cette recette, spécialité de la Flandre pour être précise, que ma maman m'a apprise à cuisiner.",
                "Entrée", 15, 2, 2, 5, recipeCreator5, 0, 2, true);
            Recipe recipe21 = new Recipe("Apple pie à l'ancienne", "Je suis retombée en enfance ! Ma mummy nous en faisait très souvent ! ",
                "Dessert", 10, 3, 5, 6, recipeCreator6, 0, 2, true);
            Recipe recipe22 = new Recipe("Artichauts rôtis à l’huile d’olive", "De délicieux artichauts rôtis ! C'est un régal !",
                "Plat", 16, 2, 2, 10, recipeCreator6, 0, 2, true);
            Recipe recipe23 = new Recipe("Tamquam", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator6, 0, 2, true);
            Recipe recipe24 = new Recipe("Inposito erexit", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator6, 0, 2, true);
            Recipe recipe25 = new Recipe("Ex tot timeri", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator7, 0, 2, true);
            Recipe recipe26 = new Recipe("Numinis appellamus", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator7, 0, 2, true);
            Recipe recipe27 = new Recipe("Dolorum Anazarbus", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator7, 0, 2, true);
            Recipe recipe28 = new Recipe("Pamicos regnum", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator7, 0, 2, true);
            Recipe recipe29 = new Recipe("Periret perferens", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator8, 0, 2, true);
            Recipe recipe30 = new Recipe("Periculi urbis per", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator8, 0, 2, true);
            Recipe recipe31 = new Recipe("Dicendi quadam", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator8, 0, 2, true);
            Recipe recipe32 = new Recipe("Sed ad causa", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator8, 0, 2, true);
            Recipe recipe33 = new Recipe("Inpegit suam flagitaret veterem", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator9, 0, 2, true);
            Recipe recipe34 = new Recipe("Cohorte", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator9, 0, 2, true);
            Recipe recipe35 = new Recipe("Et patens vero", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator9, 0, 2, true);
            Recipe recipe36 = new Recipe("Dispexerint impetraverint", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator9, 0, 2, true);
            Recipe recipe37 = new Recipe("Labores", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator10, 0, 2, true);
            Recipe recipe38 = new Recipe("Quarto lapide", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator10, 0, 2, true);
            Recipe recipe39 = new Recipe("In mortuorum", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator10, 0, 2, true);
            Recipe recipe40 = new Recipe("Ut anteponas", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator10, 0, 2, true);
            Recipe recipe41 = new Recipe("Eusebium", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator11, 0, 2, true);
            Recipe recipe42 = new Recipe("Percita foedere maxime", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator11, 0, 2, true);
            Recipe recipe43 = new Recipe("Oppigneratos", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator11, 0, 2, true);
            Recipe recipe44 = new Recipe("Ita reducti intra", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator11, 0, 2, true);
            Recipe recipe45 = new Recipe("Ignoti vero ad observantes", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator12, 0, 2, true);
            Recipe recipe46 = new Recipe("Igitur vocabulis", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator12, 0, 2, true);
            Recipe recipe47 = new Recipe("Diversa semper", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator12, 0, 2, true);
            Recipe recipe48 = new Recipe("Istam M esse", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator12, 0, 2, true);
            Recipe recipe49 = new Recipe("Diligentiores omnis", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator12, 0, 2, true);
            Recipe recipe50 = new Recipe("Feris ad iactitabant", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator13, 0, 2, true);
            Recipe recipe51 = new Recipe("Et omnes neque", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator13, 0, 2, true);
            Recipe recipe52 = new Recipe("Statuas et aeternitati", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator13, 0, 2, true);
            Recipe recipe53 = new Recipe("Romae qua inanes", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator13, 0, 2, true);
            Recipe recipe54 = new Recipe("Vatis quem quem vocabulume", "Classique parmi les classiques, les coquillettes au beurre pour les petits et les grands. Ce qui prime c'est la qualité des pâtes. Simplement assaisonnées avec du beurre et du fromage rapé, vous allez fondre.",
                "Plat", 15, 4, 4, 4, recipeCreator13, 0, 2, true);

            // Add some Products to Recipes
            recipe1.Products.Add(product1, 2);
            recipe2.Products.Add(product2, 2);
            recipe3.Products.Add(product3, 2);
            recipe4.Products.Add(product4, 2);
            recipe5.Products.Add(product5, 2);
            recipe6.Products.Add(product6, 2);
            recipe7.Products.Add(product7, 2);
            recipe8.Products.Add(product8, 2);
            recipe9.Products.Add(product9, 2);
            recipe10.Products.Add(product10, 2);
            recipe11.Products.Add(product11, 2);
            recipe12.Products.Add(product12, 2);
            recipe13.Products.Add(product13, 2);
            recipe14.Products.Add(product14, 2);
            recipe15.Products.Add(product15, 2);
            recipe16.Products.Add(product16, 2);
            recipe17.Products.Add(product17, 2);
            recipe18.Products.Add(product18, 2);
            recipe19.Products.Add(product19, 2);
            recipe20.Products.Add(product20, 2);
            recipe21.Products.Add(product21, 2);
            recipe22.Products.Add(product22, 2);
            recipe23.Products.Add(product23, 2);
            recipe24.Products.Add(product24, 2);
            recipe25.Products.Add(product25, 2);
            recipe26.Products.Add(product26, 2);
            recipe27.Products.Add(product27, 2);
            recipe28.Products.Add(product28, 2);
            recipe29.Products.Add(product1, 2);
            recipe30.Products.Add(product2, 2);
            recipe31.Products.Add(product3, 2);
            recipe32.Products.Add(product4, 2);
            recipe33.Products.Add(product5, 2);
            recipe34.Products.Add(product6, 2);
            recipe35.Products.Add(product7, 2);
            recipe36.Products.Add(product8, 2);
            recipe37.Products.Add(product9, 2);
            recipe38.Products.Add(product10, 2);
            recipe39.Products.Add(product11, 2);
            recipe40.Products.Add(product12, 2);
            recipe41.Products.Add(product13, 2);
            recipe42.Products.Add(product14, 2);
            recipe43.Products.Add(product15, 2);
            recipe44.Products.Add(product16, 2);
            recipe45.Products.Add(product17, 2);
            recipe46.Products.Add(product18, 2);
            recipe47.Products.Add(product19, 2);
            recipe48.Products.Add(product20, 2);
            recipe49.Products.Add(product21, 2);
            recipe50.Products.Add(product22, 2);
            recipe51.Products.Add(product23, 2);
            recipe52.Products.Add(product24, 2);
            recipe53.Products.Add(product25, 2);
            recipe54.Products.Add(product26, 2);
            recipe1.Products.Add(product27, 2);
            recipe2.Products.Add(product28, 2);
            recipe3.Products.Add(product1, 2);
            recipe4.Products.Add(product2, 2);
            recipe5.Products.Add(product3, 2);
            recipe6.Products.Add(product4, 2);
            recipe7.Products.Add(product5, 2);
            recipe8.Products.Add(product6, 2);
            recipe9.Products.Add(product7, 2);
            recipe10.Products.Add(product8, 2);
            recipe11.Products.Add(product9, 2);
            recipe12.Products.Add(product10, 2);
            recipe13.Products.Add(product11, 2);
            recipe14.Products.Add(product12, 2);
            recipe15.Products.Add(product13, 2);
            recipe16.Products.Add(product14, 2);
            recipe17.Products.Add(product15, 2);
            recipe18.Products.Add(product16, 2);
            recipe19.Products.Add(product17, 2);
            recipe20.Products.Add(product18, 2);
            recipe21.Products.Add(product19, 2);
            recipe22.Products.Add(product20, 2);
            recipe23.Products.Add(product21, 2);
            recipe24.Products.Add(product22, 2);

            int recipeInserted = database.InsertRecipe(recipe1);
            recipeInserted += database.InsertRecipe(recipe2);
            recipeInserted += database.InsertRecipe(recipe3);
            recipeInserted += database.InsertRecipe(recipe4);
            recipeInserted += database.InsertRecipe(recipe5);
            recipeInserted += database.InsertRecipe(recipe6);
            recipeInserted += database.InsertRecipe(recipe7);
            recipeInserted += database.InsertRecipe(recipe8);
            recipeInserted += database.InsertRecipe(recipe9);
            recipeInserted += database.InsertRecipe(recipe10);
            recipeInserted += database.InsertRecipe(recipe11);
            recipeInserted += database.InsertRecipe(recipe12);
            recipeInserted += database.InsertRecipe(recipe13);
            recipeInserted += database.InsertRecipe(recipe14);
            recipeInserted += database.InsertRecipe(recipe15);
            recipeInserted += database.InsertRecipe(recipe16);
            recipeInserted += database.InsertRecipe(recipe17);
            recipeInserted += database.InsertRecipe(recipe18);
            recipeInserted += database.InsertRecipe(recipe19);
            recipeInserted += database.InsertRecipe(recipe20);
            recipeInserted += database.InsertRecipe(recipe21);
            recipeInserted += database.InsertRecipe(recipe22);
            recipeInserted += database.InsertRecipe(recipe23);
            recipeInserted += database.InsertRecipe(recipe24);
            recipeInserted += database.InsertRecipe(recipe25);
            recipeInserted += database.InsertRecipe(recipe26);
            recipeInserted += database.InsertRecipe(recipe27);
            recipeInserted += database.InsertRecipe(recipe28);
            recipeInserted += database.InsertRecipe(recipe29);
            recipeInserted += database.InsertRecipe(recipe30);
            recipeInserted += database.InsertRecipe(recipe31);
            recipeInserted += database.InsertRecipe(recipe32);
            recipeInserted += database.InsertRecipe(recipe33);
            recipeInserted += database.InsertRecipe(recipe34);
            recipeInserted += database.InsertRecipe(recipe35);
            recipeInserted += database.InsertRecipe(recipe36);
            recipeInserted += database.InsertRecipe(recipe37);
            recipeInserted += database.InsertRecipe(recipe38);
            recipeInserted += database.InsertRecipe(recipe39);
            recipeInserted += database.InsertRecipe(recipe40);
            recipeInserted += database.InsertRecipe(recipe41);
            recipeInserted += database.InsertRecipe(recipe42);
            recipeInserted += database.InsertRecipe(recipe43);
            recipeInserted += database.InsertRecipe(recipe44);
            recipeInserted += database.InsertRecipe(recipe45);
            recipeInserted += database.InsertRecipe(recipe46);
            recipeInserted += database.InsertRecipe(recipe47);
            recipeInserted += database.InsertRecipe(recipe48);
            recipeInserted += database.InsertRecipe(recipe49);
            recipeInserted += database.InsertRecipe(recipe50);
            recipeInserted += database.InsertRecipe(recipe51);
            recipeInserted += database.InsertRecipe(recipe52);
            recipeInserted += database.InsertRecipe(recipe53);
            recipeInserted += database.InsertRecipe(recipe54);
            Console.WriteLine(" - InsertRecipe(Recipe recipe) is Ok ! Number of RECIPE and HAS_PRODUCT inserted {0}", recipeInserted);
            progressBar.ChangeStepTitle("InsertRecipe(Recipe recipe) is Ok ! Number of RECIPE and HAS_PRODUCT inserted " + recipeInserted);

            // Create Orders
            Console.WriteLine(" - INSERT some ORDERTYPE...");
            progressBar.ChangeStepTitle("INSERT some ORDERTYPE...");
            OrderType order1 = new OrderType("7 rue de la volonté", "Paris", "75000", client1);
            OrderType order2 = new OrderType("24 rue de la caumonnerie", "le PFA", "77540", client1);
            OrderType order3 = new OrderType("83, rue Gouin de Beauchesne", "SAINT-PIERRE", "97410", client1);
            OrderType order4 = new OrderType("63, Place Charles de Gaulle", "PARIS", "75008", client1);
            OrderType order5 = new OrderType("29, rue de Lille", "ASNIÈRES-SUR-SEINE", "92600", client1);
            OrderType order6 = new OrderType("46, rue du Gue Jacquet", "CHÂTELLERAULT", "86100", client1);
            OrderType order7 = new OrderType("42, boulevard de Prague", "NOISY-LE-GRAND", "93160", client1);
            OrderType order8 = new OrderType("26, rue de la Boétie", "PLAISIR", "78370", client1);
            OrderType order9 = new OrderType("98, Place du Jeu de Paume", "VIENNE", "38200", client1);
            OrderType order10 = new OrderType("8, Place du Jeu de Paume", "VIERZON", "18100", client1);
            OrderType order11 = new OrderType("9, Boulevard de Normandie", "FONTAINE", "38600", client1);
            OrderType order12 = new OrderType("55, rue Victor Hugo", "COMPIÈGNE", "60200", client1);
            OrderType order13 = new OrderType("96, Cours Marechal-Joffre", "DAX", "40100", client1);
            OrderType order14 = new OrderType("14, rue de Raymond Poincaré", "NEUILLY-SUR-MARNE", "93330", client1);
            OrderType order15 = new OrderType("85, rue Goya", "LE PERREUX-SUR-MARNE", "94170", client1);
            OrderType order16 = new OrderType("17, Avenue des Tuileries", "GUYANCOURT", "78280", client1);
            OrderType order17 = new OrderType("14, boulevard de la Liberation", "PARIS", "75014", client1);
            OrderType order18 = new OrderType("4, rue Gustave Eiffel", "REZÉ", "44400", client1);
            OrderType order19 = new OrderType("60, rue de la République", "LUNÉVILLE", "54300", client1);
            OrderType order20 = new OrderType("35, boulevard Amiral Courbet", "OYONNAX", "01100", client1);
            OrderType order21 = new OrderType("81, Rue du Palais", "ÉTAMPES", "91150", client1);
            OrderType order22 = new OrderType("52, Faubourg Saint Honoré", "PARIS", "75116", client1);
            OrderType order23 = new OrderType("22, Chemin Du Lavarin Sud", "CACHAN", "94230", client1);
            OrderType order24 = new OrderType("94, Rue Joseph Vernet", "BAR-LE-DUC", "55000", client1);
            OrderType order25 = new OrderType("5, Chemin Du Lavarin Sud", "PARIS", "75000", client1);

            order1.Recipes.Add(recipe1, 2);
            order2.Recipes.Add(recipe2, 2);
            order3.Recipes.Add(recipe3, 2);
            order4.Recipes.Add(recipe4, 2);
            order5.Recipes.Add(recipe5, 2);
            order6.Recipes.Add(recipe6, 2);
            order7.Recipes.Add(recipe7, 2);
            order8.Recipes.Add(recipe8, 2);
            order9.Recipes.Add(recipe9, 2);
            order10.Recipes.Add(recipe10, 2);
            order11.Recipes.Add(recipe11, 2);
            order12.Recipes.Add(recipe12, 2);
            order13.Recipes.Add(recipe13, 2);
            order14.Recipes.Add(recipe14, 2);
            order15.Recipes.Add(recipe15, 2);
            order16.Recipes.Add(recipe16, 2);
            order17.Recipes.Add(recipe17, 2);
            order18.Recipes.Add(recipe18, 2);
            order19.Recipes.Add(recipe19, 2);
            order20.Recipes.Add(recipe20, 2);
            order21.Recipes.Add(recipe21, 2);
            order22.Recipes.Add(recipe22, 2);
            order23.Recipes.Add(recipe23, 2);
            order24.Recipes.Add(recipe24, 2);
            order25.Recipes.Add(recipe25, 2);
            order1.Recipes.Add(recipe26, 2);
            order2.Recipes.Add(recipe27, 2);
            order3.Recipes.Add(recipe28, 2);
            order4.Recipes.Add(recipe29, 2);
            order5.Recipes.Add(recipe30, 2);
            order6.Recipes.Add(recipe31, 2);
            order7.Recipes.Add(recipe32, 2);
            order8.Recipes.Add(recipe33, 2);
            order9.Recipes.Add(recipe34, 2);
            order10.Recipes.Add(recipe35, 2);
            order11.Recipes.Add(recipe36, 2);
            order12.Recipes.Add(recipe37, 2);
            order13.Recipes.Add(recipe38, 2);
            order14.Recipes.Add(recipe39, 2);
            order15.Recipes.Add(recipe40, 2);
            order16.Recipes.Add(recipe41, 2);
            order17.Recipes.Add(recipe42, 2);
            order18.Recipes.Add(recipe43, 2);
            order19.Recipes.Add(recipe44, 2);

            int orderInserted = database.InsertOrder(client1, order1);
            orderInserted += database.InsertOrder(client2, order2);
            orderInserted += database.InsertOrder(client3, order3);
            orderInserted += database.InsertOrder(client4, order4);
            orderInserted += database.InsertOrder(client5, order5);
            orderInserted += database.InsertOrder(client6, order6);
            orderInserted += database.InsertOrder(client7, order7);
            orderInserted += database.InsertOrder(client8, order8);
            orderInserted += database.InsertOrder(client9, order9);
            orderInserted += database.InsertOrder(client10, order10);
            orderInserted += database.InsertOrder(client11, order11);
            orderInserted += database.InsertOrder(client12, order12);
            orderInserted += database.InsertOrder(client13, order13);
            orderInserted += database.InsertOrder(client14, order14);
            orderInserted += database.InsertOrder(client15, order15);
            orderInserted += database.InsertOrder(client16, order16);
            orderInserted += database.InsertOrder(client17, order17);
            orderInserted += database.InsertOrder(client18, order18);
            orderInserted += database.InsertOrder(client19, order19);
            Console.WriteLine(" - InsertOrder(Client buyer, OrderType orderType) is Ok ! Number of ORDERTYPE and IS_IN_ORDERTYPE inserted {0}", orderInserted);
            progressBar.ChangeStepTitle("InsertOrder(Client buyer, OrderType orderType) is Ok ! Number of ORDERTYPE and IS_IN_ORDERTYPE inserted {0}" + orderInserted);

            // Create IS_IN_CART_OF
            Console.WriteLine(" - INSERT some IS_IN_CART_OF...");
            progressBar.ChangeStepTitle("INSERT some IS_IN_CART_OF...");
            KeyValuePair<Recipe, int> isInCartOf1 = new KeyValuePair<Recipe, int>(recipe7, 1);
            KeyValuePair<Recipe, int> isInCartOf2 = new KeyValuePair<Recipe, int>(recipe8, 1);
            KeyValuePair<Recipe, int> isInCartOf3 = new KeyValuePair<Recipe, int>(recipe9, 1);
            KeyValuePair<Recipe, int> isInCartOf4 = new KeyValuePair<Recipe, int>(recipe10, 1);
            KeyValuePair<Recipe, int> isInCartOf5 = new KeyValuePair<Recipe, int>(recipe11, 1);
            KeyValuePair<Recipe, int> isInCartOf6 = new KeyValuePair<Recipe, int>(recipe12, 1);
            KeyValuePair<Recipe, int> isInCartOf7 = new KeyValuePair<Recipe, int>(recipe13, 1);
            KeyValuePair<Recipe, int> isInCartOf8 = new KeyValuePair<Recipe, int>(recipe14, 1);
            KeyValuePair<Recipe, int> isInCartOf9 = new KeyValuePair<Recipe, int>(recipe15, 1);
            KeyValuePair<Recipe, int> isInCartOf10 = new KeyValuePair<Recipe, int>(recipe16, 1);
            KeyValuePair<Recipe, int> isInCartOf11 = new KeyValuePair<Recipe, int>(recipe17, 1);
            KeyValuePair<Recipe, int> isInCartOf12 = new KeyValuePair<Recipe, int>(recipe18, 1);
            KeyValuePair<Recipe, int> isInCartOf13 = new KeyValuePair<Recipe, int>(recipe19, 1);
            KeyValuePair<Recipe, int> isInCartOf14 = new KeyValuePair<Recipe, int>(recipe20, 1);
            KeyValuePair<Recipe, int> isInCartOf15 = new KeyValuePair<Recipe, int>(recipe21, 1);
            KeyValuePair<Recipe, int> isInCartOf16 = new KeyValuePair<Recipe, int>(recipe22, 1);
            KeyValuePair<Recipe, int> isInCartOf17 = new KeyValuePair<Recipe, int>(recipe23, 1);
            KeyValuePair<Recipe, int> isInCartOf18 = new KeyValuePair<Recipe, int>(recipe24, 1);
            KeyValuePair<Recipe, int> isInCartOf19 = new KeyValuePair<Recipe, int>(recipe25, 1);
            KeyValuePair<Recipe, int> isInCartOf20 = new KeyValuePair<Recipe, int>(recipe26, 1);
            KeyValuePair<Recipe, int> isInCartOf21 = new KeyValuePair<Recipe, int>(recipe27, 1);

            int isInCartInserted = database.InsertRecipeInCartOf(client4, isInCartOf1);
            isInCartInserted += database.InsertRecipeInCartOf(client5, isInCartOf2);
            isInCartInserted += database.InsertRecipeInCartOf(client6, isInCartOf3);
            isInCartInserted += database.InsertRecipeInCartOf(client7, isInCartOf4);
            isInCartInserted += database.InsertRecipeInCartOf(client8, isInCartOf5);
            isInCartInserted += database.InsertRecipeInCartOf(client9, isInCartOf6);
            isInCartInserted += database.InsertRecipeInCartOf(client10, isInCartOf7);
            isInCartInserted += database.InsertRecipeInCartOf(client11, isInCartOf8);
            isInCartInserted += database.InsertRecipeInCartOf(client12, isInCartOf9);
            isInCartInserted += database.InsertRecipeInCartOf(client13, isInCartOf10);
            isInCartInserted += database.InsertRecipeInCartOf(client14, isInCartOf11);
            isInCartInserted += database.InsertRecipeInCartOf(client15, isInCartOf12);
            isInCartInserted += database.InsertRecipeInCartOf(client16, isInCartOf13);
            isInCartInserted += database.InsertRecipeInCartOf(client17, isInCartOf14);
            isInCartInserted += database.InsertRecipeInCartOf(client18, isInCartOf15);
            isInCartInserted += database.InsertRecipeInCartOf(client19, isInCartOf16);
            isInCartInserted += database.InsertRecipeInCartOf(client1, isInCartOf17);
            isInCartInserted += database.InsertRecipeInCartOf(client2, isInCartOf18);
            isInCartInserted += database.InsertRecipeInCartOf(client3, isInCartOf19);
            isInCartInserted += database.InsertRecipeInCartOf(client4, isInCartOf20);
            isInCartInserted += database.InsertRecipeInCartOf(client5, isInCartOf21);
            Assert.AreEqual(21, isInCartInserted); // Here we check the number of IS_IN_CART_OF inserted is OK !
            Console.WriteLine(" - InsertRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e) is Ok ! Number of IS_IN_CART_OF inserted {0}", isInCartInserted);
            progressBar.ChangeStepTitle("InsertRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e) is Ok ! Number of IS_IN_CART_OF inserted {0}" + isInCartInserted);

            /*
             * UPDATE
             */
             //Update Client
            Console.WriteLine(" - UPDATE some CLIENT...");
            progressBar.ChangeStepTitle("UPDATE some CLIENT...");
            client1.Username = "JB";
            client2.FirstName = "Adbel";
            client3.Email = "new.email@mail.com";
            client4.Password = "12345";

            int clientUpdated = database.UpdateClient(client1);
            clientUpdated += database.UpdateClient(client2);
            clientUpdated += database.UpdateClient(client3);
            clientUpdated += database.UpdateClient(client4);
            Assert.AreEqual(4, clientUpdated); // Here we check the number of CLIENT updated is OK !
            Console.WriteLine(" - UpdateClient(Client client) is Ok ! Number of CLIENT updated {0}", clientUpdated);
            progressBar.ChangeStepTitle("UpdateClient(Client client) is Ok ! Number of CLIENT updated {0}" + clientUpdated);

            // Update Recipe
            Console.WriteLine(" - UPDATE some RECIPE...");
            progressBar.ChangeStepTitle("UPDATE some RECIPE...");
            recipe1.ForNbPerson = 14;
            recipe2.DifficultyLevel = 1;
            recipe3.IsValidated = false;
            recipe4.Name = "New Name !!";

            int recipeUpdated = database.UpdateRecipe(recipe1);
            recipeUpdated += database.UpdateRecipe(recipe2);
            recipeUpdated += database.UpdateRecipe(recipe3);
            recipeUpdated += database.UpdateRecipe(recipe4);
            Assert.AreEqual(4, clientUpdated); // Here we check the number of RECIPE updated is OK !
            Console.WriteLine(" - UpdateRecipe(Recipe recipe) is Ok ! Number of RECIPE updated {0}", clientUpdated);
            progressBar.ChangeStepTitle("UpdateRecipe(Recipe recipe) is Ok ! Number of RECIPE updated {0}" + clientUpdated);

            // Update IS_IN_CART_OF
            Console.WriteLine(" - UPDATE some IS_IN_CART_OF...");
            progressBar.ChangeStepTitle("UPDATE some IS_IN_CART_OF...");
            KeyValuePair<Recipe, int> newIsInCartOf1 = new KeyValuePair<Recipe, int>(isInCartOf1.Key, 3);
            KeyValuePair<Recipe, int> newIsInCartOf2 = new KeyValuePair<Recipe, int>(isInCartOf2.Key, 6);
            KeyValuePair<Recipe, int> newIsInCartOf3 = new KeyValuePair<Recipe, int>(isInCartOf3.Key, 2);
            KeyValuePair<Recipe, int> newIsInCartOf4 = new KeyValuePair<Recipe, int>(isInCartOf4.Key, 2);

            int isInCartUpdated = database.UpdateRecipeInCartOf(client4, newIsInCartOf1); // To Update, Client and Recipe must be the same from the Insert
            isInCartUpdated += database.UpdateRecipeInCartOf(client5, newIsInCartOf2); // To Update, Client and Recipe must be the same from the Insert
            isInCartUpdated += database.UpdateRecipeInCartOf(client6, newIsInCartOf3); // To Update, Client and Recipe must be the same from the Insert
            isInCartUpdated += database.UpdateRecipeInCartOf(client7, newIsInCartOf4); // To Update, Client and Recipe must be the same from the Insert
            Assert.AreEqual(4, isInCartUpdated); // Here we check the number of IS_IN_CART_OF updated is OK !
            Console.WriteLine(" - UpdateRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e) is Ok ! Number of IS_IN_CART_OF updated {0}", isInCartUpdated);
            progressBar.ChangeStepTitle("UpdateRecipeInCartOf(Client buyer, KeyValuePair<Recipe, int> e) is Ok ! Number of IS_IN_CART_OF updated {0}" + isInCartUpdated);

            /*
             * DELETE
             */
             // Delete Client
            Console.WriteLine(" - DELETE 1 CLIENT...");
            progressBar.ChangeStepTitle("DELETE 1 CLIENT...");
            int clientDeleted = database.DeleteClient(client1);
            Assert.AreEqual(1, clientDeleted); // Here we check the number of CLIENT deleted is OK !
            Console.WriteLine(" - DeleteClient(Client client) is Ok ! Number of CLIENT deleted {0}", clientDeleted);
            progressBar.ChangeStepTitle("DeleteClient(Client client) is Ok ! Number of CLIENT deleted " + clientDeleted);

            // Delete Recipe
            Console.WriteLine(" - DELETE 1 RECIPE...");
            progressBar.ChangeStepTitle("DELETE 1 RECIPE...");
            int recipeDeleted = database.DeleteRecipe(recipe1);
            Assert.AreEqual(1, recipeDeleted); // Here we check the number of RECIPE deleted is OK !
            Console.WriteLine(" - DeleteRecipe(Recipe recipe) is Ok ! Number of RECIPE deleted {0}", recipeDeleted);
            progressBar.ChangeStepTitle("DeleteRecipe(Recipe recipe) is Ok ! Number of RECIPE deleted " + recipeDeleted);

            // Delete IS_IN_CART_OF
            Console.WriteLine(" - DELETE 1 IS_IN_CART_OF...");
            progressBar.ChangeStepTitle("DELETE 1 IS_IN_CART_OF...");
            int isInCartOfDeleted = database.DeleteRecipeInCartOf(client7, isInCartOf4.Key); // To Delete, Client and Recipe must be the same from the Insert
            Assert.AreEqual(1, isInCartOfDeleted); // Here we check the number of IS_IN_CART_OF deleted is OK !
            Console.WriteLine(" - DeleteRecipeInCartOf(Client buyer, Recipe recipe) is Ok ! Number of IS_IN_CART_OF deleted {0}", isInCartOfDeleted);
            progressBar.ChangeStepTitle("DeleteRecipeInCartOf(Client buyer, Recipe recipe) is Ok ! Number of IS_IN_CART_OF deleted " + isInCartOfDeleted);

            /*
             * SELECT
             */
             // Test Login
            Console.WriteLine(" - Login CLIENT...");
            progressBar.ChangeStepTitle("Login CLIENT...");
            Client client = database.Login(client14.Username, client14.Username); // In our example Password equals Username
            Console.WriteLine(" - CLIENT successfully login !");
            progressBar.ChangeStepTitle(" CLIENT successfully login !");

            // Test SELECT valid Recipes
            Console.WriteLine(" - Test SELECT valid Recipes...");
            progressBar.ChangeStepTitle("Test SELECT valid Recipes..");
            int validRecipes = database.GetValidRecipesOrderByName().Count;
            Assert.AreEqual(52, validRecipes);
            Console.WriteLine(" - GetValidRecipesOrderByName() is OK ! Number of valid Recipes: {0}", validRecipes);
            progressBar.ChangeStepTitle("GetValidRecipesOrderByName() is OK ! Number of valid Recipes: " + validRecipes);

            // Test SELECT not valid Recipes
            Console.WriteLine(" - Test SELECT not valid Recipes...");
            progressBar.ChangeStepTitle("Test SELECT not valid Recipes...");
            int notValidRecipes = database.GetNotValidRecipesOrderByName().Count;
            Assert.AreEqual(1, notValidRecipes);
            Console.WriteLine(" - GetNotValidRecipesOrderByName() is OK ! Number of not valid Recipes: {0}", notValidRecipes);
            progressBar.ChangeStepTitle("GetNotValidRecipesOrderByName() is OK ! Number of not valid Recipes: " + notValidRecipes);

            // Test SELECT Recipes of RecipeCreator
            Console.WriteLine(" - Test SELECT Recipes of RecipeCreator...");
            progressBar.ChangeStepTitle("Test SELECT Recipes of RecipeCreator...");
            int recipeOfRecipeCreator12 = database.GetRecipeOfRecipeCreator(recipeCreator12).Count;
            Assert.AreEqual(5, recipeOfRecipeCreator12);
            Console.WriteLine(" - GetRecipeOfRecipeCreator() is OK ! Number of Recipes: {0}", recipeOfRecipeCreator12);
            progressBar.ChangeStepTitle("GetRecipeOfRecipeCreator() is OK ! Number of Recipes: " + recipeOfRecipeCreator12);

            // Test Select Products
            Console.WriteLine(" - Test SELECT Products...");
            progressBar.ChangeStepTitle("Test SELECT Products...");
            int products = database.GetAllProducts().Count;
            Assert.AreEqual(28, products);
            Console.WriteLine(" - GetAllProducts() is OK ! Number of Products: {0}", products);
            progressBar.ChangeStepTitle("GetAllProducts() is OK ! Number of Products: " + products);

            // Test Select Orders of the last Week
            Console.WriteLine(" - Test SELECT Orders of the last Week...");
            progressBar.ChangeStepTitle("Test SELECT Orders of the last Week...");
            int ordersOfTheLastWeek = database.GetAllOrdersOfLastWeek().Count;
            Assert.AreEqual(18, ordersOfTheLastWeek);
            Console.WriteLine(" - GetAllOrdersOfLastWeek() is OK ! Number of Orders: {0}", ordersOfTheLastWeek);
            progressBar.ChangeStepTitle("GetAllOrdersOfLastWeek() is OK ! Number of Orders: " + ordersOfTheLastWeek);

            // Test Select Dashboard
            Console.WriteLine(" - Test SELECT Dashboard...");
            progressBar.ChangeStepTitle("Test SELECT Dashboard...");
            Dashboard dashboard2 = database.GetDashboard();
            Assert.IsNotNull(dashboard2);
            Console.WriteLine(" - GetDashboard() is OK !");
            progressBar.ChangeStepTitle("GetDashboard() is OK !");

            // The End
            Console.WriteLine("End of populate Database and Unit Tests !\n");
            progressBar.ChangeStepTitle("End of populate Database and Unit Tests !");
        }

    }
}
