using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;

namespace RunTests
{
    public class MyUnitTestSystem
    {
        public void GetAssembly(string assemblyFile)
        {
            Assembly assmblTests = Assembly.LoadFrom(assemblyFile);

            Type[] MxTestTypes = assmblTests.GetTypes();

            object testObject = new Object();

            foreach (var testType in MxTestTypes)
            {
                Console.WriteLine(testType);

                ConstructorInfo[] ciTestType = testType.GetConstructors();

                foreach (ConstructorInfo cTestType in ciTestType)
                {
                    if (cTestType.GetParameters().Length == 0)
                    {
                        testObject = cTestType.Invoke(null);
                    }
                }

                MethodInfo[] mi = testType.GetMethods();

                foreach (MethodInfo m in mi)
                {
                    if (m.GetCustomAttributes(false).Any(x => x is NUnit.Framework.TestAttribute))
                    {
                        Console.WriteLine(m.Name);

                        m.Invoke(testObject, null);

                        Console.WriteLine();
                    }
                }
            }
        }
    }

    public class Assert
    {
        public static void IsTrue(bool condition)
        {
            if (condition)
            {
                Console.WriteLine("The test is passed.");
            }
            else
            {
                Console.WriteLine("The test is not passed.");
            }
        }
    }
}
