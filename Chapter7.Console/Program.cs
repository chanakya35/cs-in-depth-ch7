using PartialKittens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter7.Console
{
    using Console = System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: create a simple console menu here
            // Tiger partial method example
            Tiger tiger = new Tiger();
            tiger.FinishLoading(); // will *not* see any print out if Index() is not implemented
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
