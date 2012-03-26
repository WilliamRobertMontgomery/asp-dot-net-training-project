using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RegExpTests
{
    [TestFixture]
    public class RegExpTests
    {
        [Test]
        public void TestTask1()
        {
            string actual = RegExp.RegExp.Task1("Наша Маша громко плачет", "Маша");
            Assert.AreEqual("Наша <b>Маша</b> громко плачет", actual);
        }

        [Test]
        public void TestTask2()
        {
            string[] testArr = { "Маша", "ша", "громко" };
            int[] actual = RegExp.RegExp.Task2("Наша Маша громко громко плачет", testArr);
            int[] expected = { 1, 2, 2 };
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void TestTask3()
        {
           int actual = RegExp.RegExp.Task3("Наша Маша громко плачет");
           Assert.AreEqual(4, actual);
        }

        [Test]
        public void TestTask4()
        {
            int actual = RegExp.RegExp.Task4(@"Наша Маша громко плачет. Второе предложение.Третье.");
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void TestTask5()
        {
            string actual = RegExp.RegExp.Task5( @"</html>Наша <b>Маша</b> <font color=""red"">громко</font> плачет</html>");
            Assert.AreEqual("Наша Маша громко плачет", actual);
        }

        [Test]
        public void TestTask6()
        {
            string actual = RegExp.RegExp.Task6(@"2009.04.12 2020.12.26 1500.12.23");
            Assert.AreEqual("12.04.2009 26.12.2020 23.12.1500", actual);
        }

        [Test]
        public void TestTask7()
        {
            string actual = RegExp.RegExp.Task7(@"http://music.yandex.ru/");
            Assert.AreEqual("ftp://music.yandex.ru/", actual);
        }

        [Test]
        public void TestTask8()
        {
            string actual = RegExp.RegExp.Task8(@"MyMail1@tut.by MyMail2@tut.by My.Mail3@tut.by");
            Assert.AreEqual("MyMail1@gmail.com MyMail2@gmail.com My.Mail3@gmail.com", actual);
        }

        [Test]
        public void TestTask15()
        {
            string actual = RegExp.RegExp.Task15(@"Наша Маша громко плачет!,уронила в речку мячик");
            Assert.AreEqual("Наша Маша громко плачет! , уронила в речку мячик", actual);
        }
    }
}
