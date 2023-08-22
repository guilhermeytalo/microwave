using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microwave.Controllers
{
    public class MicrowaveController : Controller
    {
        private const int MinimumRequiredTime = 1;
        private const int MaxRequiredTime = 120;

        private int heatedMeal = 0;

        private const int MaxPotency = 10;
        private const int MinPotency = 1;

        public static int GetMinimumRequiredTime() => MinimumRequiredTime;
        public static int GetMaxRequiredTime() => MaxRequiredTime;

        public int HeatedMeal
        {
            get => heatedMeal;
            set => heatedMeal = value;
        }


        public class TimeConverter
        {
            public TimeSpan Time { get; }

            public TimeConverter(int typedTime)
            {
                Time = TimeSpan.FromSeconds(typedTime);
            }

            public override string ToString()
            {
                return $"{Time.Minutes}:{Time.Seconds:D2}";
            }
        }

        public IActionResult Heating(int time, int potency)
        {
            Console.WriteLine($"Heating with potency: {potency}");

            if (time < MinimumRequiredTime || time > MaxRequiredTime)
            {
                return BadRequest($"Time should be between {MinimumRequiredTime} and {MaxRequiredTime} seconds.");
            }

            if (time  > 60 && time < 100 )
            {
                TimeConverter(time);
            }
            int heatedMealResult = CalculateHeatedMeal(potency, time);

            return Ok($"Heated meal for {time} seconds with potency {potency}. Current heated meal: {heatedMealResult}");
        }

        private int CalculateHeatedMeal(int potency, int time)
        {
            // Replace this with your actual heating logic
            return potency * time;
        }
    }
}