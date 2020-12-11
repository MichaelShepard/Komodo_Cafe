using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeTest
{
    [TestClass]
    public class Test
    {

        // Initialize tests

        private Menu _menu;
        private MenuRepo _repo;

        [TestInitialize]

        public void Arrange()
        {

            _menu = new Menu("1", "Hamburger", "The classic hamburger and a crowd favorite", "Bun, Hamburger, Lettuce, Tomato", "$4.95");
            _repo = new MenuRepo();
            _repo.AddItemToMenu(_menu);

        }

        //Add Method Test

        [TestMethod]
        public void AddToMenu_ShouldGetNonNull()
        {

            // Arrange

            Menu menuItem = new Menu();
            menuItem.MealNumber = "4";

            //Act

            MenuRepo repo = new MenuRepo();
            repo.AddItemToMenu(menuItem);
            Menu itemFromMenu = repo.GetMenuItemByMealNumber("4");

            //Assert
            Assert.IsNotNull(itemFromMenu);

        }

        [TestMethod]
        
        public void UpdateExistingContent_ShouldReturnTrue()
        {

            //Arrange & Test Initialization
            Menu updatedItem = new Menu("1", "Best Best Hamburger", "The classic hamburger and a crowd favorite", "Bun, Hamburger, Lettuce, Tomato", "$4.95");

            //Act
            bool updateResult = _repo.UpdateExistingMenuItem("1", updatedItem);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("1", true)]
        public void UpdateExistingMenuItem_ShouldMatchGivenBool(string originalTitle, bool shouldUpdate)
        {
            //Arrange & Test Initialization
            Menu updatedItem = new Menu("1", "Best Best Hamburger", "The classic hamburger and a crowd favorite", "Bun, Hamburger, Lettuce, Tomato", "$4.95");

            //Act
            bool updatedResult = _repo.UpdateExistingMenuItem(originalTitle, updatedItem);

            //Assert
            Assert.AreEqual(shouldUpdate, updatedResult);

        }



        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {

            //Arrange & Initialize

            //Act
            bool deleteResult = _repo.RemoveItemFromMenu(_menu.MealNumber);

            //Assert

            Assert.IsTrue(deleteResult);

        }
    }
}
