using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using microwave.Models;
using microwave.Controllers;

namespace microwave.Controllers
{
    public class MicrowaveController : MicrowaveControllerBase
    {
        public MicrowaveController(MicrowaveModel microwaveModel) : base(microwaveModel)
        {
            
        }

        public IActionResult Index()
        {
            int progress = _microwaveModel.GetHeatedMealProgress();
            return Ok($"Heating progress: {progress}%");
        }

        public IActionResult Pause()
        {
            if (!_microwaveModel.GetIsPaused())
            {
                _microwaveModel.IsPaused = true;
                return Ok("Heating paused.");
            }
            else
            {
                return BadRequest("Heating is already paused.");
            }
        }

        public IActionResult Resume()
        {
            if (_microwaveModel.GetIsPaused())
            {
                _microwaveModel.IsPaused = false;
                return Ok("Heating resumed.");
            }
            else
            {
                return BadRequest("Heating is not paused.");
            }
        }

        public IActionResult IncreaseTime(int additionalTime)
        {
            if (additionalTime <= 0)
            {
                return BadRequest("Please provide a valid time.");
            }

            int previousTime = _microwaveModel.CurrentTime;
            _microwaveModel.CurrentTime += additionalTime;
            int newHeatedMeal = MicrowaveModel.CalculateHeatedMeal(_microwaveModel.CurrentTime, _microwaveModel.CurrentPotency);

            return Ok($"Increased heating time from {previousTime} to {_microwaveModel.CurrentTime}. New heated meal: {newHeatedMeal}");
        }

        public new IActionResult QuickStart()
        {
            _microwaveModel.CurrentTime = 30;
            _microwaveModel.CurrentPotency = 10;

            int heatedMeal = MicrowaveModel.CalculateHeatedMeal(_microwaveModel.CurrentTime, _microwaveModel.CurrentPotency);

            return View("QuickStart", heatedMeal);
        }


    }
}
