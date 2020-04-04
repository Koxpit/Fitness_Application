using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessApp.BL.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
        private const string USER_FILE_PATH = "users.dat";
        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Пользователь новый или нет
        /// </summary>
        public bool IsNewUser { get; } = false;

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                SaveUsersData();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USER_FILE_PATH) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsersData();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void SaveUsersData()
        {
            Save(USER_FILE_PATH, Users);
        }
    }
}
