using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFitnessTracker.Models
{
    public class UserData
    {
        //Upper bounds for BMI categories
        const double SeverelyUnderweightUpper = 15.9;
        const double UnderweightUpper = 18.4;
        const double NormalWeightUpper = 24.9;
        const double OverweightUpper = 29.9;
        const double ModeratelyObeseUpper = 34.9;

        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First name cannot exceed 20 characters. ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Second Name is required")]
        [Display(Name = "Second Name")]
        [StringLength(20, ErrorMessage = "Second name cannot exceed 20 characters. ")]
        public string SecondName { get; set; }
        public string Gender { get; set; }
        [Range(5, 110, ErrorMessage = "Please enter a valid age. ")]
        public int Age { get; set; }
        [Display(Name = "Weight (KG)")]
        [Range(5, 150, ErrorMessage = "KG must be between 5 and 150")]
        public double WeightKG { get; set; }
        [Display(Name = "Height (CM)")]
        [Range(5, 220, ErrorMessage = "Height must be between 5 and 220 CM")]
        public int HeightCM { get; set; }

        //returns a value for user BMR
        public double BMR
        {
            get
            {
                double bmr = (10 * WeightKG) + (6.25 * HeightCM) - (5 * Age) - 161;
                return bmr;
            }
        }

        //show current saved stats, allow to change to up-do-date stats - check BMR/BMI 
        //return a value for user BMI
        public double BMIValue
        {
            get
            {
                double bmi = (WeightKG / HeightCM / HeightCM) * 10000;
                return bmi;
            }
        }


        public string BMICategory
        {

            get
            {
                double userBMI = this.BMIValue;
                if (userBMI <= SeverelyUnderweightUpper)
                {
                    return "Severely Underweight";
                }
                else if (userBMI <= UnderweightUpper)
                {
                    return "Underweight";
                }
                else if (userBMI <= NormalWeightUpper)
                {
                    return "Normal";
                }
                else if (userBMI <= OverweightUpper)
                {
                    return "Overweight";
                }
                else if (userBMI <= ModeratelyObeseUpper)
                {
                    return "Moderately Obese";
                }
                else
                {
                    return "Not determined";
                }
            }
        }

        ////user calorie stats
        ////total calroies burned working out so far this month
        //public int MonthlyCaloriesBurned
        //{
        //    get
        //    {
        //        using (var db = new FitnessTrackerWebAPIContext())
        //        {
        //            var caloriesMonthly = db.Workouts.Where(w => w.Date.Month == DateTime.Today.Month && w.UserID == ID).Sum(w => w.CaloriesBurned);
        //            return caloriesMonthly;
        //        }
        //    }
        //}

        ////calories burned working out over the last 30 days
        //public int CaloriesBurnedLast30Days
        //{
        //    get
        //    {
        //        using (var db = new FitnessTrackerWebAPIContext())
        //        {
        //            int calsLast30Days = 0;
        //            calsLast30Days = db.Workouts.Where(w => w.Date >= DateTime.Now.AddDays(-30) && w.UserID == ID).Sum(w => w.CaloriesBurned);
        //            return calsLast30Days;
        //        }
        //    }
        //}



        //Users list of personal workouts
        public List<WorkoutData> Workouts { get; set; }

    }
    //holds all workout information such as start/end times, workout details, calories burned etc.
    public class WorkoutData
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Date of workout is required")]
        public DateTime Date { get; set; }
        [Display(Name = "Workout Length")]
        public double WorkoutDuration { get; set; }
        [Display(Name = "Workout Details")]
        public string WorkoutDetails { get; set; }
        [Display(Name = "Calories Burned")]
        public int CaloriesBurned { get; set; }
        public UserData User { get; set; }
        //Foreign Key for Entity Framework
        public int UserID { get; set; }
    }
}
