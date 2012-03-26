using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My.RegularExpression
{
	interface ITasksRegularExpressions
	{
		string searchExpression(string text, string word, bool ignoreCase);
		int[] countUse(string text, List<string> listWord, bool ignoreCase);
		int countWords(string text);
		int countSentence(string text);
		string dellAllHTMLTags(string text);
		string standartDateFormat(string text);
		string substituteHTMLForFTP(string text, bool ignoreCase);
		string substituteEmail(string text, bool ignoreCase);
		string substituteDollarForRouble(string text);
		string substitutePrefix(string text, string prefix, string replaced);
		string substitutePoinInNumberForComma(string text);
		string dellUnnecessarySpace(string text);
		string changeQuote(string text);
		string selectFile(string text);
		string insertSpaces(string text);
	}
}
