using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkShop.Day4.RegExp
{
    public class RegExp
    {
        /// <summary>
        /// Highlight the selected word in input string
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <param name="word">Highlighted word</param>
        /// <returns>Highlighted text/string</returns>
        public static string SelectWord(string inputString, string word)
        {
            var pattern = string.Format(@"{0}", Regex.Escape(word));
            var evaluator = string.Format("<b>{0}</b>", word);

            return Regex.Replace(inputString, pattern, evaluator);
        }

        /// <summary>
        /// Counting the frequency of use
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <param name="words">string to compare with text strings</param>
        /// <returns>Enumeration of matches</returns>
        public static IEnumerable<int> CountingFrequencyOfUse(string inputString, string[] words)
        {
            return words.Select(pattern => Regex.Matches(
                inputString,
                string.Format(@"{0}", Regex.Escape(pattern)),
                RegexOptions.IgnoreCase)
                .Count);
        }

        /// <summary>
        /// Counting the number of words
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>Number of words</returns>
        public static int CountingNumberOfWords(string inputString)
        {
            const string pattern = @"[a-zа-яё0-9]*\-?[a-zа-яё]+";
            return Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        /// Counting the number of sentences in the text
        /// </summary>
        /// <param name="inputString">The input string</param>
        /// <returns>Number of sentences</returns>
        public static int CountingNumberOfSentences(string inputString)
        {
            const string pattern = @"(\A\D+?|[.!?;:-])\s*[a-zа-яё]+?";
            return Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        /// Remove all html-tags from text
        /// </summary>
        /// <param name="inputString">Text with html-tags</param>
        /// <returns>Text without html-tags</returns>
        public static string RemoveHtmlTags(string inputString)
        {
            const string pattern = @"<.*?>";
            return Regex.Replace(inputString, pattern, "");
        }

        /// <summary>
        /// Change date to Eastern European format from Western European format
        /// </summary>
        /// <param name="inputString">Date in Western European format</param>
        /// <returns>Date in Eastern European format</returns>
        public static string ChangeDate(string inputString)
        {
            const string pattern = @"(?<yy>\d{4})(?<mm>\.\d{2}\.)(?<dd>\d{2})";
            return Regex.Replace(inputString, pattern, "$3$2$1");
        }

        /// <summary>
        /// Change protocol to ftp from http
        /// </summary>
        /// <param name="inputString">Input http-link in text</param>
        /// <returns>Return ftp-link</returns>
        public static string ChangeProtocol(string inputString)
        {
            const string pattern = @"(http[s]?://)(w{3}\.)?";
            return Regex.Replace(inputString, pattern, "ftp://");
        }

        /// <summary>
        /// Change e-mail addresses from @tut.by to @gmail.com
        /// </summary>
        /// <param name="inputString">Input e-mail in text</param>
        /// <returns>Return e-mail in format @gmail.com</returns>
        public static string ChangeEmail(string inputString)
        {
            const string pattern = @"\@\w+\.\w+";
            return Regex.Replace(inputString, pattern, "@gmail.com");
        }

        /// <summary>
        /// Convert the currency from dollars to rubles
        /// </summary>
        /// <param name="inputString">Input string currency in dollars</param>
        /// <returns>Return currency in rubles</returns>
        public static string ConversionCurrency(string inputString)
        {
            const string pattern = @"\d+\s?\$";
            const int exchangeRate = 10000;
            MatchCollection theMatchCollection = Regex.Matches(inputString, pattern);
            foreach (Match theMatch in theMatchCollection)
            {
                int rubles = int.Parse(theMatch.Value.Trim(new[] { '$', ' ' })) * exchangeRate;
                string replacementString = string.Format("{0}p", rubles);
                string patternFromMatch = Regex.Replace(string.Format("{0}", theMatch.Value), @"\$", @"\$");
                inputString = Regex.Replace(inputString, patternFromMatch, replacementString);
            }

            return inputString;
        }

        /// <summary>
        /// Change the city code Grodno to Brest code
        /// </summary>
        /// <param name="inputString">Input string with Grodno city code</param>
        /// <returns>Return string with Brest city code</returns>
        public static string ChangeCityCode(string inputString)
        {
            const string pattern = @"\(\d+\)(?=[\-\d]+)";
            return Regex.Replace(inputString, pattern, "(0162)");
        }

        /// <summary>
        /// Change the city code Grodno to Brest code
        /// </summary>
        /// <param name="inputString">Input string with Grodno city code</param>
        /// <returns>Return string with Brest city code</returns>
        public static string ChangePointToComma(string inputString)
        {
            const string pattern = @"(?<=\d)\.(?=\d)";
            return Regex.Replace(inputString, pattern, ",");
        }

        /// <summary>
        /// Remove the extra spaces
        /// </summary>
        /// <param name="inputString">Input string with a lot of spaces</param>
        /// <returns>Return norm string</returns>
        public static string DeleteExtraSpaces(string inputString)
        {
            const string pattern = @"\s+(?<=[^\r])";
            return Regex.Replace(inputString, pattern, " ");
        }

        /// <summary>
        /// Change quotes from english to russian
        /// </summary>
        /// <param name="inputString">Input string with english quotes</param>
        /// <returns>Return text with russian quotes</returns>
        public static string ChangeQuotes(string inputString)
        {
            const string pattern = "(?:[\"\']+)([a-zA-Zа-яА-ЯёЁ0-9]+)(?:[\"\']+)";
            return Regex.Replace(inputString, pattern, "<<$1>>");
        }

        /// <summary>
        /// Select the file name and extension
        /// </summary>
        /// <param name="inputString">Input string like a path</param>
        /// <returns>Return file name and extension</returns>
        public static string SelectFileNameWithExtension(string inputString)
        {
            //TODO
            /*
             * The first group it is the file name and extension. Try to pull with replacement
             * const string pattern = @".:\\.+(?<=\\)(\w+\.\w+)";
             */
            const string pattern = @"(?<=\\)[\w\.\s-]+\.\w+$";
            var x = Regex.Match(inputString, pattern).Value;
            return x;
        }

        /// <summary>
        /// Check and alignment spaces
        /// </summary>
        /// <param name="inputString">Input string</param>
        /// <returns>Return refactored text</returns>
        public static string CheckAndAlignmentSpaces(string inputString)
        {
            const string pattern = @"(?<=[a-zA-Zа-яА-ЯёЁ0-9])(?:[,!?.:;]+)(?! )";
            return Regex.Replace(inputString, pattern, "$& ");
        }

        public static void Main()
        {
        }
    }
}