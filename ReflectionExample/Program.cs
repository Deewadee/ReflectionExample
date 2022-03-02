using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace ReflectionExample
{
    internal partial class Program
    {
        private static bool _showMenu = true;
        static void Main(string[] args)
        {
            try
            {
                MenuHandler.ShowMenu();
                
                while(_showMenu)
                {
                    MenuHandler.HandleMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
