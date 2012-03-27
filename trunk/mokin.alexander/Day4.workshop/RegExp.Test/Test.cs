using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RegExp.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestSerchWord()
        {
            RegExpr regularExp = new RegExpr();
            string word = "hello";
            string inputString = "Hello, lalalal, hello";
            string result = regularExp.SearchWord(inputString, word);
            string expected = @"<b>Hello</b>, lalalal, <b>hello</b>";
            Assert.IsTrue(result == expected);
        }

        [Test]
        public void TestCountArgs()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "Онегин, добрый мой приятель, родился на брегах Невы, где, может быть, родились вы или блистали, мой читатель";
            int [] result = regularExp.countArgs(inputString, "родился" , "бр");
            int[] expected = { 1, 2 };
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TestCountWords()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "При использовании вызовов статически? sdfdasg, sgjg! ыаываыфа";
            int result = regularExp.countWords(inputString);
            int expected = 7;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TestCountSentences()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "При использовании вызовов статически? sdfdasg, sgjg! ыаываыфа... dsagg.";
            int result = regularExp.countSentences(inputString);
            int expected = 4;
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TestDeleteHtmlTags()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "<p>При использовании</p> выз<html>ов</html>ов статически? sdfdasg, sgjg! ыаываыфа... dsagg.<head></head>";
            string result = regularExp.deleteHtmlTags(inputString);
            string expected = "При использовании вызовов статически? sdfdasg, sgjg! ыаываыфа... dsagg.";
            Assert.AreEqual(result, expected);
        }


        [Test]
        public void TestConvertDate()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "Завтра 1939.09.01, послезавтра 1939.09.02";
            string result = regularExp.convertDate(inputString);
            string expected = "Завтра 01.09.1939, послезавтра 02.09.1939";
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void TestHttpToFtp()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "http://mail.ru/";
            string result = regularExp.changeHttpToFtp(inputString);
            string expected = "ftp://mail.ru/";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestTutToGmail()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "citizen@tut.by, wArrior@tut.by";
            string result = regularExp.changeTutToGmail(inputString);
            string expected = "citizen@gmail.com, wArrior@gmail.com";
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void TestСonvertCurrencies()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "cost: 4543684$,45489 $ ";
            string result = regularExp.convertCurrencies(inputString);
            string expected = "cost: 4543684р,45489 р ";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestChangeAreaCode()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "(0152)-25-54-60, dfdf (0152)-25-54-70.";
            string result = regularExp.changeAreaCode(inputString);
            string expected = "(0162)-25-54-60, dfdf (0162)-25-54-70.";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestChangePointOnComma()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "Фдыфвлопаыфлоа, dakjgfkdajf, 45.15. 51.3 dkjfdfj.";
            string result = regularExp.ChangePointOnComma(inputString);
            string expected = "Фдыфвлопаыфлоа, dakjgfkdajf, 45,15. 51,3 dkjfdfj.";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestDeleteExtraSpaces()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "Фдыфвлопаыфлоа, dakjgfkdajf   , 45.15.    51.3   dkjfdfj.";
            string result = regularExp.deleteExtraSpaces(inputString);
            string expected = "Фдыфвлопаыфлоа, dakjgfkdajf, 45.15. 51.3 dkjfdfj.";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestChangeQuotes()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = "Фдыфвлопаыфлоа  «/»,  dakjg      fkdaj  f, 45.15. 51.3 dkjfdfj.";
            string result = regularExp.changeQuotes(inputString);
            string expected = "Фдыфвлопаыфлоа  «/\",  dakjg      fkdaj  f, 45.15. 51.3 dkjfdfj.";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestSelectFileName()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = @"E:\c#\googlecode.txt";
            string result = regularExp.selectFileName(inputString);
            string expected = "googlecode.txt";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestCheckPunctuationMarks()
        {
            RegExpr regularExp = new RegExpr();
            string inputString = @"ыфафап,фа (пфы)апdafsdf.dkjfdjf!daskjf.";
            string result = regularExp.checkPunctuationMarks(inputString);
            string expected = "ыфафап, фа (пфы) апdafsdf. dkjfdjf! daskjf.";
            Assert.AreEqual(expected, result);
        }






        
    }
}
