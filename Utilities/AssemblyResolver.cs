using System.Reflection;
using System;
using System.IO;

public static class AssemblyResolver
{
    public static void Initialize()
    {
        AppDomain.CurrentDomain.AssemblyResolve += ResolveGameAssembly;
    }

    private static Assembly ResolveGameAssembly(object sender, ResolveEventArgs args)
    {
        try
        {
            string assemblyName = new AssemblyName(args.Name).Name;

            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (asm.GetName().Name == assemblyName)
                    return asm;
            }

            string gameDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string managedPath = Path.Combine(gameDir, "..", "AQ3D_Data", "Managed");
            string targetDll = Path.Combine(managedPath, $"{assemblyName}.dll");

            if (File.Exists(targetDll))
            {
                return Assembly.LoadFile(targetDll);
            }

            string[] searchPaths = new[] {
                    Path.Combine(gameDir, $"{assemblyName}.dll"),
                    Path.Combine(System.Environment.CurrentDirectory, $"{assemblyName}.dll"),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.dll")
                };

            foreach (var path in searchPaths)
            {
                if (File.Exists(path))
                    return Assembly.LoadFile(path);
            }
        }
        catch (Exception ex)
        {
        }

        return null;
    }
}