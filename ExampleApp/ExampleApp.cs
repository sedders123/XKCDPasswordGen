using System;
using XKCDPasswordGen;

namespace ExampleApp
{
    class ExampleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine(XkcdPasswordGen.Generate(4));
            Console.ReadLine();
        }
    }
}