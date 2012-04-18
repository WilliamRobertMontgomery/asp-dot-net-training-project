using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRegex
{
	class Program
	{
		static void Main(string[] args)
		{
			Reg.DeleteHtmlTags("<html><head><title>TITLE</title></head><body>BODY</body></html>");

			Console.ReadKey();
		}
	}
}
