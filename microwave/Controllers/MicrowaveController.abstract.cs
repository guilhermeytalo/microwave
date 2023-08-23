using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using microwave.Models;

namespace microwave.Controllers
{
    public abstract class MicrowaveBaseController : Controller
    {
        protected const int MinimumRequiredTime = 1;
        protected const int MaxRequiredTime = 120;

        protected const int MinPotency = 1;
        protected const int MaxPotency = 10;

        protected int heatedMeal = 0;

        public int HeatedMeal
        {
            get => heatedMeal;
            set => heatedMeal = value;
        }

        public IActionResult IncreaseHeating(int time)
        {
            MicrowaveModel microwave = new();

            int potency = microwave.CurrentPotency;

            int calculatedTime = time + 30;
            int timeIncreased = MicrowaveModel.CalculateHeatedMeal(calculatedTime, potency);

            return Ok(timeIncreased);
        }

        public IActionResult QuickStart()
        {
            int start = DefaultValidPotency(0) + 30;
            return View("QuickStart", start);
        }

        public IActionResult Heating(int time, int potency)
        {
            if (!IsValidTime(time))
            {
                return BadRequest("Invalid time set a valid time.");
            }

            if (!IsValidPotency(potency))
            {
                return BadRequest("Invalid potency set a valid potency.");
            }

            DefaultValidPotency(potency);

            if (time > 60 && time < 100)
            {
                FormatTime(time);
            }

            int heatedMealResult = MicrowaveModel.CalculateHeatedMeal(time, potency);

            return Ok($"Heated meal for {FormatTime(time)} with potency {potency}. Current heated meal: {heatedMealResult}");
        }

        protected bool IsValidTime(int time)
        {
            return time >= MinimumRequiredTime && time <= MaxRequiredTime;
        }

        protected bool IsValidPotency(int potency)
        {
            return potency >= MinPotency && potency <= MaxPotency;
        }

        protected int DefaultValidPotency(int potency)
        {
            return IsValidPotency(potency) ? potency : 10;
        }

        protected string FormatTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{timeSpan.Minutes}:{timeSpan.Seconds:D2}";
        }
    }
}
