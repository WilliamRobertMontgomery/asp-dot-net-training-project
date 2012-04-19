using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    class CBank
    {
        public class CBankItem
        {
            public CBankItem(double money, DateTime time, string comment)
            {
                Money = money;
                Time = time;
                Comment = comment;
            }
            public double Money { get; set; }
            public DateTime Time { get; set; }
            public string Comment { get; set; }
        }

        public List<CBankItem> BankItem;

        public CBank()
        {
            BankItem = new List<CBankItem>();
        }

        public bool Add(double Money, DateTime Time, string Comment)
        {
            BankItem.Add(new CBankItem(Money, Time, Comment));
            return true;
        }
    }
}
