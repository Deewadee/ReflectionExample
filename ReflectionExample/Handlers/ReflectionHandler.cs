using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    internal partial class Program
    {
        private class ReflectionHandler
        {
            private string CURRENT_ASSEMBLY = Assembly.GetExecutingAssembly().GetName().Name;

            internal List<Type> GetImplementations(string typeName)
            {
                if (string.IsNullOrEmpty(typeName)) throw new ArgumentNullException(nameof(typeName));

                var type = GetType(typeName);

                List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(assembly => assembly.GetTypes())
                                .Where(i => type.IsAssignableFrom(i) && !i.IsInterface).ToList();

                return types;
            }

            internal Type GetType(string typeName)
            {
                if (string.IsNullOrEmpty(typeName)) throw new ArgumentNullException(nameof(typeName));

                return Type.GetType($"{CURRENT_ASSEMBLY}.{typeName}", true, true);
            }

            internal object CreateInstance(string typeName)
            {
                return Activator.CreateInstance(GetType(typeName));
            }

            internal MethodInfo[] GetMethods(Type type)
            {
                return type.GetMethods();
            }

            internal MethodInfo GetMethod(Type type, string methodName)
            {
                return type.GetMethod(methodName);
            }

            internal PropertyInfo[] GetProperties(Type type)
            {
                return type.GetProperties();
            }

            internal FieldInfo[] GetFields(Type type)
            {
                return type.GetFields();
            }
        }
    }
}
