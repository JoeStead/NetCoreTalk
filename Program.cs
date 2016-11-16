using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var osDescription = RuntimeInformation.FrameworkDescription;
            Console.WriteLine($"Hello from {osDescription}!");
        }
    }
}
