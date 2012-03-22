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
        void GetPrinterInfo();
        void GetPrintQueue();
        void ClearPrintQueue();
        bool IsColor { get; }
    }
}
