using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace MyPrinters
{
    public enum PrintTechnology
    {
        LiquidInkjet,
        TonerBased,
        SolidInk
    };

    public class Document
    {
        static int docCount;
        string name;
        int pages;
        
        public Document()
        {
            docCount++;
            this.name = string.Format("Document #{0}", docCount);
            this.pages = 1;
        }

        public Document(string name, int pages)
            : this()
        {
            this.name = name;
            this.pages = pages;
        }

        public int GetPages
        {
            get
            {
                return pages;
            }
        }

        public string GetName
        {
            get
            {
                return name;
            }
        }
    }

    class Printer : IPrinter
    {
        protected static int printerCount;
        protected string name;
        protected int printedPages;
        protected int capacityCartridge;
        protected bool color;
        protected PrintTechnology technology;

        public Printer()
        {
            printerCount++;
            this.name = string.Format("Printer #{0}", printerCount);
            this.capacityCartridge = 1000;
        }

        public Printer(string printerName, PrintTechnology technology, bool color)
            : this()
        {
            this.name = printerName;
            this.technology = technology;
            this.color = color;
        }

        //static ArrayList printersList = new ArrayList();
        ArrayList printQueue = new ArrayList();

        public void AddDoc (Document newDoc)
        {
            if (newDoc is Document)
            {
                if (IsCapacityCartridgeOk(newDoc.GetPages))
                {
                    printQueue.Add(newDoc);
                    capacityCartridge -= newDoc.GetPages;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < printQueue.Count; i++)
            {
                Document printedDoc = (Document)printQueue[i];
                printedPages += printedDoc.GetPages;
                Console.WriteLine("The document: {0} is printed.", printedDoc.GetName);
            }
            printQueue.Clear();
        }

        public void ReplaceCartrige(int capacityCartridge = 1000)
        {
            this.capacityCartridge = capacityCartridge;
        }

        bool IsCapacityCartridgeOk (int pagesDoc)
        {
            int balance = capacityCartridge - pagesDoc;
            if (balance >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Capacity()
        {
            Console.WriteLine("{0} page(-s) is left.", capacityCartridge);
        }

        public void GetPrintTechnology()
        {
            Console.WriteLine(this.technology);
        }

        virtual public void GetPrinterInfo()
        {
            string result = string.Format(
                "Printer's name: {0}\nPages was printed: {1}\n" +
                "Capacity: {2} page(-s) is left\nColor: {3}\n" +
                "Print technology: {4}", name, printedPages, capacityCartridge, color, technology);
            Console.WriteLine(result);
        }

        public bool IsColor
        {
            get 
            {
                return color;
            }
        }

        public void GetPrintQueue()
        {
            for (int i = 0; i < printQueue.Count; i++)
            {
                Document doc = (Document)printQueue[i];
                Console.WriteLine("{0}: {1} page(-s)", doc.GetName, doc.GetPages);
            }
        }
    }
}
