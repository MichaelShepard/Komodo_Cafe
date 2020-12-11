using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Menu
    {
        public string MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public string MealPrice { get; set; }

        public Menu() { }

        public Menu (string mealNumber, string mealName, string mealDescription, string listOfIngredients, string mealPrice)
        {

            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }
    }
}
