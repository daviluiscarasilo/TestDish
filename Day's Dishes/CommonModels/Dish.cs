using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonModels
{
	public class Dish
	{
		//Dictionary with the dishes types
		public Dictionary<DishType, string> Dishes { get; set; }

		//The current permitted repeat key dishe
		public int PermitedRepeatDishesKey { get; set; }

		//Enum with the kind of the dish
		public enum DishType { Entree = 1, Side = 2, Drink = 3, Dessert = 4 };

		//User Imput
		public List<string> InputDish = new List<string>();

        readonly Regex validInputs = new Regex(@"[1-4]+");

		public Dish(bool IsMornigDishe)
		{

			//Validate if the Dish is from the morning or not
			if (IsMornigDishe)
			{
				//Innitializing Dictionary with the keys and respective values from the morning dishes
				Dishes = new Dictionary<DishType, string>()
				{
					{DishType.Entree, "eggs"},
					{DishType.Side, "toast"},
					{DishType.Drink, "coffee"},
					{DishType.Dessert, "error"}
				};

				//Setting the current permitted repeat dish from the morning
				PermitedRepeatDishesKey = (int)DishType.Drink;

			}
			else
			{
				//Innitializing Dictionary with the keys and respective values from the night dishes
				Dishes = new Dictionary<DishType, string>()
				{
					{ DishType.Entree, "steak"},
					{ DishType.Side, "potato"},
					{ DishType.Drink, "wine"},
					{ DishType.Dessert, "cake"}
				};


				//Setting the current permitted repeat dish from the morning
				PermitedRepeatDishesKey = (int)DishType.Side;
			}
		}

		public string OutputDishes()
		{
			string FullOutput = "";

			if (InputDish.Any())
			{
                int count = -1;

                foreach (var dishType in Dishes)
				{
					//Auxiliary variables
					string ParseOutput = "";
					int repeat = 0;
					foreach (var dish in InputDish)
					{
						//Check the type with the dish and if the dish can be input more times
						if (Convert.ToInt32(dishType.Key) == Convert.ToInt32(dish) && Convert.ToInt32(dishType.Key) == PermitedRepeatDishesKey)
						{

                            //Set the Auxiliary variable with the name of the dish and valide if the same is inputed more on times
                            ParseOutput = repeat == 0 ? dishType.Value : dishType.Value + $"(x{repeat + 1})";

							repeat++;
                            count++;

                        }
						else if (Convert.ToInt32(dishType.Key) == Convert.ToInt32(dish))
						{
                            //Set the Auxiliary variable with the name of the dish and valide if the same is inputed more on times
                            ParseOutput = repeat == 0 ? string.Concat(" ", dishType.Value) : String.Concat(ParseOutput, ", error");

							repeat++;
                            count++;
                        }
					}

                    if (!String.IsNullOrEmpty(ParseOutput))
                        FullOutput += String.IsNullOrEmpty(FullOutput) ? ParseOutput : String.Concat(", ", ParseOutput);
                    else
                    {
                        try
                        {
                            if (!validInputs.Match(InputDish[count + 1]).Success)
                            {
                                FullOutput += String.IsNullOrEmpty(FullOutput) ? "error" : ", error";
                            }
                        }
                        catch (Exception){}

                    }

					if (ParseOutput.Contains("error"))
						return FullOutput;
				}
			}

			return FullOutput;
			
		}







	}
}
