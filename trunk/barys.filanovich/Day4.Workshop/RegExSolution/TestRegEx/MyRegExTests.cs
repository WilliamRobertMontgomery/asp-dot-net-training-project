using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RegEx;

namespace TestRegEx
{
    public class MyRegExTests
    {
        MyRegEx regEx = new MyRegEx();

        [Test]
        public void TestSelectWords()
        {
            string inputString =
                "Существуют две основных трактовки понятия текст: имманентная (расширенная, " +
                "философски нагруженная) и репрезентативная (более частная). Имманентный подход " +
                "подразумевает отношение к тексту как к автономной реальности, нацеленность на выявление " +
                "его внутренней структуры. Репрезентативный — рассмотрение текста как особой формы " +
                "представления знаний о внешней тексту действительности.";
            string pattern = "текст";

            int[] expected = { 42, 180, 300, 355 };
            int[] actual = regEx.SelectWord(inputString, pattern);

            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void TestGetCountOFFoundWords()
        {
            string inputString =
                "Существуют две основных трактовки понятия текст: имманентная (расширенная, " +
                "философски нагруженная) и репрезентативная (более частная). Имманентный подход " +
                "подразумевает отношение к тексту как к автономной реальности, нацеленность на выявление " +
                "его внутренней структуры. Репрезентативный — рассмотрение текста как особой формы " +
                "представления знаний о внешней тексту действительности.";
            string pattern = "текст";

            Assert.AreEqual(4, regEx.GetCountOFFoundWords(inputString, pattern));
        }

        [Test]
        public void TestCountOfSentences()
        {
            string inputString = "The first sentence. My second sentence! Is it sentence? Yes.";

            Assert.AreEqual(4, regEx.GetCountOfSentences(inputString));
        }

        [Test]
        public void TestCountOfWords()
        {
            string inputString = "The first sentence. My second sentence! Is it sentence? Yes.";

            Assert.AreEqual(10, regEx.GetCountOfWords(inputString));
        }

        [Test]
        public void TestRemoveHTMLTags()
        {
            string inputString = "<h1>Lorem ipsum dolor sit amet</h1>";

            Assert.AreEqual(-1, regEx.RemoveHtmlTags(inputString).IndexOfAny(new char [] {'<','>'}));
        }

        [Test]
        public void TestDateReplace()
        {
            string inputString = "2012.03.20";

            StringAssert.AreEqualIgnoringCase("20.03.2012", regEx.DateReplace(inputString));
        }

        [Test]
        public void TestURLReplace()
        {
            string inputString = "http://www.byfly.by";

            StringAssert.AreEqualIgnoringCase("ftp://www.byfly.by", regEx.URLReplace(inputString));
        }

        [Test]
        public void TestMailReplace()
        {
            string inputString = "barys.filanovich@tut.by";

            StringAssert.AreEqualIgnoringCase("barys.filanovich@gmail.com", regEx.MailReplace(inputString));
        }

        [Test]
        public void TestReplaceBucks()
        {
            string inputString = "100 $";

            StringAssert.AreEqualIgnoringCase("100 р.", regEx.ReplaceBucks(inputString));
        }

        [Test]
        public void TestReplaceCode()
        {
            string inputString = "(0152)-55-55-22";

            StringAssert.AreEqualIgnoringCase("(0162)-55-55-22", regEx.ReplaceCode(inputString));
        }

        [Test]
        public void TestReplaceNumber()
        {
            string inputString = "99.99 33.99 12.99";

            StringAssert.AreEqualIgnoringCase("99,99 33,99 12,99", regEx.ReplaceNumber(inputString));
        }

        [Test]
        public void TestRemoveWhiteSpaces()
        {
            string inputString = "Убрать     лишние    пробелы      .      ";

            StringAssert.AreEqualIgnoringCase("Убрать лишние пробелы . ", regEx.RemoveWhiteSpaces(inputString));
        }

        [Test]
        public void TestReplaceQuotes()
        {
            string inputString = "Заменить „лапки“ на «ёлочки»";

            StringAssert.AreEqualIgnoringCase("Заменить «лапки» на «ёлочки»", regEx.ReplaceQuotes(inputString));
        }

        [Test]
        public void TestGetFileName()
        {
            string inputString = @"c:\Temp\Test.txt";

            StringAssert.AreEqualIgnoringCase("Test.txt", regEx.GetFileName(inputString));
        }

        [Test]
        public void CheckWhiteSpace()
        {
            string inputString = "Проверить,расставить порбелы.После знаков препинания.";

            StringAssert.AreEqualIgnoringCase("Проверить, расставить порбелы. После знаков препинания.",
                regEx.CheckWhiteSpace(inputString));
        }
    }
}
