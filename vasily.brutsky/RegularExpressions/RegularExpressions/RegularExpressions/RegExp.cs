using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace RegularExpressions
{
    public class RegExp
    {
            public static string SelectWord(string str, string word)
            {
                string pattern =  @"\b" + @word + @"\b";
                Regex NewRegex = new Regex(pattern);
                Match theMatch= NewRegex.Match(str);
                str = NewRegex.Replace(str, "<b>"+theMatch.ToString()+"</b>");
                return str;
            }


            public static int CountWords(string str)
            {
                string pattern = @"\S+";
                Regex NewRegex = new Regex(pattern);

                MatchCollection theMatchCollection = NewRegex.Matches(str);
                return theMatchCollection.Count;
            }

            public static int NumberOfSentences(string str)
            {
                string pattern = @"\.";
                Regex NewRegex = new Regex(pattern);
                MatchCollection theMatchCollection = NewRegex.Matches(str);
                return theMatchCollection.Count;
            }




            public static string DeleteHtmlTags(string str)
            {

                string pattern = @"<.*?>";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, "");
                return outputString;

            }

            public static string ChangeHttpToFtp(string str)
            {
                string pattern = @"http";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, "ftp");
                return outputString;

            }


            public static string ChangeEmails(string str)
            {
                string pattern = @"tut.by";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, "gmail.com");
                return outputString;

            }

            public static string ChangeDollars(string str)
            {
                string pattern = @"\$";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, "р");
                return outputString;

            }


            public static string ChangeCode(string str)
            {
                string pattern = @"\(0152\)";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, "(0162)");
                return outputString;

            }

            public static string RemoveSpaces(string str)
            {
                string pattern = @"  +";
                Regex theRegex = new Regex(pattern);
                string outputString = theRegex.Replace(str, " ");
                return outputString;

            }

            
        }

    }
