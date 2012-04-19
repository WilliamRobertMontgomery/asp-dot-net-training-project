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
        protected int tempCapacity;
        protected bool color;
        protected PrintTechnology technology;

        public Printer()
        {
            printerCount++;
            this.name = string.Format("Printer #{0}", printerCount);
            this.capacityCartridge = this.tempCapacity = 1000;
        }

        public Printer(string printerName, int capacityCartridge, PrintTechnology technology, bool color)
            : this()
        {
            this.name = printerName;
            this.capacityCartridge = this.tempCapacity = capacityCartridge;
            this.technology = technology;
            this.color = color;
        }

        ArrayList printQueue = new ArrayList();

        public void AddDoc (Document newDoc)
        {
            if (newDoc is Document)
            {
                if (IsCapacityCartridgeOk(newDoc.GetPages))
                {
                    printQueue.Add(newDoc);
                    //capacityCartridge -= newDoc.GetPages;
                    tempCapacity -= newDoc.GetPages;
                    Console.WriteLine("Document {0} has been added.", newDoc.GetName);
                }
                else
                {
                    Console.WriteLine("Document {0} has not been added.\nThe pages more than cartridge's capacity", newDoc.GetName);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < printQueue.Count; i++)
            {
                Document printedDoc = (Document)printQueue[i];
                printedPages += printedDoc.GetPages;
                capacityCartridge -= printedDoc.GetPages;
                Console.WriteLine("The document {0} has been printed.", printedDoc.GetName);
            }
            printQueue.Clear();
        }

        public void ReplaceCartrige(int capacityCartridge = 1000)
        {
            this.tempCapacity = this.capacityCartridge = capacityCartridge;
            RefresPrintQueue();
            Console.WriteLine("The cartridge has been replaced.");
        }
        
        protected void RefresPrintQueue()
        {
            for (int i = 0; i < printQueue.Count; i++)
            {
                Document doc = (Document)printQueue[i];
                tempCapacity -= doc.GetPages;
            }
        }

        bool IsCapacityCartridgeOk (int pagesDoc)
        {
            if (tempCapacity >= pagesDoc)
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

        public virtual void GetPrinterInfo()
        {
            Console.WriteLine("Test-page:");
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
            if (printQueue.Count != 0)
            {
                Console.WriteLine("Print queue:");
                for (int i = 0; i < printQueue.Count; i++)
                {
                    Document doc = (Document)printQueue[i];
                    Console.WriteLine("{2}) {0}: {1} page(-s)", doc.GetName, doc.GetPages, i + 1);
                }
            }
            else
            {
                Console.WriteLine("The print queue is empty.");
            }
        }

        public void ClearPrintQueue()
        {
            printQueue.Clear();
            Console.WriteLine("The print queue has been cleared.");
        }
    }
}
