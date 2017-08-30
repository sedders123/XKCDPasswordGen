using System;
using XKCDPasswordGen;

namespace ExampleApp
{
    class ExampleApp
    {
        static void Main(string[] args)
        {
            var fourWordPassword = XkcdPasswordGen.Generate(4);
            Console.WriteLine("4 random words: " + fourWordPassword);

            var dashPassword = XkcdPasswordGen.Generate(4, "-");
            Console.WriteLine("4 random words separated by a dash: " + dashPassword);

            Console.ReadLine();
        }
    }
}