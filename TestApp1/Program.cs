using System;
using System.Linq;
using System.Reflection;
using static System.Console;

namespace TestApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.DataSet ds;

            System.Net.Http.HttpClient client;
            {
                bool a = true;
                bool b = false;

                WriteLine($"AND | a | b");
                WriteLine($"a |{a & a,-5}|{a & b,-5}");
                WriteLine($"b | {b & a,-5} | {b & b,-5} ");
                WriteLine();

                WriteLine($"OR | a | b ");

                WriteLine($"a | {a | a,-5} | {a | b,-5} ");

                WriteLine($"b | {b | a,-5} | {b | b,-5} ");

                WriteLine();

                WriteLine($"XOR | a | b ");

                WriteLine($"a | {a ^ a,-5} | {a ^ b,-5} ");

                WriteLine($"b | {b ^ a,-5} | {b ^ b,-5} ");
                WriteLine();
            }
            {
                // loop through the assemblies that this app references
                foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
                {
                    // load the assembly so we can read details
                    var a = Assembly.Load(r.FullName);

                    // count the number of mothods
                    int methodCount = 0;
                    // loop through all types in the assembly
                    foreach (var t in a.DefinedTypes)
                    {
                        methodCount += t.GetMethods().Count();

                    }

                    // output the count of types and their methods
                    Console.WriteLine($"{a.DefinedTypes.Count()} types with {methodCount} methods in {r.Name} assembly.");
                }
            }
        }
    }
}
