using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class MenuRepo
    {

        // Field
        private List<Menu> _itemOnMenu = new List<Menu>();

        // Create a new menu item


        public void AddItemToMenu(Menu item)
        {

            _itemOnMenu.Add(item);

        }


        // Read a list of menu items


        public List<Menu> GetMenuItems()
        {
            return _itemOnMenu;
        }

        public Menu GetMenuItemByMealNumber(string number)
        {
            foreach (Menu item in _itemOnMenu)
            {
                if(item.MealNumber == number)
                {
                    return item;
                }
            }

            return null;
        }


        // Update menu items

        public bool UpdateExistingMenuItem(string originalMenuItem, Menu newMenuItem)
        {

            var oldMenuItem = GetMenuItemByMealNumber(originalMenuItem);


            if(oldMenuItem !=null)
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.MealDescription = newMenuItem.MealDescription;
                oldMenuItem.ListOfIngredients = newMenuItem.ListOfIngredients;
                oldMenuItem.MealPrice = newMenuItem.MealPrice;
                return true; 

            } else {

                return false;

            }
        }





        // Delete menu items


        public bool RemoveItemFromMenu(string menuItem)
        {
            var item = GetMenuItemByMealNumber(menuItem);

            if (item == null)
            {
                return false;

            }

            int initialCount = _itemOnMenu.Count();
            _itemOnMenu.Remove(item);

            if (initialCount > _itemOnMenu.Count)
            {
                return true;
            } else {
                return false;
            }

        }





    }
}
