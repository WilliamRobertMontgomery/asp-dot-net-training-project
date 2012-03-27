using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExp
{
    interface IRegExp
    {
        string SearchWord(string inputString, string word);       //Найти и подсветить в тексте все вхождения заданного слова (выражения).
        int[] countArgs(string inputString, params string[] args);//считает сколько раз в тексте встретился i-й args
        int countWords(string inputString);                       //считает слова в предложении
        int countSentences(string inputString);                   //считает предложения
        string deleteHtmlTags(string inputString);                //удаляет html теги
        string convertDate(string inputString);                   //ковертирует западноевропейский формат даты в наш
        string changeHttpToFtp(string inputString);               //поменять http на ftp
        string changeTutToGmail(string inputString);              //поменять xxx@tut.by на xxx.gmail.com
        string convertCurrencies(string inputString);             //из $ в р
        string changeAreaCode(string inputString);                //поменять телефонный код города
        string ChangePointOnComma(string inputString);            //поменять в вещественных числах , на .
        string deleteExtraSpaces(string inputString);             //удалить лишние пробелы
        string changeQuotes(string inputString);                  //поменять кавычки-елочка на "
        string selectFileName(string inputString);                //из локального пути выбрать имя файла
        string checkPunctuationMarks(string inputString);         //проверить пробелы после знаков препинания
    }
}
