using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NUnit.Framework;

namespace RunTests
{
    class Program
    {
        static void Main(string[] args)
        {
            MyUnitTestSystem UnitTest = new MyUnitTestSystem();

            UnitTest.GetAssembly(args[0]);
        }
    }
}
