using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegEx
{
    public class MyRegEx
    {
        public int[] SelectWord(string inputString, string pattern)
        {
            int[] firstChars;

            MatchCollection myMatches = Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase);

            firstChars = new int[myMatches.Count];

            for (int i = 0; i < firstChars.Length; i++)
            {
                firstChars[i] = myMatches[i].Index;
            }

            for (int i = 0; i < inputString.Length; i++)
            {
                foreach (Match nextMatch in myMatches)
                {
                    if ((i >= nextMatch.Index) && (i < nextMatch.Index + nextMatch.Length))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                }
                Console.Write(inputString[i]);
            }

            return firstChars;
        }

        public int GetCountOFFoundWords(string inputString, string pattern)
        {
            MatchCollection myMatches = Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase);

            return myMatches.Count;
        }

        public int GetCountOfSentences(string inputString)
        {
            string pattern = @"[\.?!]+\s*";
            MatchCollection myMatches = Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase);
            return myMatches.Count;
        }

        public int GetCountOfWords(string inputString)
        {
            string pattern = @"\b\w+\b";
            MatchCollection myMatches = Regex.Matches(inputString, pattern,
                RegexOptions.IgnoreCase);
            return myMatches.Count;
        }

        public string RemoveHtmlTags(string inputString)
        {
            string pattern = @"<.*?>";

            return Regex.Replace(inputString, pattern, string.Empty);
        }

        public string DateReplace(string inputString)
        {
            string pattern = @"(\d{4}).(\d{1,2}).(\d{1,2})";

            return Regex.Replace(inputString, pattern, String.Format(@"$3.$2.$1"));
        }

        public string URLReplace(string inputString)
        {
            string pattern = @"\b(http)(://\S+)\b";

            return Regex.Replace(inputString, pattern, String.Format(@"ftp$2"));
        }

        public string MailReplace(string inputString)
        {
            string pattern = @"\b(\S+)(@tut.by)\b";

            return Regex.Replace(inputString, pattern, String.Format(@"$1@gmail.com"));
        }

        public string ReplaceBucks(string inputString)
        {
            string pattern = @"(\d+)\s?\$";

            return Regex.Replace(inputString, pattern, String.Format(@"$1 р."));
        }

        public string ReplaceCode(string inputString)
        {
            string pattern = @"\((0152)\)([0-9-]{8,})";

            return Regex.Replace(inputString, pattern, String.Format(@"(0162)$2"));
        }

        public string ReplaceNumber(string inputString)
        {
            string pattern = @"(\d+)\.(\d+)";

            return Regex.Replace(inputString, pattern, String.Format(@"$1,$2"));
        }

        public string RemoveWhiteSpaces(string inputString)
        {
            string pattern = @"\s+";
            return Regex.Replace(inputString, pattern, @" ");
        }

        public string ReplaceQuotes(string inputString)
        {
            string pattern = @"\„([\w\W]+)\“";
            return Regex.Replace(inputString, pattern, @"«$1»");
        }

        public string GetFileName(string inputString)
        {
            string pattern = @"\b\w:{1}\\[\w\W]+\\([\w\W]+)\.(\w+)\b";
            return Regex.Replace(inputString, pattern, @"$1.$2");
        }

        public string CheckWhiteSpace(string inputString)
        {
            string pattern = @"[\.,:!\?-](?!\s|\Z)";
            return Regex.Replace(inputString, pattern, @"$0 ");
        }
    }
}
