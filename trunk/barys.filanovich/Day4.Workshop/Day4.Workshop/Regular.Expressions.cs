using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Day4.Workshop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void findBtn_Click(object sender, EventArgs e)
        {
            inputStringTBox.SelectAll();
            inputStringTBox.SelectionBackColor = Color.White;
            MatchCollection myMatches = Regex.Matches(inputStringTBox.Text, patternTBox.Text,
                RegexOptions.IgnoreCase);

            countLbl.Text = myMatches.Count.ToString();

            foreach (Match nextMatch in myMatches)
            {
                inputStringTBox.SelectionStart = nextMatch.Index;
                inputStringTBox.SelectionLength = nextMatch.Length;
                inputStringTBox.SelectionBackColor = Color.GreenYellow;
            }
        }

        private void GetInfoBtn_Click(object sender, EventArgs e)
        {
            infoTBox.Text = String.Format("Number of words: {0}\r\n" +
                                            "Number of sentences: {1}",
                                            GetNumWords(inputStringTBox.Text).ToString(), 
                                            GetNumSentences(inputStringTBox.Text).ToString());
        }

        int GetNumWords(string inputString)
        {
            string pattern = @"\b\S+\b";
            MatchCollection myMatches = Regex.Matches(inputString, pattern,
                RegexOptions.IgnoreCase);
            return myMatches.Count;
        }

        int GetNumSentences(string inputString)
        {
            string pattern = @"[\.?!]+\s*";
            MatchCollection myMatches = Regex.Matches(inputString, pattern,
                RegexOptions.IgnoreCase);
            return myMatches.Count;
        }

        private void RemoveTagBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"<.*?>";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, string.Empty);
        }

        private void dateReplaceBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"(\d{4}).(\d{1,2}).(\d{1,2})";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, String.Format(@"$3.$2.$1"));

        }

        private void replaceURLBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"\b(http)(://\S+)\b";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, String.Format(@"ftp$2"));
        }

        private void replaceMailBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"\b(\S+)(@tut.by)\b";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, String.Format(@"$1@gmail.com"));
        }

        private void replaceBucksBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"(\d+)\s?\$";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, String.Format(@"$1 р."));
        }

        private void replaceCodeBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"\((0152)\)([0-9-]{8,})";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, String.Format(@"(0162)$2"));
        }

        private void replaceNumberBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"(\d+)\.(\d+)";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, @"$1,$2");
        }

        private void removeSpaceBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"\s+";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, @" ");
        }

        private void replaceQuotesBtn_Click(object sender, EventArgs e)
        {
            string pattern = @"\„([\w\W]+)\“";
            inputStringTBox.Text = Regex.Replace(inputStringTBox.Text, pattern, @"«$1»");
        }


    }
}
