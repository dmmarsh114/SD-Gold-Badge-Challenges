using System;
using System.Collections.Generic;
using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeTests
    {
        MenuRepo menuTest = new MenuRepo();

        [TestMethod]
        public void CreateMealTest()
        {
            for (int i = 0; i < 3; i++)
            {
                Meal mealTest = new Meal();
                mealTest.Name = $"Test Meal {i}";
                mealTest.Description = "Test meal";
                List<string> testIngredients = new List<string> { "Salt", "Sugar", "Flour" };
                mealTest.Ingredients = testIngredients;
                mealTest.Price = 2.00M;

                menuTest.CreateMeal(mealTest);
            }

            Assert.AreEqual(3, menuTest.GetAllMeals().Count);
        }

        [TestMethod]
        public void DeleteMealTest()
        {
            Meal mealTest = new Meal();
            mealTest.Name = $"Test Meal 0";
            mealTest.Description = "Test meal";
            List<string> testIngredients = new List<string> { "Salt", "Sugar", "Flour" };
            mealTest.Ingredients = testIngredients;
            mealTest.Price = 2.00M;

            menuTest.CreateMeal(mealTest);

            menuTest.DeleteMeal("Test Meal 0");
            Assert.AreEqual(0, menuTest.GetAllMeals().Count);
        }
    }
}
