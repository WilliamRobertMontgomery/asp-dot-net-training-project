﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vectorTests
{
    class Runner
    {
        [STAThread]
        static void Main(string[] args)
        {
            NUnit.ConsoleRunner.Runner.Main(args);
        }
    }
}