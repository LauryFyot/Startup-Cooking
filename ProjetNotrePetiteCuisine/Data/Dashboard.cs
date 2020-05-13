using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNotrePetiteCuisine.Data
{
    public class Dashboard
    {

        public RecipeCreator BestRecipeCreatorOfWeek { get; } // Could be null
        public Recipe FirstRecipe { get; } // Could be null
        public Recipe SecondRecipe { get; } // Could be null
        public Recipe ThirdRecipe { get; } // Could be null
        public Recipe FourthRecipe { get; } // Could be null
        public Recipe FifthRecipe { get; } // Could be null
        public RecipeCreator BestRecipeCreator { get; } // Could be null
        public Recipe FirstRecipeOfBestRC { get; } // Could be null
        public Recipe SecondRecipeOfBestRC { get; } // Could be null
        public Recipe ThirdRecipeOfBestRC { get; } // Could be null
        public Recipe FourthRecipeOfBestRC { get; } // Could be null
        public Recipe FifthRecipeOfBestRC { get; } // Could be null

        public Dashboard(RecipeCreator bestRecipeCreatorOfWeek,
            Recipe firstRecipe,
            Recipe secondRecipe,
            Recipe thirdRecipe,
            Recipe fourthRecipe,
            Recipe fifthRecipe,
            RecipeCreator bestRecipeCreator,
            Recipe firstRecipeOfBestRC,
            Recipe secondRecipeOfBestRC,
            Recipe thirdRecipeOfBestRC,
            Recipe fourthRecipeOfBestRC,
            Recipe fifthRecipeOfBestRC)
        {
            this.BestRecipeCreatorOfWeek = bestRecipeCreatorOfWeek;
            this.FirstRecipe = firstRecipe;
            this.SecondRecipe = secondRecipe;
            this.ThirdRecipe = thirdRecipe;
            this.FourthRecipe = fourthRecipe;
            this.FifthRecipe = fifthRecipe;
            this.BestRecipeCreator = bestRecipeCreator;
            this.FirstRecipeOfBestRC = firstRecipeOfBestRC;
            this.SecondRecipeOfBestRC = secondRecipeOfBestRC;
            this.ThirdRecipeOfBestRC = thirdRecipeOfBestRC;
            this.FourthRecipeOfBestRC = fourthRecipeOfBestRC;
            this.FifthRecipeOfBestRC = fifthRecipeOfBestRC;
        }

        public List<Recipe> GetRecipesOfTheWeek()
        {
            List<Recipe> recipes = new List<Recipe>();
            if (FirstRecipe!=null)
            {
                recipes.Add(FirstRecipe);
                if (SecondRecipe!=null)
                {
                    recipes.Add(SecondRecipe);
                    if (ThirdRecipe!=null)
                    {
                        recipes.Add(ThirdRecipe);
                        if (FourthRecipe!=null)
                        {
                            recipes.Add(FourthRecipe);
                            if (FifthRecipe!=null)
                            {
                                recipes.Add(FifthRecipe);
                            }
                        }
                    }
                }

            }
            return recipes;
        }

        public List<Recipe> GetRecipesOfBestRC()
        {
            List<Recipe> recipes = new List<Recipe>();
            if (FirstRecipeOfBestRC != null)
            {
                recipes.Add(FirstRecipeOfBestRC);
                if (SecondRecipeOfBestRC != null)
                {
                    recipes.Add(SecondRecipeOfBestRC);
                    if (ThirdRecipeOfBestRC != null)
                    {
                        recipes.Add(ThirdRecipeOfBestRC);
                        if (FourthRecipeOfBestRC != null)
                        {
                            recipes.Add(FourthRecipeOfBestRC);
                            if (FifthRecipeOfBestRC != null)
                            {
                                recipes.Add(FifthRecipeOfBestRC);
                            }
                        }
                    }
                }

            }
            return recipes;
        }
    }
}
