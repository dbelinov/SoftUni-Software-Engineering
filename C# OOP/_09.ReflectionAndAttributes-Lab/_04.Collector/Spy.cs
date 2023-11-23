using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fields)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                                                                            | BindingFlags.Static |
                                                                            BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        Object objectInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo fieldInfo in fieldInfos.Where(fi => fields.Contains(fi.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(objectInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance
                                                 | BindingFlags.Public);
        PropertyInfo[] properties = classType.GetProperties(BindingFlags.Public
                                                            | BindingFlags.NonPublic
                                                            | BindingFlags.Instance
                                                            | BindingFlags.Static);

        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic
                                                           | BindingFlags.Instance);

        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Public
                                                          | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo privateMethod in privateMethods
                     .Where(prvm => prvm.Name.Contains("get")))
        {
            sb.AppendLine($"{privateMethod.Name} have to be public!");
        }

        foreach (MethodInfo publicMethod in publicMethods
                     .Where(pm => pm.Name.Contains("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.NonPublic
                                                        | BindingFlags.Instance
                                                        | BindingFlags.Static);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo methodInfo in methodInfos)
        {
            sb.AppendLine(methodInfo.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Instance
                                                        | BindingFlags.Public
                                                        | BindingFlags.Static
                                                        | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();
        
        //getters
        foreach (MethodInfo methodInfo in methodInfos
                     .Where(mi => mi.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
        }
        
        //setters
        foreach (MethodInfo methodInfo in methodInfos
                     .Where(mi => mi.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}