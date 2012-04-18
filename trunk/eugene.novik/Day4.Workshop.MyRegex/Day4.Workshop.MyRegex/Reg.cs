using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyRegex
{
	public class Reg
	{
		public static void Task0()
		{
			string inputString = "<html><head><title>TITLE</title></head><body>BODY</body></html>";
			string outputString;

			string pattern = @"<.*?>";

			Regex theRegex = new Regex(pattern);

			MatchCollection theMatchCollection = theRegex.Matches(inputString);

			foreach (Match theMatch in theMatchCollection)
			{
				Console.WriteLine("Результат: {0}", theMatch);
			}

			outputString = Regex.Replace(inputString, pattern, "1");

			Console.WriteLine("Результат2: " + outputString);

		}


		public static string SelectText(string inputString, string searchString)
		{
			throw new NotImplementedException();
		}


		public static string DeleteHtmlTags(string inputString)
		{
			string pattern = @"<.*?>";

			Regex theRegex = new Regex(pattern);

			string outputString = Regex.Replace(inputString, pattern, "");

			Console.WriteLine("Результат: " + outputString);

			return outputString;
		}



		public static int GetCountWords(string inputString)
		{
			throw new NotImplementedException();
		}

		public static int[] GetCountWordList(string inputString, List<string> wordList)
		{
			throw new NotImplementedException();
		}

		public static int GetCountSentences(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplaceDate(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplacePrоtocоl(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplaceEmail(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplaceMoney(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplacePhone(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string ReplaceDecimalDivider(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string DeleteSpaces(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string DeleteQuotes(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string[] SelectNameAndExtension(string inputString)
		{
			throw new NotImplementedException();
		}

		public static string VerifySpaces(string inputString)
		{
			throw new NotImplementedException();
		}
	}
}
