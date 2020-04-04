using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_PATH = "foods.dat";
        private const string EATINGS_FILE_PATH = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользватель не может быть пустым", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                SaveFoodsAndEatings();
            }
            else
            {
                Eating.Add(product, weight);
                SaveFoodsAndEatings();
            }
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_PATH) ?? new List<Food>();
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_PATH) ?? new Eating(user);
        }

        public void SaveFoodsAndEatings()
        {
            Save(FOODS_FILE_PATH, Foods);
            Save(EATINGS_FILE_PATH, Eating);
        }
    }
}
