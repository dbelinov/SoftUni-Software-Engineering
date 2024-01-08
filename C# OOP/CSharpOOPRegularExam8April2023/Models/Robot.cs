using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models;

public abstract class Robot : IRobot
{
    private string model;
    private int batteryCapacity;
    private List<int> interfaceStandards;

    protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        ConvertionCapacityIndex = conversionCapacityIndex;
        BatteryLevel = BatteryCapacity;
        interfaceStandards = new List<int>();
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
            }

            model = value;
        }
    }
    public int BatteryCapacity
    {
        get => batteryCapacity;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }

            batteryCapacity = value;
        }
    }
    public int BatteryLevel { get; private set; }
    public int ConvertionCapacityIndex { get; private set; }
    public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();
    
    public void Eating(int minutes)
    {
        // int producedEnergy = ConvertionCapacityIndex * minutes;
        // if (BatteryLevel != BatteryCapacity)
        // {
        //     BatteryLevel += producedEnergy;
        // }

        for (int minute = 1; minute <= minutes; minute++)
        {
            int producedEnergy = ConvertionCapacityIndex;
            if (BatteryCapacity == BatteryLevel)
            {
                break;
            }
            BatteryLevel += producedEnergy;
        }
    }

    public void InstallSupplement(ISupplement supplement)
    {
        interfaceStandards.Add(supplement.InterfaceStandard);
        BatteryCapacity -= supplement.BatteryUsage;
        BatteryLevel -= supplement.BatteryUsage;
    }

    public bool ExecuteService(int consumedEnergy)
    {
        if (BatteryLevel >= consumedEnergy)
        {
            BatteryLevel -= consumedEnergy;
            return true;
        }
        
        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{GetType().Name} {Model}:");
        sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
        sb.AppendLine($"--Current battery level: {BatteryLevel}");
        if (interfaceStandards.Count > 0)
        {
            sb.AppendLine($"--Supplements installed: {string.Join(" ", interfaceStandards)}");
        }
        else
        {
            sb.AppendLine("--Supplements installed: none");
        }

        return sb.ToString().Trim();    
    }
}