using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
        | BindingFlags.Static | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        Object objectInstance = Activator.CreateInstance(classType, new object[] {});

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo fieldInfo in fieldInfos.Where(fi => fields.Contains(fi.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(objectInstance)}");
        }

        return sb.ToString().Trim();
    }
}