using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPrinters
{
    public interface IPrinter
    {
        void AddDoc(Document newDoc);
        void Print();
        void ReplaceCartrige(int capacityCartridge = 1000);
        void Capacity();
        void GetPrintTechnology();
        void GetPrinterInfo();
        void GetPrintQueue();
        bool IsColor { get; }
    }
}
