using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;

namespace RobotService.Core;

/*
CreateRobot K-2SO IndustrialAssistant
CreateRobot T-X IndustrialAssistant
CreateRobot AVA DomesticAssistant
CreateRobot KUSANAGI IndustrialAssistant
CreateRobot C-3PO DomesticAssistant
CreateRobot R2-D2 DomesticAssistant
CreateRobot C1-10P SocialAssistant
CreateRobot C-3PO DomesticAssistant
CreateSupplement FaceRecognitionCamera
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement SpecializedArm
CreateSupplement LaserRadar
CreateSupplement LaserRadar
CreateSupplement LaserRadar
CreateSupplement LaserRadar
PerformService Dishwashing 10045 1000
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO SpecializedArm
UpgradeRobot C-3PO LaserRadar
UpgradeRobot R2-D2 SpecializedArm
UpgradeRobot KUSANAGI LaserRadar
UpgradeRobot KUSANAGI SpecializedArm
PerformService PaintRoad 20082 100000
PerformService DishWashing 10045 1000
PerformService AutomotiveAssembly 10045 25000
RobotRecovery C-3PO 3
RobotRecovery KUSANAGI 3
Report
Exit
*/

public class Controller : IController
{
    private SupplementRepository supplements = new();
    private RobotRepository robots = new();
    
    public string CreateRobot(string model, string typeName)
    {
        if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }

        IRobot robot;
        if (typeName == nameof(DomesticAssistant))
        {
            robot = new DomesticAssistant(model);
        }
        else
        {
            robot = new IndustrialAssistant(model);
        }
        
        robots.AddNew(robot);
        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }

        ISupplement supplement;
        if (typeName == nameof(SpecializedArm))
        {
            supplement = new SpecializedArm();
        }
        else
        {
            supplement = new LaserRadar();
        }
        
        supplements.AddNew(supplement);
        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }

    public string UpgradeRobot(string model, string supplementTypeName)
    {
        ISupplement supplement = supplements.Models().First(s => s.GetType().Name == supplementTypeName);
        List<IRobot> selectedRobots = robots.Models()
            .Where(r => !r.InterfaceStandards.Contains(supplement.InterfaceStandard))
            .Where(r => r.Model == model)
            .ToList();

        if (selectedRobots.Count == 0)
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }

        IRobot robotToUpgrade = selectedRobots.First();
        robotToUpgrade.InstallSupplement(supplement);
        supplements.RemoveByName(supplementTypeName);
        
        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
    }

    public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
    {
        List<IRobot> supportedRobots = robots.Models()
            .Where(r => r.InterfaceStandards.Contains(interfaceStandard))
            .ToList();

        if (supportedRobots.Count == 0)
        {
            return string.Format(OutputMessages.UnableToPerform, interfaceStandard);
        }

        supportedRobots = supportedRobots.OrderByDescending(r => r.BatteryLevel).ToList();

        int sumOfBatteryLevels = supportedRobots.Sum(r => r.BatteryLevel);
        if (sumOfBatteryLevels < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumOfBatteryLevels);
        }

        int counter = 0;
        foreach (IRobot robot in supportedRobots)
        {
            if (robot.BatteryLevel >= totalPowerNeeded)
            {
                robot.ExecuteService(totalPowerNeeded);
                counter++;
                break;
            }

            totalPowerNeeded -= robot.BatteryLevel;
            robot.ExecuteService(robot.BatteryLevel);
            counter++;
        }

        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
    }
    
    public string RobotRecovery(string model, int minutes)
    {
        List<IRobot> robotsToFeed = robots.Models()
            .Where(r => r.Model == model)
            .Where(r => r.BatteryLevel < 0.5 * r.BatteryCapacity)
            .ToList();

        int fedRobots = 0;
        foreach (IRobot robot in robotsToFeed)
        {
            robot.Eating(minutes);
            fedRobots++;
        }

        return string.Format(OutputMessages.RobotsFed, fedRobots);
    }
    public string Report()
    {
        List<IRobot> sortedRobots = robots.Models()
            .OrderByDescending(r => r.BatteryLevel)
            .ThenBy(r => r.BatteryCapacity)
            .ToList();

        StringBuilder sb = new StringBuilder();
        
        foreach (IRobot robot in sortedRobots)
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().Trim();
    }
}