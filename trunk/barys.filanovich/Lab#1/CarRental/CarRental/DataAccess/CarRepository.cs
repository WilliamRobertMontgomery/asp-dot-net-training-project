using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CarRental.BusinessLogic;

namespace CarRental.DataAccess
{
    public class CarRepository : IRepository<Car>
    {
        const string extension = ".car";

        public void Save(Car item)
        {
            StreamWriter fileWriter = new StreamWriter(item.Id + extension, false);
            fileWriter.Write("{0}\r\n{1}\r\n{2}\r\n{3}",
                item.Id, item.BrandName, item.Client, item.DateOfLease);
            fileWriter.Close();
        }

        public Car[] Read()
        {
            Car[] cars;

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*"+extension);

            cars = new Car[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                StreamReader carFile = new StreamReader(files[i]);
                string carInfo = carFile.ReadToEnd();
                string[] carString = carInfo.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
                carFile.Close();

                cars[i] = new Car(carString[0], carString[1], carString[2], carString[3]);
            }

            return cars;
        }

        public void Remove(Car item)
        {
            File.Delete(item.Id + ".car");
        }
    }
}
