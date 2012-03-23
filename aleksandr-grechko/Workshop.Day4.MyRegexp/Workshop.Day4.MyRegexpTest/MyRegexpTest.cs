using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;



namespace Workshop.Day4.MyRegexp.Test
{	
	[TestFixture]
	public class MyRegexpTest
	{

		[Test]
		public void SelectWordTest()
		{
			string str = "1. Найти и подсветить в тексте все вхождения заданного слова (выражения)";
			string result = "1. Найти и подсветить <b>в тексте<\b> все вхождения заданного слова (выражения)";
			Assert.AreEqual(result, MyRegexp.SelectWord(str, "в тексте"));
		}

		[Test]
		public void CountMatchesAllStringsOfListTest()
		{
			string str = "2. В заданном тексте подсчитать частоту использования каждого буквосочетания, слова и словосочетания из заданного списка";
			string[] patterns = new string[] { "текст", "ка", "с", " ", "каждого буквосочетания", "та", "ща" };
			int[] counts = new int[] { 1, 2, 10, 14, 1, 3, 0};
			Assert.AreEqual(counts, MyRegexp.CountMatchesAllStringsOfList(str, patterns));
		}

		[Test]
		public void CountNumberOfWordsTest()
		{
			string str = "3. Подсчитать в тексте число слов.";
			Assert.AreEqual(6, MyRegexp.CountNumberOfWords(str));
		}

		[Test]
		public void CountNumberOfSentencesTest()
		{
			string str = "Подсчитать количество предложений в тексте. Подсчитать количество (например 4.3) предложений в тексте. Подсчитать количество предложений в тексте.";
			Assert.AreEqual(3, MyRegexp.CountNumberOfSentences(str));
		}
		
		[Test]
		public void RemoveAllHtmlTagsTest()
		{
			string str = @"<div><h1>5.</h1> <a href="">Удалить все html-теги из текста</a></div>";
			string result = "5. Удалить все html-теги из текста";
			Assert.AreEqual(result, MyRegexp.RemoveAllHtmlTags(str));
		}

		[Test]
		public void ChangeDateFormatTest()
		{
			string str = "6. Все даты в тексте записаны в западноевропейском формате: 2012.05.30 Привести их к принятому формату у нас: 30.05.2012. 1996.03.12, 1985.12.01";
			string result = "6. Все даты в тексте записаны в западноевропейском формате: 30.05.2012 Привести их к принятому формату у нас: 30.05.2012. 12.03.1996, 01.12.1985";
			Assert.AreEqual(result, MyRegexp.ChangeDateFormat(str));
		}

		[Test]
		public void ChangeUrlTest()
		{
			string str = "7. Заменить в тексте все http-ссылки на аналогичные ftp-ссылки: http://radsoftware.com.au/web/";
			string result = "7. Заменить в тексте все http-ссылки на аналогичные ftp-ссылки: ftp://radsoftware.com.au/web/";
			Assert.AreEqual(result, MyRegexp.ChangeUrl(str));
		}

		[Test]
		public void ChangeDomainNameTest()
		{
			string str = "8. Заменить в тексте адреса электронной почты xxx@tut.by на xxx@gmail.com";
			string result = "8. Заменить в тексте адреса электронной почты xxx@gmail.com на xxx@gmail.com";
			Assert.AreEqual(result, MyRegexp.ChangeDomainName(str));
		}

		[Test]
		public void ChangeCurrencyTest()
		{
			string str = "9. В тексте указаны стоимости товаров в долларах, например xxx $ ( 345 $, 25$ ). Заменить на аналогичные суммы только в рублях: xxx р.";
			string result = "9. В тексте указаны стоимости товаров в долларах, например xxx $ ( 345 р, 25р ). Заменить на аналогичные суммы только в рублях: xxx р.";
			Assert.AreEqual(result, MyRegexp.ChangeCurrency(str));
		}

		[Test]
		public void ChangePhoneCodeTest()
		{
			string str = "10. В тексте указаны телефонные номера с кодом г. Гродно: (0152)-xx-xx-xx. Заменить во всех номерах код г. Гродно на код г. Бреста (0162). (0152)-34-33-22";
			string result = "10. В тексте указаны телефонные номера с кодом г. Гродно: (0152)-xx-xx-xx. Заменить во всех номерах код г. Гродно на код г. Бреста (0162). (0162)-34-33-22";
			Assert.AreEqual(result, MyRegexp.ChangePhoneCode(str));
		}

		[Test]
		public void ChangeFormatNumbersTest()
		{
			string str = "11. Все вещественные числа 234.0234 в тексте записаны в формате с десятичной точкой. Заменить во всех числах 0.123 точки на запятые.";
			string result = "11. Все вещественные числа 234,0234 в тексте записаны в формате с десятичной точкой. Заменить во всех числах 0,123 точки на запятые.";
			Assert.AreEqual(result, MyRegexp.ChangeFormatNumbers(str));
		}

		[Test]
		public void RemoveSpacesTest()
		{
			string str = "12.   Удалить    в      строке    лишние    пробелы";
			string result = "12. Удалить в строке лишние пробелы";
			Assert.AreEqual(result, MyRegexp.RemoveSpaces(str));
		}

		[Test]
		public void ChangeQuotesTest()
		{
			string str = "13. В тексте заменить все “английские” закрывающие кавычки-“лапки” на русские «елочки».";
			string result = "13. В тексте заменить все «английские» закрывающие кавычки-«лапки» на русские «елочки».";
			Assert.AreEqual(result, MyRegexp.ChangeQuotes(str));
		}

		[Test]
		public void GetFileNameAndExtensionTest()
		{
			string str = @"C:\Program Files\Microsoft Office\OFFICE11\winword.exe";
			string filename = "";
			string ext = "";
			MyRegexp.GetFileNameAndExtension(str, out filename, out ext);
			Assert.AreEqual("winword", filename);
			Assert.AreEqual("exe", ext);
		}

		[Test]
		public void AddSpaceAfterPunctuationMarksTest()
		{
			string str = "15.Проверить и при необходимости,расставить в тексте пробелы:после знаков препинания.";
			string result = "15. Проверить и при необходимости, расставить в тексте пробелы: после знаков препинания.";
			Assert.AreEqual(result, MyRegexp.AddSpaceAfterPunctuationMarks(str));
		}
		
	}
}
