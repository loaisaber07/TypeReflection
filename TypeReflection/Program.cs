using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
namespace TypeReflection; //new feature in c#10 

public class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        Program p = new Program();
        Type type=  p.GetType(); 
   MethodInfo[] methods = type.GetMethods();

        foreach (var item in methods) {
            Console.WriteLine(item.ReturnType.FullName);
            foreach (var param in item.GetParameters()) {
                Console.WriteLine($"{param.Name}  : {param.ParameterType.FullName}");
            }
        }
       AssemblyName a = new AssemblyName("TypeReflection");
       a.Version = new Version("1.0.0.0"); 
      Assembly e = Assembly.Load(a);
   Program? pro=  Activator.CreateInstance(typeof(Program)) as Program; 

        Object o = new object();
       Type t= o.GetType();
        Type d = Type.GetType("TypeReflection.Program", false, true);
        if (d.IsClass)
        {
            Console.WriteLine("Is class !");
        }
        IEnumerable<string> method = Methods(d); 
        foreach (var item in method)
        {
            Console.WriteLine(item);
        }
        //Dynamic Properties 
    }
    public static IEnumerable<string> Methods(Type type)
    {
//        r = new List<string>(); 
    ICollection<string> strings = new List<string>(); 
    
    foreach (string method in type.GetMethods().OrderBy(s=>s.Name).Select(s=>s.Name))
    {
        strings.Add(method);
        }
    return strings; 

    }
}
