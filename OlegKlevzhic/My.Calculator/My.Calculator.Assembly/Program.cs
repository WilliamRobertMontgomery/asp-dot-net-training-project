using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using NUnit.Framework;

namespace My.Calculator.Reflection
{
	class Program
	{
		private const string myAssemblyName = "My.Calculator.Tests.exe";

		static void RunFirstReflectionTest()
		{
			Assembly theAssembly = Assembly.LoadFrom(myAssemblyName);

			Type[] allTypes = theAssembly.GetTypes();

			foreach (Type t in allTypes)
			{
				Console.WriteLine("Detected type: " + t.Name);
			}

			Console.WriteLine();

			// Работаем с первым типом
			Type firstType = allTypes[1];
			object reflectObject = theAssembly.CreateInstance(firstType.FullName);

			Console.WriteLine("Работаем с типом " + firstType.FullName);
			Console.WriteLine();

			// Получаем список методов объекта
			MethodInfo[] allMethods = firstType.GetMethods();

			foreach (MethodInfo m in allMethods)
			{
				if (m.Attributes == new Test)
				{
					// Создаем массив параметров метода
					object[] methodArgs = new object[2];
					methodArgs[0] = 11;
					methodArgs[1] = 15;

					Console.WriteLine("Вызов метода " + m.Name);
					// Вызов метода с двумя параметрами
					m.Invoke(reflectObject, methodArgs);

					Console.WriteLine();
				}
			}
		}

		static void Main(string[] args)
		{
			RunFirstReflectionTest();
			Console.ReadLine();
		}
	}
}
