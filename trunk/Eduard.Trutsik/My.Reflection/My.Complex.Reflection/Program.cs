using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace My.Complex.Reflection
{
	class Program
	{
		private const string nameAssembly = "My.Complex.dll"; 

		static void Main(string[] args)
		{
			Console.WriteLine("Автор: Труцик Эдуард.");
			Console.WriteLine("Рефлексия библиотеки {0}",nameAssembly);
			Console.WriteLine();
			reflectionInfoAndRun();
			
		}
		static void reflectionInfoAndRun()
		{
			Assembly assmembly = Assembly.LoadFrom(nameAssembly);
			AssemblyName assemblyName = assmembly.GetName();
			Console.WriteLine("Полное имя: {0}", assemblyName.FullName);
			Console.WriteLine("Версия сборки: {0}", assemblyName.Version);		
			Console.WriteLine();
			Type[] allType = assmembly.GetTypes();
			foreach (Type type in allType)
			{
				Console.WriteLine("Найден тип:"+type.Name);
				ConstructorInfo[] allConstructorInfo = type.GetConstructors();
				foreach (ConstructorInfo constr in allConstructorInfo)
				{
					ParameterInfo[] allParameter = constr.GetParameters();
					Console.Write("Найден конструктор: "+type.Name + "(");
					foreach (ParameterInfo parameter in allParameter)
					{
						Console.Write(parameter.ParameterType.Name + " "+parameter.Name+"; ");
					}
					Console.WriteLine(");");
					if (allParameter.Length == 2)
					{
						object[] constrParam = new object[2];
						constrParam[0] = 2;
						constrParam[1] = 5;
						Console.WriteLine();
						Console.WriteLine("Вызываем конструктор с параметрами: re={0}, im={1}",constrParam[0],constrParam[1]);
						object reflectObject = constr.Invoke(constrParam);
						MethodInfo[] allMethods = type.GetMethods();
						foreach (MethodInfo metod in allMethods)
						{
							Console.WriteLine("Обнаружен метод:"+ metod.Name);
							if (metod.Name == "Sum")
							{
								ParameterInfo[] allMetodParameters = metod.GetParameters();
								Console.WriteLine();
								Console.Write("Метод Sum(");
								foreach (ParameterInfo metodParameter in allMetodParameters)
								{
									Console.Write(metodParameter.ParameterType.Name+" "+metodParameter.Name+"; ");
								}
								Console.WriteLine(");");
								if (allMetodParameters.Length == 1)
								{
									Console.WriteLine("Вызов метода Sum с одним входным параметром.");
									if (allMetodParameters[0].ParameterType.Name == type.Name)
									{
										Console.WriteLine("Вызов метода Sum(this)");
										object[] objParam = new object[1];
										objParam[0]=reflectObject;
										Console.WriteLine("Sum(this)="+metod.Invoke(reflectObject, objParam));
										Console.WriteLine();
									}
								}
							}
							if (metod.Name == "ToString")
							{
								Console.WriteLine();
								Console.WriteLine("Вызов метода " + metod.Name);
								Console.WriteLine(metod.Invoke(reflectObject, null));
							}
						}
					}
				}
			}
		}
	}
}
