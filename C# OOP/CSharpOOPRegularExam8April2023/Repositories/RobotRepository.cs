using System.Collections.Generic;
using System.Linq;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories;

public class RobotRepository : IRepository<IRobot>
{
    private List<IRobot> robots = new List<IRobot>();

    public IReadOnlyCollection<IRobot> Models() => robots.AsReadOnly();

    public void AddNew(IRobot robot) => robots.Add(robot);

    public bool RemoveByName(string robotModel)
    {
        IRobot robot = robots.FirstOrDefault(r => r.Model == robotModel);
        if (robot != null)
        {
            robots.Remove(robot);
            return true;
        }

        return false;
    }

    public IRobot FindByStandard(int interfaceStandard)
        => robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
}