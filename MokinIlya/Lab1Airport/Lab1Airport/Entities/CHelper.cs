using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lab1Airport
{
    static class CHelper
    {
        private static CAircrafts Aircrafts;
        private static CReis Reis;

        private static void FillReis()
        {
            StreamReader fileReis = File.OpenText("Reis.txt");
            string str;
            while ((str =  fileReis.ReadLine())!=null)
            {
                string[] elementsOfStr = str.Split(' ');
                Reis.Add(Int32.Parse(elementsOfStr[0]), double.Parse(elementsOfStr[1]), DateTime.Parse(elementsOfStr[2]), Int32.Parse(elementsOfStr[3]), elementsOfStr[4], Int32.Parse(elementsOfStr[5]));
            }
            fileReis.Close();
        }

        private static void FillAircrafts()
        {
            StreamReader fileAircrafts = File.OpenText("Aircrafts.txt");
            string str;
            while ((str = fileAircrafts.ReadLine()) != null)
            {
                string[] elementsOfStr = str.Split(' ');
                Aircrafts.Add(Int32.Parse(elementsOfStr[0]),Int32.Parse(elementsOfStr[1]));
            }
            fileAircrafts.Close();
        }

        static CHelper()
        {
            Aircrafts = new CAircrafts();
            Reis = new CReis();
        }

        public static bool ReadOfDataBase(ref CAircrafts aircrafts, ref CReis reis)
        {
            FillAircrafts();
            FillReis();

            aircrafts = Aircrafts;
            reis = Reis;
            return true;
        }
    }
}
