using System.Reflection;

namespace CleanArchitectureProjectTemplate.Application.Extensions;

public static class AssemblyExtension
{
    public static Assembly GetApplicationLayerAssembly()
        => Assembly.GetExecutingAssembly();
}
