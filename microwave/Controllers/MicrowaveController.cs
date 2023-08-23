using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using microwave.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microwave.Controllers;

public class MicrowaveController : Controller
{
    private const int MinimumRequiredTime = 1;
    private const int MaxRequiredTime = 120;

    private const int MinPotency = 1;
    private const int MaxPotency = 10;

    private int heatedMeal = 0;

    public int HeatedMeal
    {
        get => heatedMeal;
        set => heatedMeal = value;
    }

    public IActionResult QuickStart()
    {
        int start = DefaultValidPotency(0) + 30;

        return View("QuickStart", start);
    }

    public IActionResult Heating(int time, int potency)
    {
        // case 2a - 3a
        if (!IsValidTime(time))
        {
            return BadRequest("Invalid time set a valid time.");
        }

        // case 3b
        if (!IsValidPotency(potency))
        {
            return BadRequest("Invalid potency set a valid potency.");
        };

        // case 2b - 3c
        DefaultValidPotency(potency);

        // case 2c
        if (time > 60  && time < 100)
        {
            FormatTime(time);
        }

        int heatedMealResult = CalculateHeatedMeal(potency, time);

        var model = new MicrowaveModel { HeatedMeal = heatedMealResult };


        return View(model);
        //return Ok($"Heated meal for {FormatTime(time)} with potency {potency}. Current heated meal: {heatedMealResult}");
    }

    private static bool IsValidTime(int time)
    {
        return time >= MinimumRequiredTime && time <= MaxRequiredTime;
    }

    private static bool IsValidPotency(int potency)
    {
                            
        return potency >= MinPotency && potency <= MaxPotency;
    }

    private static int DefaultValidPotency(int potency)
    {
        return IsValidPotency(potency) ? 10 : potency;
    }


    private static string FormatTime(int seconds)
    {
            TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
            return $"{timeSpan.Minutes}:{timeSpan.Seconds:D2}";
    }

    private static int CalculateHeatedMeal(int potency, int time)
    {
        // Replace this with your actual heating logic
        return potency * time;
    }
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
