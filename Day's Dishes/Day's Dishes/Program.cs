using CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_s_Dishes
{
	class Program
	{
		static void Main(string[] args)
		{
			//Create Variable for the user dishes input
			String input = "";

			Dish dish = null;

			do
			{
				Console.Clear();
				Console.Write("Input: ");

				//Get the input and to lower the letters
				input = Console.ReadLine().ToLower();

				//Vallidation with the input is not empty
				if (!String.IsNullOrEmpty(input))
				{

					//Innitiliazing the dish with the time of day Morning or Night or invalid input
					dish = input.Contains("morning") && !input.Contains("night") ? new Dish(true)
							: !input.Contains("morning") && input.Contains("night") ? new Dish(false)
							: null;

					//Validate the instance from the dish is valid
					if(dish != null)
					{
						//Remove white spaces
						input = input.Replace(" ", string.Empty);

						//Remove the time of the day from the input
						input = input.Replace("morning,", string.Empty).Replace("night,", string.Empty);

						//Parse a input and set de InputDish property from Dish object
						dish.InputDish = input.Split(',')?.ToList();

						Console.WriteLine($"Output:{dish.OutputDishes()}");

						Console.ReadKey();
					}
						
				}

			// While the input is Null or Empty, the user need input a new value 
			} while (String.IsNullOrEmpty(input) || dish == null);
		}
	}
}
