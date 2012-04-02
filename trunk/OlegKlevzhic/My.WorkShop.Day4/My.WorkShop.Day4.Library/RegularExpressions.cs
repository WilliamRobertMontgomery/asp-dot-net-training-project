using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace My.WorkShop.Day4.Library
{
	public static class RegularExpressions
	{
		/// <summary>
		/// Allocates the selected word in the text.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <param name="word">Emphasized word.</param>
		/// <returns>The input string with the selected word you choose.</returns>
		public static string SelectWord(string inputString, string word)
		{
			return Regex.Replace(inputString, word, "<Font color = red>" + word + "</font>");
		}

		/// <summary>
		/// Calculating of frequency of use.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <param name="words">A collection of words</param>
		/// <returns>Frequency in a collection.</returns>
		public static IEnumerable<int> FrequencyOfUse(string inputString, IEnumerable<string> words)
		{
			return words.Select(word => Regex.Matches(inputString, word, RegexOptions.IgnoreCase).Count);
		}

		/// <summary>
		/// Calculating of the number of words in the text.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>Number of words.</returns>
		public static int NumberWords(string inputString)
		{
			return Regex.Matches(inputString, @"(\w+(\-\w+)?)", RegexOptions.IgnoreCase).Count;
		}

		/// <summary>
		/// Calculate the number of sentences.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>Number of sentences.</returns>
		public static int NumberSentences(string inputString)
		{
			return Regex.Matches(inputString, @"([^.!?]+[.!?]?)", RegexOptions.IgnoreCase).Count;
		}

		/// <summary>
		/// Remove html tags from a string.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>String without html tags.</returns>
		public static string RemoveHtmlTags(string inputString)
		{
			return Regex.Replace(inputString, @"<.*?>", "");
		}

		/// <summary>
		/// Changing the date format in text.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The text of the amended date format.</returns>
		public static string ConvertDate(string inputString)
		{
			return Regex.Replace(inputString, @"(?<yy>\d{2,4})(?<mm>\.\d{1,2}\.)(?<dd>\d{1,2})", "$3$2$1");
		}

		/// <summary>
		/// Changing the http links in text to ftp.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The text of the modified links.</returns>
		public static string HttpToFtpLink(string inputString)
		{
			return Regex.Replace(inputString, @"(http[s]?://(w{3}\.)?)", "ftp://");
		}

		/// <summary>
		/// Changing email address from Tut.by to Gmail.com.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The modified text.</returns>
		public static string ChangingEmail(string inputString)
		{
			return Regex.Replace(inputString, @"(\@tut.by)", "@gmail.com");
		}

		/// <summary>
		/// The change of currency in the text.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <param name="rate">Rate.</param>
		/// <returns>The text of the amended currency.</returns>
		public static string ConvertCurrency(string inputString, double rate)
		{
			MatchCollection theMatchCollection = Regex.Matches(inputString, @"\d+[\.,]?(\d+)?(\s+)?(?=\$)", RegexOptions.IgnoreCase);
			foreach (Match b in theMatchCollection)
			{
				inputString = Regex.Replace(inputString, "(" + b.Value.Trim().ToString() + @"(\s+)?\$)", (double.Parse(b.Value) * rate).ToString() + "р");
			}
			return inputString;
		}

		/// <summary>
		/// Changing phone code to Brest code.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>Modified text.</returns>
		public static string ConvertDialingCode(string inputString)
		{
			return Regex.Replace(inputString, @"\(\d+\)(?=\-)", "(0162)");
		}

		/// <summary>
		/// Replacing the terms include a comma.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The modified text.</returns>
		public static string PointToCommaInNumber(string inputString)
		{
			return Regex.Replace(inputString, @"(?<=\d)\.(?=\d)", ",");
		}

		/// <summary>
		/// Remove of unnecessary spaces.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The modified text.</returns>
		public static string RemovalOfUnnecessarySpaces(string inputString)
		{
			return Regex.Replace(inputString, @"\s+", " ");
		}

		/// <summary>
		/// Replace quotes.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The modifier text.</returns>
		public static string ReplaceQuotes(string inputString)
		{
			return Regex.Replace(inputString, "(?:[\"\'])([a-zA-Zа-яА-Я0-9]+)(?:[\"\'])", "<<$1>>");
		}

		/// <summary>
		/// Select the file name and extension.
		/// </summary>
		/// <param name="inputString">Input string</param>
		/// <returns>File name and him extension.</returns>
		public static string SelectFileNameWithExtension(string inputString)
		{
			return Regex.Match(inputString, @"(?<=\\)[\w\.\s-]+\.\w+$").Value;
		}

		/// <summary>
		/// Check and alignment spaces.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		/// <returns>The modified text.</returns>
		public static string CheckAndAlignmentSpaces(string inputString)
		{
			return Regex.Replace(inputString, @"(?<=[a-zA-Zа-яА-Я0-9])(?:[,!?.:;]+)(?! )", "$0 ");
		}
	}
}
