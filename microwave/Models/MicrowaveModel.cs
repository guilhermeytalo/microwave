    namespace microwave.Models;

public class MicrowaveModel
{

    public int CurrentTime { get; set; }      // Current time setting in seconds
    public int CurrentPotency { get; set; }   // Current power level (1 to 10)
    public int HeatedMeal { get; set; }       // Amount of heating for the meal

    // Constructor to initialize default values
    public MicrowaveModel()
    {
        CurrentTime = 60;       // Default time is 60 seconds
        CurrentPotency = 5;     // Default potency is 5
        HeatedMeal = 0;         // Initial heated meal value
    }

    public int CalculateHeatedMeal()
    {
        return CurrentTime * CurrentPotency;
    }
}

