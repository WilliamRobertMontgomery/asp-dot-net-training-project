using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExp
{
    public class RegExp
    {
        public static string Task1(string str, string word)
        {
            string pattern = @"(?=" + word + ")";
            Regex theRegex = new Regex(pattern, RegexOptions.Multiline);
            str = theRegex.Replace(str, "<b>");
            pattern = @"(?<=" + word + ")";
            theRegex = new Regex(pattern, RegexOptions.Multiline);
            str = theRegex.Replace(str, "</b>");
            return str;
        }

        public static int[]  Task2(string str, string[] pattern)
        {
            int[] Count = new int[pattern.Length];
            for (int i = 0; i < pattern.Length; i++)
            {
                Regex theRegex = new Regex(pattern[i], RegexOptions.Multiline);
                MatchCollection theMatchCollection = theRegex.Matches(str);
                Count[i] = theMatchCollection.Count;
            }
            return Count;
        }

        public static int Task3(string str)
        {
            string pattern = @"[\w\d.]+";
            Regex theRegex = new Regex(pattern, RegexOptions.Multiline);
            int CountWords = theRegex.Matches(str).Count;
            return CountWords;
        }
                      
        public static int Task4(string str)
        {
            string pattern = @"[\w\s\d]+.?";
            Regex theRegex = new Regex(pattern, RegexOptions.Multiline);
            int CountSentences = theRegex.Matches(str).Count;
            return CountSentences;
        }
                      
        public static string Task5(string str)
        {
            string pattern = @"</*[\w\d\s=""]+>";
            Regex theRegex = new Regex(pattern, RegexOptions.Multiline);
            str = theRegex.Replace(str, "");
            return str;
        }
                      
        public static string Task6(string str)
        {
            string pattern = @"(\d{4})\.(\d{2})\.(\d{2})";
            Regex theRegex = new Regex(pattern);
            str = theRegex.Replace(str, @"$3.$2.$1");
            return str;
        }
                      
        public static string Task7(string str)
        {
            string pattern = @"http://";
            Regex theRegex = new Regex(pattern);
            str = theRegex.Replace(str, @"ftp://");
            return str;
        }
                      
        public static string Task8(string str)
        {
            string pattern = @"@tut.by";
            Regex theRegex = new Regex(pattern);
            str = theRegex.Replace(str, @"@gmail.com");
            return str;
        }
                      
        public static string Task15(string str)
        {
            string pattern = @"[,!:;.""]\s{0}(?! )";
            Regex theRegex = new Regex(pattern);
            str = theRegex.Replace(str, @"$0 ");
            return str;
        }
    }
}
