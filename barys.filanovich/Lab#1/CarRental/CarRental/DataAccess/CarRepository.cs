using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CarRental.BusinessLogic;

namespace CarRental.DataAccess
{
    public class CarRepository
    {
        const string extension = ".car";

        public static void Save(Car car)
        {
            StreamWriter fileWriter = new StreamWriter(car.BrandName + extension, false);
            fileWriter.Write("{0}\r\n{1}\r\n{2}", 
                car.BrandName, car.Status, car.DateOfLease);
            fileWriter.Close();
        }

        public static Car[] GetCars()
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

                cars[i] = new Car(carString[0], carString[1], carString[2]);
            }

            return cars;
        } 
    }
}
