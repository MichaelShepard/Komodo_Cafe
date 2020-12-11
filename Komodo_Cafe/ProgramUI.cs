using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    class ProgramUI
    {

        private MenuRepo _itemRepo = new MenuRepo();  // Creates a new instance of Menu Repo

        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Select an option: \n" +
                    "1. Create New Menu Item \n" +
                    "2. View All Menu Items \n" +
                    "3. View Menu Item By Meal # \n" +
                    "4. Update Meal Item \n" +
                    "5. Delete A Meal Item \n" +
                    "6. Exit");
            
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewMenuItem();
                    break;
                case "2":
                    DisplayAllMenuItems();
                    break;
                case "3":
                    DisplayMenuItemByNumber();
                    break;
                case "4":
                    UpdateMealItem();
                        break;
                case "5":
                        DeleteMenuItem();
                        break;
                case "6":
                    // Exit
                    Console.WriteLine("Good Bye!!");
                    keepRunning = false; // breaks while loop
                    break;
                default:
                    Console.WriteLine("Please enter a valid number.");
                    break;
            }
                Console.WriteLine("Press any key to conitnue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();

            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter in the new menu number:");
            newMenuItem.MealNumber = Console.ReadLine();

            Console.WriteLine("Enter in the new menu item name:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter in the description of the new menu item:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter in the ingredients of the new menu item:");
            newMenuItem.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("Enter in the price of the new menu item:");
            newMenuItem.MealPrice = Console.ReadLine();

            _itemRepo.AddItemToMenu(newMenuItem);

        }


        private void DisplayAllMenuItems()
        {

            Console.Clear();

            List<Menu> _itemOnMenu = _itemRepo.GetMenuItems();

            foreach (Menu item in _itemOnMenu)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber} \n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Price: {item.MealPrice} \n");
            }
        }

        private void DisplayMenuItemByNumber()
        {
            Console.Clear();

            Console.WriteLine("Enter in the number to meal item information:");
            string input = Console.ReadLine();

            Menu item = _itemRepo.GetMenuItemByMealNumber(input);

            if (item != null)
            {

                Console.Write($"Meal Number: {item.MealNumber} \n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Meal Price: {item.MealPrice} \n");
            } else {
                Console.WriteLine("I could not find that meal number");

            }

        }

        private void UpdateMealItem()
        {

            DisplayAllMenuItems();

            Console.WriteLine("Enter in the Meal number you would like to change:");
            string oldMealNumber = Console.ReadLine();

            Menu newMenuItem = new Menu();

            Console.WriteLine("Enter in the new menu number:");
            newMenuItem.MealNumber = Console.ReadLine();

            Console.WriteLine("Enter in the new menu item name:");
            newMenuItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter in the description of the new menu item:");
            newMenuItem.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter in the ingredients of the new menu item:");
            newMenuItem.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("Enter in the price of the new menu item:");
            newMenuItem.MealPrice = Console.ReadLine();

            bool wasUpdated = _itemRepo.UpdateExistingMenuItem(oldMealNumber, newMenuItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu item successfully updated.");
            } else {
                Console.WriteLine("Content was not updated.");
            }
        }

        public void DeleteMenuItem()
        {

            DisplayAllMenuItems();

            Console.WriteLine("Which menu item do you want to remove from menu?");
            string input = Console.ReadLine();

            bool wasUpdated = _itemRepo.RemoveItemFromMenu(input);

            if(wasUpdated)
            {

                Console.WriteLine("The item was successfully deleted");
            } else {

                Console.WriteLine("The item was not deleted.");
            }
        }

        // Seed Methods

        private void SeedMenuList()
        {

            Menu Hamburger = new Menu("1", "Hamburger", "The classic hamburger and a crowd favorite", "Bun, Hamburger, Lettuce, Tomato", "$4.95");
            Menu Cheeseburger = new Menu("2", "Cheeseburger", "The classic hamburger with cheese and a crowd favorite", "Bun, cheese, Hamburger, Lettuce, Tomato", "$5.95");

            _itemRepo.AddItemToMenu(Hamburger);
            _itemRepo.AddItemToMenu(Cheeseburger);

        }

    }  //End of Class
} // End of namespace
