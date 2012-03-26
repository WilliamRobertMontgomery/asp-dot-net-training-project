using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace My.RegularExpression.Tests
{
	[TestFixture]
	public class RegularExpressionTest
	{
		private RegularExpression regularExpression;

		[TestFixtureSetUp]
		public void SetUp()
		{
			regularExpression = new RegularExpression();
		}

		[Test]
		public void searchExpression()
		{
			string text = "Найти и подсветить в тексте все вхождения заданного слова (выражения).";
			string word = "все";
			string expected = regularExpression.searchExpression(text,word,true);
			string actual = @"Найти и подсветить в тексте <b>все</b> вхождения заданного слова (выражения).";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void countUse()
		{
			string text = "В заданном тексте подсчитать частоту использования каждого буквосочетания, слово и словосочетания из заданного списка";
			List<string> listWord = new List<string> { "соч", "слово", "В заданном" };
			int[] expected = regularExpression.countUse(text, listWord, true);
			int[] actual = {2, 2, 1};
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void countWords()
		{
			string text = "Подсчитать в тексте число слов.";
			int expected = regularExpression.countWords(text);
			int actual = 5;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void countSentence()
		{
			string text = "Подсчитать количество предложений в тексте. Здесь два предложения!";
			int expected = regularExpression.countSentence(text);
			int actual = 2;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void dellAllHTMLTags()
		{
			string text = "Удалить <HR  size  =10 > все html-теги из текста.";
			string expected = regularExpression.dellAllHTMLTags(text);
			string actual = "Удалить все html-теги из текста.";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void standartDateFormat()
		{
			string text = "Все даты 2012.03.24 в тексте записаны 2012.3.4 в западноевропейском 2015.13.35 формате: yyyy.mm.dd. Привести их к принятому формату у нас: дд.мм.гггг";
			string expected = regularExpression.standartDateFormat(text);
			string actual = "Все даты 24.03.2012 в тексте записаны 4.3.2012 в западноевропейском 2015.13.35 формате: yyyy.mm.dd. Привести их к принятому формату у нас: дд.мм.гггг";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void substituteHTMLForFTP()
		{
			string text = "Заменить http://msdn.microsoft.com/ru-ru/library/hs600312.aspx в тексте все http-ссылки на аналогичные ftp-ссылки";
			string expected = regularExpression.substituteHTMLForFTP(text, true);
			string actual = "Заменить ftp://msdn.microsoft.com/ru-ru/library/hs600312.aspx в тексте все http-ссылки на аналогичные ftp-ссылки";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void substituteEmail()
		{
			string text = "Заменить EdikTrutsik@tut.by в тексте адреса tut.by электронной почты xxx@tut.by на xxx@gmail.com";
			string expected = regularExpression.substituteEmail(text, true);
			string actual = "Заменить EdikTrutsik@gmail.com в тексте адреса tut.by электронной почты xxx@gmail.com на xxx@gmail.com";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void substituteDollarForRouble()
		{
			string text = "В тексте указаны стоимости товаров 200 $ в долларах, например xxx $. Заменить на аналогичные суммы только в рублях: xxx р.";
			string expected = regularExpression.substituteDollarForRouble(text);
			string actual = "В тексте указаны стоимости товаров 200 р. в долларах, например xxx $. Заменить на аналогичные суммы только в рублях: xxx р.";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void substitutePrefix()
		{
			string text = "В тексте указаны телефонные номера (0152)-45-21-79 с кодом г. Гродно: (0152)-xx-xx-xx. Заменить во всех номерах код г. Гродно на код г. Бреста (0162)";
			string expected = regularExpression.substitutePrefix(text, "0152", "0162");
			string actual = "В тексте указаны телефонные номера (0162)-45-21-79 с кодом г. Гродно: (0152)-xx-xx-xx. Заменить во всех номерах код г. Гродно на код г. Бреста (0162)";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void substitutePoinInNumberForComma()
		{
			string text = "3.5 Все вещественные числа в тексте записаны в формате с десятичной точкой, например: 12.56 или 0.358. Кроме того точками также разделены предложения внутри текста. Заменить во всех числах точки на запятые.";
			string expected = regularExpression.substitutePoinInNumberForComma(text);
			string actual = "3,5 Все вещественные числа в тексте записаны в формате с десятичной точкой, например: 12,56 или 0,358. Кроме того точками также разделены предложения внутри текста. Заменить во всех числах точки на запятые.";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void dellUnnecessarySpace()
		{
			string text = "  Удалить    в  строке      лишние      пробелы   .   ";
			string expected = regularExpression.dellUnnecessarySpace(text);
			string actual = "Удалить в строке лишние пробелы.";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void changeQuote()
		{
			string text = "В \"тексте заменить \"все\" английские\" закрывающие кавычки-\"лапки\" на русские \"елочки\".";
			string expected = regularExpression.changeQuote(text);
			string actual = "В «тексте заменить «все» английские» закрывающие кавычки-«лапки» на русские «елочки».";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void selectFile()
		{
			string text = "d:\\Программирование\\Epam\\DOT.net\\dotNET-2012\\Workshop\\Day4.Workshop.txt";
			string expected = regularExpression.selectFile(text);
			string actual = "Day4.Workshop.txt";
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void insertSpaces()
		{
			string text = "Проверить,и при необходимости,расставить 23,5 в тексте пробелы,после знаков, препинания.";
			string expected = regularExpression.insertSpaces(text);
			string actual = "Проверить, и при необходимости, расставить 23,5 в тексте пробелы, после знаков, препинания.";
			Assert.AreEqual(expected, actual);
		}
	}	
}

