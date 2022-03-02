using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionExample
{
    internal partial class Program
    {
        private class MenuHandler
        {
            private static ReflectionHandler _handler = new ReflectionHandler();

            internal static void ShowMenu()
            {
                Console.WriteLine("\n<---------------MENU--------------->");
                Console.WriteLine("Choose an option:\n");

                Console.WriteLine("1 - Show interface implementation");
                Console.WriteLine("2 - Show type information");
                Console.WriteLine("3 - Invoke type method");
                Console.WriteLine("4 - Exit");
                Console.WriteLine("<---------------MENU--------------->\n");
            }

            internal static void HandleMenu()
            {
                Console.WriteLine("\n<---------------MENU HANDLER--------------->");
                Console.WriteLine("Enter option number:");
                string optionNumber = Console.ReadLine();

                try
                {
                    switch(optionNumber)
                    {
                        case "1":
                            ShowInterfaceImplementation();
                            break;
                        case "2":
                            ShowTypeInfo();
                            break;
                        case "3":
                            InvokeMethod();
                            break;
                        case "4":
                            _showMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid number entered!\n");
                            break;
                    }
                }
                catch (TypeLoadException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private static void InvokeMethod()
            {
                Console.WriteLine("Enter type name:");

                string typeName = Console.ReadLine().Trim();

                Console.WriteLine("\nEnter method name:");

                string methodName = Console.ReadLine().Trim();

                var instance = _handler.CreateInstance(typeName);
                
                MethodInfo method = _handler.GetMethod(instance.GetType(), methodName);

                object[] parameters = null;

                if(method.GetParameters().Length > 0)
                {
                    Console.WriteLine("\nTo invoke the method, enter a parameter");

                    string parameter = Console.ReadLine().Trim();

                    parameters = new [] { parameter };
                }

                method.Invoke(instance, parameters);
            }

            private static void ShowTypeInfo()
            {
                Console.WriteLine("To show the information about type, enter its name");

                string typeName = Console.ReadLine().Trim();

                Type type = _handler.GetType(typeName);
                
                MethodInfo[] methods = _handler.GetMethods(type);
                PropertyInfo[] properties = _handler.GetProperties(type);
                FieldInfo[] fields = _handler.GetFields(type);

                Console.WriteLine();
                Console.WriteLine($"Type: {type.Name}");

                Console.WriteLine("\nMethods:");
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine($"{method.ReturnType.Name} {method.Name}()");
                }

                Console.WriteLine("\nProperties:");
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine($"{property.PropertyType.Name} {property.Name}");
                }

                Console.WriteLine("\nFields:");
                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine($"{field.FieldType.Name} {field.Name}");
                }
            }

            private static void ShowInterfaceImplementation()
            {
                Console.WriteLine("There are IMessenger and IPay interfaces");
                Console.WriteLine("To show the implementation of an interface, enter its name:");

                string typeName = Console.ReadLine().Trim();

                List<Type> implementations = _handler.GetImplementations(typeName);

                Console.WriteLine($"\nImplementation of the interface {typeName}:");
                implementations.ForEach(i => Console.WriteLine(i.Name));
                Console.WriteLine();
            }
        }
    }
}
