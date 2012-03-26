using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace My.RegularExpression
{
	public class RegularExpression:ITasksRegularExpressions
	{

		public string searchExpression(string text, string word, bool ignoreCase)
		{
			string pattern = @"\b(" + word + @")\b";
			if (ignoreCase)
			{
				return Regex.Replace(text, pattern, "<b>$1</b>", RegexOptions.IgnoreCase);
			}
			else
			{
				return Regex.Replace(text, pattern, "<b>$1</b>");
			}
		}

		public int[] countUse(string text, List<string> listWord, bool ignoreCase)
		{
			int[] result=new int[listWord.Count];
			for(int i=0;i<listWord.Count;i++)
			{
				if (ignoreCase)
				{
					result[i] = Regex.Matches(text, listWord[i].ToString(), RegexOptions.IgnoreCase).Count;
				}
				else
				{
					result[i] = Regex.Matches(text, listWord[i].ToString()).Count;
				}
			}
			return result;
		}

		public int countWords(string text)
		{
			string pattern = @"\b(\w+)\b";
			return Regex.Matches(text, pattern).Count;
		}

		public int countSentence(string text)
		{
			string pattern = @"[.?!]+(\s+|$)";
			return Regex.Matches(text, pattern).Count;
		}

		public string dellAllHTMLTags(string text)
		{
			string pattern = @"\s?<.+>\s?";
			return Regex.Replace(text,pattern," ");
		}

		public string standartDateFormat(string text)
		{
			string pattern = @"([0-9]{4})\.(0?[0-9]|1[0-2])\.([0-2]?[0-9]|3[01])([^0-9])$?";
			return Regex.Replace(text, pattern, @"$3.$2.$1$4");
		}

		public string substituteHTMLForFTP(string text, bool ignoreCase)
		{
			string pattern = @"\bhttp://";
			if (ignoreCase)
			{
				return Regex.Replace(text, pattern, @"ftp://", RegexOptions.IgnoreCase);
			}
			else
			{
				return Regex.Replace(text, pattern, @"ftp://");
			}
		}

		public string substituteEmail(string text, bool ignoreCase)
		{
			string pattern = @"@tut.by";
			if (ignoreCase)
			{
				return Regex.Replace(text, pattern, @"@gmail.com", RegexOptions.IgnoreCase);
			}
			else
			{
				return Regex.Replace(text, pattern, @"@gmail.com");
			}
		}

		public string substituteDollarForRouble(string text)
		{
			string pattern = @"(\d+\s+)\$";
			return Regex.Replace(text, pattern, @"$1р.");
		}

		public string substitutePrefix(string text, string prefix,string replaced)
		{
			string pattern = @"\("+prefix+@"\)(-\d{2}-\d{2}-\d{2}\s?$?)";
			return Regex.Replace(text, pattern, "("+replaced+@")$1");
		}

		public string substitutePoinInNumberForComma(string text)
		{
			string pattern = @"(\s|^)(\d+)\.(\d+)(\s|$|\.\s)";
			return Regex.Replace(text, pattern, "$1$2,$3$4");
		}

		public string dellUnnecessarySpace(string text)
		{
			string pattern = @"^\s+|\s+$|\s+([.,;:!?]+)";
			text= Regex.Replace(text, pattern, "$1");
			pattern = @"\s+";
			return Regex.Replace(text, pattern, " ");
		}

		public string changeQuote(string text)
		{
			string pattern = "([ ^(-]+)\"";
			text = Regex.Replace(text, pattern, "$1«");
			pattern = "\"([ .;:$)-]+)";
			return Regex.Replace(text, pattern, "»$1");
		}

		public string selectFile(string text)
		{
			string pattern = @"[^*<>|\\]+\.\w+(\s|$)";
			return Regex.Match(text, pattern).Value;
		}

		public string insertSpaces(string text)
		{
			string pattern = @"([.,;:!?()-]+)([^ 0-9]\s?)";
			return Regex.Replace(text, pattern,"$1 $2");
		}
	}
}
