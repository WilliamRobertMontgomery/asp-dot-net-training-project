using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.Complex.Tests
{
    class Runner
    {
        [STAThread]
        public static void Main(string[] args)
        {
            NUnit.ConsoleRunner.Runner.Main(args);
        }
    }
}
