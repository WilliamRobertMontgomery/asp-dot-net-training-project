using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestComplex
{
    class Runner
    {
        [STAThread]
        static void Main(string[] args)
        {
            int returnCode;

            returnCode = NUnit.ConsoleRunner.Runner.Main(args);

            if (returnCode != 0)
                Console.Beep();
        }
    }
}