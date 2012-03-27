using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace RegExp
{
    
    public class RegExpr : IRegExp
    {
       
        public string SearchWord(string inputString, string word)
        {
            string pattern = @"\b(" + Regex.Escape(word) + @")\b";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, @"<b>$1</b>");        
        }

        public int [] countArgs(string inputString, params string[] args)
        {
            int[] count = new int[args.Length];
            string pattern;
            for (int i = 0; i < args.Length; i++)
            {
                pattern = @"(\b" + Regex.Escape(args[i]) + "\b)|("+ Regex.Escape(args[i]) + ")";
                count[i] = Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase).Count;
            }
            return count;
        }

        public int countWords(string inputString)
        {
            string pattern = @"\b\w+\b";
            Regex theRegex = new Regex(pattern);
            return theRegex.Matches(inputString).Count;
        }

        public int countSentences(string inputString)
        {
            string pattern = @"[.!?]+(\s|$|)";
            Regex theRegex = new Regex(pattern);
            return theRegex.Matches(inputString).Count;
        }

        public string deleteHtmlTags(string inputString)
        {
            string pattern = @"<.+?>";
            Regex theRegex = new Regex(pattern);
            return theRegex.Replace(inputString, "");
        }

        public string convertDate(string inputString)
        {
            string pattern =@"(\d{4}).(\d{2}).(\d{2})";
            Regex theRegex = new Regex(pattern);
            return theRegex.Replace(inputString, "$3.$2.$1");
        }
        
        public string changeHttpToFtp(string inputString)
        {
            string pattern = @"http(://[a-zA-Z0-9]+?\.[a-zA-Z]{2,4}[^\s]*\b)";
            Regex theRegex = new Regex(pattern);
            return theRegex.Replace(inputString, "ftp$1");
        }

        public string changeTutToGmail(string inputString)
        {
            string pattern = @"([a-zA-Z0-9]+?@)tut.by\b";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, "$1gmail.com");
        }

        public string convertCurrencies(string inputString)
        {
            string pattern = @"(\b\d+?\s*?)\$";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, "$1р");
        }
     
        public string changeAreaCode(string inputString)
        {
            string pattern = @"\(0152\)(-\d{2}-\d{2}-\d{2})";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, "(0162)$1");
        }

        public string ChangePointOnComma(string inputString)
        {
            string pattern = @"(\d+?)\.(\d+?\b)";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, "$1,$2");
        }

        public string chooseVariant(Match match) //для функции deleteExtraSpaces
        {
            if (match.Value[match.Value.Length-1] == ' ') return " ";
            else return ",";
        }

        public string deleteExtraSpaces(string inputString)
        {
            string pattern = @"([ ]{1,},)|([ ]{2,})";
            Regex theRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            return theRegex.Replace(inputString, new MatchEvaluator(chooseVariant));
        }

        public string changeQuotes(string inputString)
        {
            string pattern = @"»";
            return Regex.Replace(inputString, pattern, "\"");
        }

        public string selectFileName(string inputString)
        {
            string pattern = @"([-_A-Za-zА-Яа-я0-9]+?\.[a-z]+?)$";
            return Regex.Match(inputString, pattern).Value;
        }

        public string checkPunctuationMarks(string inputString)
        {
            string pattern = "([),.?!:\";])(\\w)";
            return Regex.Replace(inputString, pattern, "$1 $2");
        }
    }
}
