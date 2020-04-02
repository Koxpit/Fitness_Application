using FitnessApp.BL.Controllers;
using System;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness!");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine()); // TODO: Переписаь

            Console.WriteLine("Введите вес");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            double height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender,
                birthdate, weight, height);

            userController.Save();
        }
    }
}
