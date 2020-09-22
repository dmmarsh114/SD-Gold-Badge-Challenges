using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuRepo
    {
        private List<Meal> _meals = new List<Meal>();

        public List<Meal> GetAllMeals()
        {
            return _meals;
        }

        public void CreateMeal(Meal newMeal)
        {
            newMeal.Number = _meals.Count + 1;
            _meals.Add(newMeal);
        }

        public bool DeleteMeal(string name)
        {
            Meal mealToDelete = getMealByName(name);
            if (mealToDelete == null)
            {
                return false;
            }
            _meals.Remove(mealToDelete);
            return true;
        }

        private Meal getMealByName(string name)
        {
            foreach (Meal m in _meals)
            {
                if (m.Name == name)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
