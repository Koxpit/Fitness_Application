using FitnessApp.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controllers
{
    [Serializable]
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_PATH = "exercises.dat";
        private const string ACTIVITIES_FILE_PATH = "activities.dat";

        private User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }

            SaveExercisesAndActivities();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_PATH) ?? new List<Exercise>();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_PATH) ?? new List<Activity>();
        }

        private void SaveExercisesAndActivities()
        {
            Save(EXERCISES_FILE_PATH, Exercises);
            Save(ACTIVITIES_FILE_PATH, Activities);
        }
    }
}
