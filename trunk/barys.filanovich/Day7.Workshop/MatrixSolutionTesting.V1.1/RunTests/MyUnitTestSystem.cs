using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;
using MyMatrix;

namespace RunTests
{
    public class MyUnitTestSystem
    {
        static void Main(string[] args)
        {
            Assembly assmblTests = Assembly.LoadFrom("MyMatrixTests.dll");

            Type[] MxTestTypes = assmblTests.GetTypes();

            object testObject = new Object();

            foreach (var testType in MxTestTypes)
            {
                Console.WriteLine(testType.Name + "\n");

                ConstructorInfo[] ciTestType = testType.GetConstructors();

                foreach (ConstructorInfo cTestType in ciTestType)
                {
                    if (cTestType.GetParameters().Length == 0)
                    {
                        testObject = cTestType.Invoke(null);
                    }
                }

                MethodInfo[] mi = testType.GetMethods();

                FieldInfo[] fields = testType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (MethodInfo m in mi)
                {
                    if (m.GetCustomAttributes(false).Any(x => x is NUnit.Framework.TestAttribute))
                    {
                        Console.WriteLine(m.Name);
                        m.Invoke(testObject, null);

                        if (String.Compare(fields[0].GetValue(testObject).ToString(), fields[1].GetValue(testObject).ToString(), true)==0)
                        {
                            Console.WriteLine("The test is passed.\n");
                        }
                        else
                        {
                            Console.WriteLine("The test is not passed.\n");
                        }
                    }
                }
            }
        }
    }
}
