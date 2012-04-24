using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace MyRegex.Test
{
	[TestFixture]
	class RegTest
	{

		[Test]
		public void SelectTextTest()
		{
			string inputString = "1. Найти и подсветить в тексте все вхождения заданного слова (выражения).";
			string searchString = "в тексте";
			string actualString = @"1. Найти и подсветить <b>в тексте</b> все вхождения заданного слова (выражения).";
			string outputString = Reg.SelectText(inputString, searchString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void GetCountWordListTest()
		{
			string inputString = "2. В заданном тексте подсчитать частоту использования каждого буквосочетания, " +
				"слова и словосочетания из заданного списка";
			int[] actualCount = {5, 2, 2, 1, 0};
			string[] wordList = new string[] { "ан", "сочетания", "слов", "В заданном тексте", "нет" };
			int[] outputCount = Reg.GetCountWordList(inputString, wordList);
			Assert.AreEqual(actualCount, outputCount);
		}
		
		
		[Test]
		public void GetCountWordsTest()
		{
			string inputString = "3. Подсчитать в тексте число слов.";
			int actualCount = 6;
			int outputCount = Reg.GetCountWords(inputString);
			Assert.AreEqual(actualCount, outputCount);
		}


		[Test]
		public void GetCountSentencesTest()
		{
			string inputString = "4. Подсчитать количество предложений в тексте. " + 
								 "В итоге три предложения.";
			int actualCount = 3;
			int outputCount = Reg.GetCountSentences(inputString);
			Assert.AreEqual(actualCount, outputCount);
		}


		[Test]
		public void DeleteHtmlTagsTest()
		{
			string inputString = @"<html><head><title>5.</title></head><body>Удалить все html-теги из текста</body></html>";
			string actualString = "5.Удалить все html-теги из текста";
			string outputString = Reg.DeleteHtmlTags(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void ReplaceDateTest()
		{
			string inputString = "Все даты в тексте записаны в западноевропейском формате: 2012.11.21 " +
								"Привести их к принятому формату у нас: 21.11.2012 " +
								"1999.12.31; 2012.02.29-date" +
								"192.168.1.1; 2222.2.22; 2000.00.01";
			string actualString = "Все даты в тексте записаны в западноевропейском формате: 21.11.2012 " +
								"Привести их к принятому формату у нас: 21.11.2012 " +
								"31.12.1999; 29.02.2012-date" +
								"192.168.1.1; 2222.2.22; 2000.00.01";
			string outputString = Reg.ReplaceDate(inputString);
			Assert.AreEqual(actualString, outputString);
		}



		[Test]
		public void ReplacePrоtocоlTest()
		{
			string inputString = "7. Заменить в тексте все http-ссылки на аналогичные ftp-ссылки" +
								" http://192.168.1.1/" +
								" http://ru.wikipedia.org/wiki/Регулярные_выражения" +
								" https://www.google.ru/" +
								" ftp://ftp.byfly.by/";
			string actualString = "7. Заменить в тексте все http-ссылки на аналогичные ftp-ссылки" +
								" ftp://192.168.1.1/" +
								" ftp://ru.wikipedia.org/wiki/Регулярные_выражения" +
								" https://www.google.ru/" +
								" ftp://ftp.byfly.by/";
			string outputString = Reg.ReplacePrоtocоl(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void ReplaceEmailTest()
		{
			string inputString = "8. Заменить в тексте адреса электронной почты xxx@tut.by на xxx@gmail.com" +
								"admin@tut.by " +
								"@tut.by " +
								"user@@tut.by ";
			string actualString = "8. Заменить в тексте адреса электронной почты xxx@gmail.com на xxx@gmail.com" +
								"admin@gmail.com " +
								"@tut.by " +
								"user@@tut.by ";
			string outputString = Reg.ReplaceEmail(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void ReplaceMoneyTest()
		{
			string inputString = "9. В тексте указаны стоимости товаров в долларах, например xxx $. " +
								"Заменить на аналогичные суммы только в рублях: xxx р. " +
								"1 $ == 8000 р " +
								"100 $ " +
								"00 $ + 11$$ + $ + 15 S";
			string actualString = "9. В тексте указаны стоимости товаров в долларах, например xxx $. " +
								"Заменить на аналогичные суммы только в рублях: xxx р. " +
								"1 р == 8000 р " +
								"100 р " +
								"00 р + 11$$ + $ + 15 S";
			string outputString = Reg.ReplaceMoney(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void ReplacePhoneTest()
		{
			string inputString = "10. В тексте указаны телефонные номера с кодом г. Гродно: (0152)-xx-xx-xx. " +
								"Заменить во всех номерах код г. Гродно на код г. Бреста (0162) " +
								"(0152)-41-44-44 " +
								"(0152)-00-01-01 " +
								"(0152)-4-44-44 ";
			string actualString = "10. В тексте указаны телефонные номера с кодом г. Гродно: (0152)-xx-xx-xx. " +
								"Заменить во всех номерах код г. Гродно на код г. Бреста (0162) " +
								"(0162)-41-44-44 " +
								"(0152)-00-01-01 " +
								"(0152)-4-44-44 ";
			string outputString = Reg.ReplacePhone(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void ReplaceDecimalDividerTest()
		{
			string inputString = "11.0 Все вещественные числа в тексте записаны в формате с десятичной точкой. " +
								"Кроме того точками также разделены предложения внутри текста. " +
								"Заменить во всех числах точки на запятые. " +
								"3.1415926 " +
								"10.10 0.0 " +
								"a2.3 4. 1234.12h34";
			string actualString = "11,0 Все вещественные числа в тексте записаны в формате с десятичной точкой. " +
								"Кроме того точками также разделены предложения внутри текста. " +
								"Заменить во всех числах точки на запятые. " +
								"3,1415926 " +
								"10,10 0,0 " +
								"a2.3 4. 1234.12h34";
			string outputString = Reg.ReplaceDecimalDivider(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void DeleteSpacesTest()
		{
			string inputString  = "12.   Удалить в строке      лишние пробелы.";
			string actualString = "12. Удалить в строке лишние пробелы.";
			string outputString = Reg.DeleteSpaces(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void DeleteQuotesTest()
		{
			string inputString = "13. В тексте заменить все английские закрывающие кавычки-«лапки» на русские «елочки». " +
								" \"Текст в кавычках\"" ;
			string actualString = "13. В тексте заменить все английские закрывающие кавычки-«лапки» на русские «елочки». " +
								" «Текст в кавычках»";
			string outputString = Reg.DeleteQuotes(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void SelectNameAndExtensionTest()
		{
			// 14. Из заданного локального пути выделить имя файла и его расширение.
			string inputString = @"C:\Program Files\Total Commander\Totalcmd.exe";
			string actualString = "Totalcmd.exe";

			string outputString = Reg.SelectNameAndExtension(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		[Test]
		public void VerifySpacesTest()
		{
			string inputString = "15.Проверить и при необходимости расставить в тексте пробелы:после знаков препинания.";
			string actualString = "15. Проверить и при необходимости расставить в тексте пробелы: после знаков препинания.";
			string outputString = Reg.VerifySpaces(inputString);
			Assert.AreEqual(actualString, outputString);
		}


		static void Main(string[] args)
		{
		}
	}
}
