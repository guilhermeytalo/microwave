using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using microwave.Models;

namespace microwave.Controllers
{
    public abstract class MicrowaveControllerBase : Controller
    {
        protected MicrowaveModel _microwaveModel;

        public MicrowaveControllerBase(MicrowaveModel microwaveModel)
        {
            _microwaveModel = microwaveModel ?? throw new ArgumentNullException(nameof(microwaveModel));
        }

        public IActionResult Heating(int time, int potency)
        {
            if (!IsValidTime(time))
            {
                return BadRequest("Please set a valid time.");
            }

            if (!IsValidPotency(potency))
            {
                return BadRequest("Please set a valid potency.");
            }

            _microwaveModel.CurrentTime = time;
            _microwaveModel.CurrentPotency = potency;

            int heatedMeal = MicrowaveModel.CalculateHeatedMeal(time, potency);

            return Ok($"Heated meal for {FormatTime(time)} with potency {potency}. Current heated meal: {heatedMeal}");
        }

        public IActionResult PauseHeating()
        {
            _microwaveModel.IsPaused = true;
            return Ok("Heating paused.");
        }

        public IActionResult ResumeHeating()
        {
            _microwaveModel.IsPaused = false;
            return Ok("Heating resumed.");
        }

        public IActionResult IncreaseHeating(int time)
        {
            if (!IsValidTime(time))
            {
                return BadRequest("Please set a valid time.");
            }

            _microwaveModel.CurrentTime += time;

            int heatedMeal = MicrowaveModel.CalculateHeatedMeal(_microwaveModel.CurrentTime, _microwaveModel.CurrentPotency);

            return Ok(heatedMeal);
        }

        public IActionResult QuickStart()
        {
            _microwaveModel.CurrentTime = 30;
            _microwaveModel.CurrentPotency = 10;

            int heatedMeal = MicrowaveModel.CalculateHeatedMeal(_microwaveModel.CurrentTime, _microwaveModel.CurrentPotency);

            return View("QuickStart", heatedMeal);
        }

        // Other methods...

        protected bool IsValidTime(int time)
        {
            return time >= MicrowaveModel.MinimumRequiredTime && time <= MicrowaveModel.MaxRequiredTime;
        }

        protected bool IsValidPotency(int potency)
        {
            return potency >= MicrowaveModel.MinPotency && potency <= MicrowaveModel.MaxPotency;
        }

        protected string FormatTime(int seconds)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{timeSpan.Minutes}:{timeSpan.Seconds:D2}";
        }
    }
}