using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RegularExpressions;



namespace RegularExpressions.Tests
{
    [TestFixture]
    public class RegularExpressionsTests
    {
        [Test]
        public void SelectWordTest()
        {
            string str = "Hello, world";
            string result = "Hello, <b>world</b>";

            Assert.AreEqual(result, RegExp.SelectWord(str, "world"));
        }

        [Test]

        public void CountWordsTest()
        {
            string str = "1234 345 234 5";
            int result = 4;

            Assert.AreEqual(result, RegExp.CountWords(str));
        }

        [Test]
        public void NumberOfSentencesTest()
        {
            string str = "123123. sdf. aaaas d fff s.";
            int result = 3;

            Assert.AreEqual(result, RegExp.NumberOfSentences(str));
        }

        [Test]
        public void DeleteHtmlTagsTest()
        {
            string str = @"<p><b>Википедия</b> — свободная энциклопедия,
                                   в которой <i>каждый</i> может изменить или дополнить
                                   любую <  span>статью</span></p>.";
            string result = @"Википедия — свободная энциклопедия,
                                   в которой каждый может изменить или дополнить
                                   любую статью.";

            Assert.AreEqual(result, RegExp.DeleteHtmlTags(str));
        }

        [Test]
        public void ChangeHttpToFtpTest()
        {
            string str = @"http:\\google.com, sdsfsdf a http:\\epam.by.";
            string result = @"ftp:\\google.com, sdsfsdf a ftp:\\epam.by.";

            Assert.AreEqual(result, RegExp.ChangeHttpToFtp(str));
        }

        [Test]
        public void ChangeEmailsTest()
        {
            string str = @"vaselOK@tut.by , sdsfsdf a sdf@tut.by";
            string result = @"vaselOK@gmail.com , sdsfsdf a sdf@gmail.com";

            Assert.AreEqual(result, RegExp.ChangeEmails(str));
        }

        [Test]
        public void ChangeDollarsTest()
        {
            string str = @"price: 1800$ , sdsfsdf a sdf 1800$";
            string result = @"price: 1800р , sdsfsdf a sdf 1800р";

            Assert.AreEqual(result, RegExp.ChangeDollars(str));
        }

        [Test]
        public void ChangeCodeTest()
        {
            string str = @"8-(0152)-0152-45-458";
            string result = @"8-(0162)-0152-45-458";

            Assert.AreEqual(result, RegExp.ChangeCode(str));
        }

        [Test]
        public void RemoveSpacesTest()
        {
            string str = @"asd    sd ss aa      d s";
            string result = @"asd sd ss aa d s";
            Assert.AreEqual(result, RegExp.RemoveSpaces(str));

        }


    }
}
