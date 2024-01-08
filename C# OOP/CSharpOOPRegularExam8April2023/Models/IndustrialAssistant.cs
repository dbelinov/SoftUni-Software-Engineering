namespace RobotService.Models;

public class IndustrialAssistant : Robot
{
    private const int DefaultBatteryCapacity = 40000;
    private const int DefaultConversionCapacityIndex = 5000;

    public IndustrialAssistant(string model) : base(model, DefaultBatteryCapacity, DefaultConversionCapacityIndex)
    {
    }
}