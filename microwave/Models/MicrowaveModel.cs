    namespace microwave.Models;

public class MicrowaveModel
{
    public int CurrentTime { get; set; }
    public int CurrentPotency { get; set; }
    public int HeatedMeal { get; set; }

    
    public bool IsPaused { get; set; }
    public bool IsFinished { get; private set; }
    public DateTime StartTime { get; private set; }

  
    public static int MinimumRequiredTime { get; } = 1;
    public static int MaxRequiredTime { get; } = 600;
    public static int MinPotency { get; } = 1;
    public static int MaxPotency { get; } = 10;

    public MicrowaveModel()
    {
        CurrentTime = 60;
        CurrentPotency = 10;
        HeatedMeal = 0;
        IsPaused = false;
        IsFinished = false;
        StartTime = DateTime.Now;
    }

    public static int CalculateHeatedMeal(int time, int potency)
    {
        return time * potency;
    }

    public bool GetIsPaused()
    {
        return IsPaused;
    }

    public bool GetIsFinished()
    {
        return IsFinished;
    }

    public void SetFinished()
    {
        IsFinished = true;
    }

    public TimeSpan GetElapsedTime()
    {
        return DateTime.Now - StartTime;
    }

    public int GetHeatedMealProgress()
    {
        if (GetIsFinished())
        {
            return 100;
        }

        return (int)((GetElapsedTime().TotalSeconds / CurrentTime) * 100);
    }

    public int GetHeatedMealTimeRemaining()
    {
        if (GetIsFinished())
        {
            return 0;
        }

        return CurrentTime - (int)GetElapsedTime().TotalSeconds;
    }
}
