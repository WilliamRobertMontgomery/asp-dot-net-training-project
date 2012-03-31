using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Workshop.Day7.Reflection
{
    class Program
    {
        private const string MyAssemblyName = "Workshop.Day3.Matrix.Test.dll";

        static void RunReflectionTest()
        {
            Assembly theAssembly = Assembly.LoadFrom(MyAssemblyName);

            Type testClass = theAssembly.GetTypes().FirstOrDefault(type => type.GetCustomAttributes(false).Any(x => x.GetType().Name == "TestFixtureAttribute"));

            if (testClass == null)
            {
                Console.WriteLine("Тестовый класс в сборке " + MyAssemblyName + " не обнаружен");
                return;
            }

            Console.WriteLine("Обнаружен тестовый класс: " + testClass.Name);

            // Search methods with attribute [Test] and without parameters
            MethodInfo[] testMetods = testClass.GetMethods().Where(methodInfo => (methodInfo.GetParameters().Length == 0) &&
                methodInfo.GetCustomAttributes(false).Any(attr => attr.GetType().Name == "TestAttribute")).ToArray();

            object testObject = testClass.GetConstructor(Type.EmptyTypes).Invoke(null);

            bool result = false;

            foreach (MethodInfo m in testMetods)
            {
                object expectedExceptionAttribute = m.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "ExpectedExceptionAttribute");

                if (expectedExceptionAttribute == null)
                {
                    result = RunTest(m, testObject);
                }
                else
                {
                    Type expectedException = (Type)expectedExceptionAttribute.GetType().GetProperties().First(x => x.Name == "ExpectedException").GetValue(expectedExceptionAttribute, null);
                    result = RunExceptionTest(m, testObject, expectedException);
                }

                Console.WriteLine((result ? "+" : "-") + " Тест " + m.Name);
            }

        }

        static bool RunTest(MethodInfo method, object obj)
        {
            try
            {
                method.Invoke(obj, null);
                return true;
            }
            catch
            {
                return false;
            }
        }

        static bool RunExceptionTest(MethodInfo method, object obj, Type expectedException)
        {
            try
            {
                method.Invoke(obj, null);
                return false;
            }
            catch (Exception ex)
            {
                if ( ex.InnerException.GetType() == expectedException )
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
        }


        static void Main(string[] args)
        {
            RunReflectionTest();

            //Console.Read();
        }
    }
}
