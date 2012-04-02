using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using My.WorkShop.Day4.Library;
using NUnit.Framework;

namespace My.WorkShop.Day4.Application
{
	[TestFixture]
	class Program
	{
		static void Main(string[] args)
		{
		}

		[Test]
		public void SelectWordTest()
		{
			string actual = "Подсветка <Font color = red>слова</font> в тексте.";
			string expected = RegularExpressions.SelectWord("Подсветка слова в тексте.", "слова");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void FrequencyOfUse()
		{
			IEnumerable<int> actual = new[] { 1, 5, 1 };
			IEnumerable<int> expected = RegularExpressions.FrequencyOfUse("ПервоеСлово слово ВтороеСлово ВтороеСлово ТретьеСлово", new[] { "ПервоеСлово", "слово", "ТретьеСлово" });
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NumberWords()
		{
			int actual = 3;
			int expected = RegularExpressions.NumberWords("Тут 3 слова.");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void NumberSentences()
		{
			int actual = 2;
			int expected = RegularExpressions.NumberSentences("Тут 1 предложение. Хотя не - два!");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void RemoveHtmlTags()
		{
			string actual = "Без тегов.";
			string expected = RegularExpressions.RemoveHtmlTags("</br>Без <b>тегов</b>.");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ConvertDate()
		{
			string actual = "10.12.2012";
			string expected = RegularExpressions.ConvertDate("2012.12.10");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void HttpToFtpLink()
		{
			string actual = "ftp://link.com ftp://dasd.ru ff://dsa.cc";
			string expected = RegularExpressions.HttpToFtpLink("http://www.link.com https://dasd.ru ff://dsa.cc");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ChangingEmail()
		{
			string actual = "Email_1@gmail.com Email_2@mail.ru Email_3@h.com";
			string expected = RegularExpressions.ChangingEmail("Email_1@tut.by Email_2@mail.ru Email_3@h.com");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ConvertCurrency()
		{
			string actual = "Стоимость вещи 20000р";
			string expected = RegularExpressions.ConvertCurrency("Стоимость вещи 2000$", 10);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ConvertDialingCode()
		{
			string actual = "(0162)-4562-321-21 (0162)-231-21-1";
			string expected = RegularExpressions.ConvertDialingCode("(0152)-4562-321-21 (0152)-231-21-1");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void PointToCommaInNumber()
		{
			string actual = "Число 3,14. 4,56 тоже число, а 1 просто цифра :).";
			string expected = RegularExpressions.PointToCommaInNumber("Число 3.14. 4.56 тоже число, а 1 просто цифра :).");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void RemovalOfUnnecessarySpaces()
		{
			string actual = "Тут нужно убирать пробелы, а тут нет!";
			string expected = RegularExpressions.RemovalOfUnnecessarySpaces("Тут    нужно  убирать  пробелы,  а тут нет!");
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void ReplaceQuotes()
		{
			string actual = "<<В кавычках>>";
			string expected = RegularExpressions.ReplaceQuotes("\'В кавычках\'");
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void SelectFileNameWithExtension()
		{
			string actual = "004567.jpg";
			string expected = RegularExpressions.SelectFileNameWithExtension("C:\\004567.jpg");
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void CheckAndAlignmentSpaces()
		{
			string actual = "Знаки, препинания, с, пробелами";
			string expected = RegularExpressions.CheckAndAlignmentSpaces("Знаки, препинания, с, пробелами");
			Assert.AreEqual(expected, actual);
		}
	}
}
