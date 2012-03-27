using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WorkShop.Day4.RegExp;

namespace WorkShop.Day4.RegExp.Tests
{
    [TestFixture]
    public class RegExpTest
    {
        private static void Main(string[] args)
        {
        }

        #region SelectWordTest

        public void SelectWordTest(string inputString, string word, string expected, string assertMessage)
        {
            var actual = RegExp.SelectWord(inputString, word);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void SelectWordShouldReturnTextWithBoldWord()
        {
            SelectWordTest(
                "1. Найти и подсветить в тексте все вхождения заданного слова (выражения)."
                , "подсветить"
                , "1. Найти и <b>подсветить</b> в тексте все вхождения заданного слова (выражения)."
                , "SelectWord method should return bold word");
            SelectWordTest(
                "support special characters \\-1#+"
                , "\\-1#+"
                , "support special characters <b>\\-1#+</b>"
                , "SelectWord should support spec chars");
        }

        #endregion SelectWordTest

        #region CountingFrequencyOfUseTest

        public void CountingFrequencyOfUseTest(string inputString, string[] stringArray, IEnumerable<int> expected, string assertMessage)
        {
            IEnumerable<int> actual = RegExp.CountingFrequencyOfUse(inputString, stringArray);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void CountingFrequencyOfUseShouldReturnCountNumber()
        {
            CountingFrequencyOfUseTest(
                "2. В заданном тексте подсчитать частоту использования каждого буквосочетания, " +
                "слова и словосочетания из заданного списка"
                , new[] { "В", "ого", "списка", "подсчитать частоту" }
                , new[] { 5, 2, 1, 1 }
                , "CountingFrequencyOfUse should return the number of entries");
        }

        #endregion CountingFrequencyOfUseTest

        #region CountingNumberOfWordsTest

        public void CountingNumberOfWordsTest(string inputString, int expected, string assertMessage)
        {
            var actual = RegExp.CountingNumberOfWords(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void CountingNumberOfWordsShouldReturnNumber()
        {
            CountingNumberOfWordsTest(
                "3. Подсчитать в тексте число слов."
                , 5
                , "CountingNumberOfWords should return the number of words");
            CountingNumberOfWordsTest(
                "Сounting the \\+_! number of #19- words."
                , 5
                , "CountingNumberOfWords should not counting all special chars");
            CountingNumberOfWordsTest(
                "кто-то где-то"
                , 2
                , "CountingNumberOfWords should count the words with hyphens");
        }

        #endregion CountingNumberOfWordsTest

        #region CountingNumberOfSentencesTest

        public void CountingNumberOfSentencesTest(string inputString, int expected, string assertMessage)
        {
            var actual = RegExp.CountingNumberOfSentences(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void CountingNumberOfSentencesShouldReturnNumber()
        {
            CountingNumberOfSentencesTest(
                "3. Подсчитать в тексте количество предложений."
                , 1
                , "CountingNumberOfSentences should return the number of sentences");
            CountingNumberOfSentencesTest(
                "3. Подсчитать количество предложений в тексте! " +
                "4. Counting the number of sentences in the text."
                , 2
                , "CountingNumberOfSentences should support enumeration of text strings");
            CountingNumberOfSentencesTest(
                "Подсчитать количество предложений в тексте: " +
                "- counting the number of sentences in the text?" +
                "Подсчитать количество предложений в тексте!"
                , 3
                , "CountingNumberOfSentences should support - : ; chars");
        }

        #endregion CountingNumberOfSentencesTest

        #region RemoveHtmlTagsTest

        public void RemoveHtmlTagsTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.RemoveHtmlTags(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void RemoveHtmlTagsShouldReturnTextWithoutHtmlTags()
        {
            RemoveHtmlTagsTest(
                "<span style=width=50%>5. <em>Удалить</em> все html-теги из текста.</span> " +
                "<div id=post class=tborder>Я смог выбраться из тегов!</div>"
                , "5. Удалить все html-теги из текста. Я смог выбраться из тегов!"
                , "RemoveHtmlTags should return text without html-tags");
            RemoveHtmlTagsTest(
                "<meta content=text/html; />"
                , string.Empty
                , "RemoveHtmlTags should return text without html-tags");
        }

        #endregion RemoveHtmlTagsTest

        #region ChangeDateTest

        public void ChangeDateTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangeDate(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangeDateShouldReturnDateInEasternEuropeanFormat()
        {
            ChangeDateTest(
                "2012.03.26"
                , "26.03.2012"
                , "ChangeDateTest should return date in Eastern European format");
        }

        #endregion ChangeDateTest

        #region ChangeProtocolTest

        public void ChangeProtocolTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangeProtocol(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangeProtocolTestShouldReturnFtpLinkFromHttp()
        {
            ChangeProtocolTest(
                "Замена в ссылке http://google.by/"
                , "Замена в ссылке ftp://google.by/"
                , "ChangeProtocolTest should change http to ftp");
            ChangeProtocolTest(
                "Замена в ссылке http://www.google.by/"
                , "Замена в ссылке ftp://google.by/"
                , "ChangeProtocolTest should change http://www to ftp://");
            ChangeProtocolTest(
                "Замена в ссылке https://www.google.by/"
                , "Замена в ссылке ftp://google.by/"
                , "ChangeProtocolTest should change https://www to ftp://");
        }

        #endregion ChangeProtocolTest

        #region ChangeEmailTest

        public void ChangeEmailTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangeEmail(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangeEmailShouldReturnGmailEmailTautology()
        {
            ChangeEmailTest(
                "Заменить в тексте адреса электронной почты xxx@tut.by"
                , "Заменить в тексте адреса электронной почты xxx@gmail.com"
                , "ChangeEmailTest should change tut.by to gmail.com");
            ChangeEmailTest(
                "xxx@tut.by."
                , "xxx@gmail.com."
                , "ChangeEmailTest should not change point at the end of the email");
        }

        #endregion ChangeEmailTest

        #region ConversionCurrencyTest

        public void ConversionCurrencyTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ConversionCurrency(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ConversionCurrencyTestShouldReturnCurrencyInRubles()
        {
            ConversionCurrencyTest(
                "Купите нашу чудо-штуку всего за 100 $ и вы сэкономите 2$!"
                , "Купите нашу чудо-штуку всего за 1000000p и вы сэкономите 20000p!"
                , "ChangeCurrencyTest should change currency from $ to p");
        }

        #endregion ConversionCurrencyTest

        #region ChangeCityCodeTest

        public void ChangeCityCodeTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangeCityCode(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangeCityCodeTestShouldReturnBrestCityCode()
        {
            ChangeCityCodeTest(
                "Изменить номер с кодом г. Гродно: (0152)-71-26-53."
                , "Изменить номер с кодом г. Гродно: (0162)-71-26-53."
                , "ChangeCityCodeTest should change city code");
        }

        #endregion ChangeCityCodeTest

        #region ChangePointToCommaTest

        public void ChangePointToCommaTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangePointToComma(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangePointToCommaTestShouldReturnNumberWithComma()
        {
            ChangePointToCommaTest(
                "All (2.1) real numbers 12.52 17."
                , "All (2,1) real numbers 12,52 17."
                , "ChangePointToCommaTest should change point to a comma");
        }

        #endregion ChangePointToCommaTest

        #region DeleteExtraSpacesTest

        public void DeleteExtraSpacesTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.DeleteExtraSpaces(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void DeleteExtraSpacesTestShouldReturnNormalText()
        {
            DeleteExtraSpacesTest(
                "12. Удалить в строке                      лишние пробелы"
                , "12. Удалить в строке лишние пробелы"
                , "DeleteExtraSpacesTest should remove redundant white spaces");
            DeleteExtraSpacesTest(
                "12. Удалить в строке                      лишние пробелы" +
                "12. Удалить в строке                      лишние пробелы"
                , "12. Удалить в строке лишние пробелы" +
                  "12. Удалить в строке лишние пробелы"
                , "DeleteExtraSpacesTest should not remove line feed");
        }

        #endregion DeleteExtraSpacesTest

        #region ChangeQuotesTest

        public void ChangeQuotesTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.ChangeQuotes(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void ChangeQuotesTestShouldReturnTextWithRussianQuotes()
        {
            ChangeQuotesTest(
                "13. В тексте заменить все \"%@%' английские закрывающие \"кавычки\"-'лапки' на русские <<елочки>>."
                , "13. В тексте заменить все \"%@%' английские закрывающие <<кавычки>>-<<лапки>> на русские <<елочки>>."
                , "ChangeQuotesTest should return text with russian quotes");
        }

        #endregion ChangeQuotesTest

        #region SelectFileNameWithExtensionTest

        public void SelectFileNameWithExtensionTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.SelectFileNameWithExtension(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void SelectFileNameWithExtensionTestShouldReturnFileNameWithExtension()
        {
            SelectFileNameWithExtensionTest(
                @"F:\Study\_asp.net 2012\Presentations\DAY #04\demo.cs"
                , "demo.cs"
                , "SelectFileNameWithExtensionTest should return file name and extension");
        }

        #endregion SelectFileNameWithExtensionTest

        #region CheckAndAlignmentSpacesTest

        public void CheckAndAlignmentSpacesTest(string inputString, string expected, string assertMessage)
        {
            var actual = RegExp.CheckAndAlignmentSpaces(inputString);
            Assert.AreEqual(expected, actual, assertMessage);
        }

        [Test]
        public void CheckAndAlignmentSpacesTestShouldReturnRefactoredText()
        {
            CheckAndAlignmentSpacesTest(
                "15.Проверить и при,необходимости расставить...в!тексте.пробелы?после знаков препинания. "
                , "15. Проверить и при, необходимости расставить... в! тексте. пробелы? после знаков препинания. "
                , "CheckAndAlignmentSpacesTest should return text with refactored spaces");
        }

        #endregion CheckAndAlignmentSpacesTest
    }
}