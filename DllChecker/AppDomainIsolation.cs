////https://blog.rsuter.com/avoiding-dll-file-locks-when-using-net-reflection-in-external-assemblies/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public sealed class AppDomainIsolation<T> : IDisposable where T : MarshalByRefObject
{
    /// <summary>
    /// The _object.
    /// </summary>
    private readonly T _object;

    /// <summary>
    /// The domain.
    /// </summary>
    private AppDomain domain;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppDomainIsolation{T}"/> class.
    /// </summary>
    /// <param name="assemblyDirectory">
    /// The assembly directory.
    /// </param>
    public AppDomainIsolation(string assemblyDirectory)
    {
        var setup = new AppDomainSetup
        {
            ShadowCopyFiles = "true",
            ApplicationBase = assemblyDirectory,
            ConfigurationFile = this.GetConfigurationPath(assemblyDirectory)
        };

        this.domain = AppDomain.CreateDomain("AppDomainIsolation:" + Guid.NewGuid(), null, setup);

        var type = typeof(T);
        _object = (T)this.domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
    }

    public T Object
    {
        get { return _object; }
    }

    /// <summary>
    /// The dispose.
    /// </summary>
    public void Dispose()
    {
        if (this.domain != null)
        {
            AppDomain.Unload(this.domain);
            this.domain = null;
        }
    }

    /// <summary>
    /// The get configuration path.
    /// </summary>
    /// <param name="assemblyDirectory">
    /// The assembly directory.
    /// </param>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public string GetConfigurationPath(string assemblyDirectory)
    {
        var config = Path.Combine(assemblyDirectory, "App.config");
        if (File.Exists(config))
        {
            return config;
        }

        config = Path.Combine(assemblyDirectory, "Web.config");
        if (File.Exists(config))
        {
            return config;
        }

        return config;
    }
}

public class ExportedTypesWorker : MarshalByRefObject
{
    /// <summary>
    /// The get exported types.
    /// </summary>
    /// <param name="assemblyPath">
    /// The assembly path.
    /// </param>
    /// <returns>
    /// Возврат списка методов
    /// </returns>
    public List<DllMethodInfo> GetMethodInfoList(string assemblyPath)
    {
        var file = Path.GetFileName(assemblyPath);
        var items = new List<DllMethodInfo>();
        var assembly = Assembly.LoadFrom(assemblyPath);
        foreach (var type in assembly.GetTypes())
        {
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                if (method.Module.Name == file)
                {
                    var item = new DllMethodInfo { AssemblyPath = assemblyPath, Method = method.ToString() };
                    items.Add(item);
                }
            }
        }

        return items;
    }
}

[Serializable]
public class DllMethodInfo
{
    public string AssemblyPath { get; set; }
    public string Method { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1}", AssemblyPath, Method);
    }
}