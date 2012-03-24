using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Workshop.Day4.MyRegexp
{
	public class MyRegexp
	{
		public static string SelectWord(string str, string pattern)
		{
			return Regex.Replace(str, @"\b("+Regex.Escape(pattern)+@")\b", "<b>$1<\b>");
		}

		public static int[] GetMatchesAllStringsOfList(string str, string[] patterns)
		{
			int[] result = new int[patterns.Length];
			for (int i = 0; i < patterns.Length; i++)
			{
				result[i] = Regex.Matches(str, patterns[i]).Count;
			}
			return result;
		}

		public static int GetNumberOfWords(string str)
		{
			return Regex.Matches(str, @"\w+").Count;
		}

		public static int GetNumberOfSentences(string str)
		{
			return Regex.Matches(str, @"\.(\s+|$)").Count;
		}

		public static string RemoveAllHtmlTags(string str)
		{
			return Regex.Replace(str, @"<.*?>", "");
		}

		public static string ChangeDateFormat(string str)
		{
			return Regex.Replace(str, @"\b(\d{4})\.(\d\d)\.(\d\d)\b", @"$3.$2.$1");
		}

		public static string ChangeUrl(string str)
		{
			return Regex.Replace(str, "http://", "ftp://", RegexOptions.IgnoreCase);
		}

		public static string ChangeDomainName(string str)
		{
			return Regex.Replace(str, @"(?<=\b\w+)@tut.by", "@gmail.com", RegexOptions.IgnoreCase);
		}

		public static string ChangeCurrency(string str)
		{
			return Regex.Replace(str, @"(?<=\d+ ?)\$", "р");
		}

		public static string ChangePhoneCode(string str)
		{
			return Regex.Replace(str, @"\(0152\)(?=(-\d\d){3})", "(0162)");
		}

		public static string ChangeFormatNumbers(string str)
		{
			return Regex.Replace(str, @"(?<=\d)\.(?=\d)", ",");
		}

		public static string RemoveSpaces(string str)
		{
			return Regex.Replace(str, @" +", " ");
		}

		public static string ChangeQuotes(string str)
		{
			return Regex.Replace(str, @"“(.*?)”", @"«$1»");
		}

		public static void GetFileNameAndExtension(string str, out string filename, out string ext)
		{
			Match result = Regex.Match(str, @"(?:[\/\\]|^)(.+?)(?:\.(.{1,3}))?$", RegexOptions.RightToLeft);
			filename = result.Groups[1].Value;
			ext = result.Groups[2].Value;
		}

		public static string AddSpaceAfterPunctuationMarks(string str)
		{
			return Regex.Replace(str, @"[\.,:!\?-](?!\s|\Z)", "$0 ");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			//Console.Read();
		}
	}
}
