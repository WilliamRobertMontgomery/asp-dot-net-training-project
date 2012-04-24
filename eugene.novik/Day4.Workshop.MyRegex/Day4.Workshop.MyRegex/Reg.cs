using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyRegex
{
	public class Reg
	{

		public static string SelectText(string inputString, string searchString)
		{
			string pattern = "(" + searchString + ")";

			string patternReplace = "<b>$1</b>";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string DeleteHtmlTags(string inputString)
		{
			string pattern = @"<.*?>";

			return Regex.Replace(inputString, pattern, String.Empty);
		}

		public static int GetCountWords(string inputString)
		{
			string pattern = @"\b[\w\d]+\b";

			return Regex.Matches(inputString, pattern).Count;
		}

		public static int[] GetCountWordList(string inputString, string[] wordList)
		{
			int[] outputCount = new int[wordList.GetLength(0)];

			for (int i = 0; i < wordList.GetLength(0); i++)
			{
				outputCount[i] = Regex.Matches(inputString, wordList[i]).Count;
			}

			return outputCount;
		}

		public static int GetCountSentences(string inputString)
		{
			string pattern = @"\S[\.!\?]+"; 

			return Regex.Matches(inputString, pattern).Count;
		}

		public static string ReplaceDate(string inputString)
		{
			string pattern = "(?<year>(19\\d{2}|2\\d{3}))\\.(?<month>(0[1-9]|1[012]))\\.(?<day>(0[1-9]|[12]\\d|3[01]))";

			string patternReplace = "${day}.${month}.${year}";
			//string patternReplace = "$3.$2.$1";
			
			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string ReplacePrоtocоl(string inputString)
		{
			string pattern = @"\b(http://)";

			string patternReplace = "ftp://";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string ReplaceEmail(string inputString)
		{
			string pattern = @"\b((\d|\w|-|_|\.)*)@tut.by\b";

			string patternReplace = "$1@gmail.com";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string ReplaceMoney(string inputString)
		{
			string pattern = @"((\d)+) \$";

			string patternReplace = "$1 р";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string ReplacePhone(string inputString)
		{
			string pattern = @"\(0152\)(-[1-9]\d(-\d\d){2})";

			string patternReplace = "(0162)$1";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string ReplaceDecimalDivider(string inputString)
		{
			string pattern = @"\b(\d+)\.(\d+)\b";

			string patternReplace = "$1,$2";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string DeleteSpaces(string inputString)
		{
			string pattern = @" +";

			string patternReplace = " ";

			return Regex.Replace(inputString, pattern, patternReplace);
		}
		
		public static string DeleteQuotes(string inputString)
		{
			string pattern = @"""([^""]*)""";

			string patternReplace = "«$1»";

			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string SelectNameAndExtension(string inputString)
		{
			string pattern = @"\b\w:(\\[\w\W]*?)?\\(\w+\.\w+)\b";

			string patternReplace = "$2";
			
			return Regex.Replace(inputString, pattern, patternReplace);
		}

		public static string VerifySpaces(string inputString)
		{
			string pattern = @"([-\.,:!\?])(\w+)";

			string patternReplace = "$1 $2";

			return Regex.Replace(inputString, pattern, patternReplace);
		}
	}
}
