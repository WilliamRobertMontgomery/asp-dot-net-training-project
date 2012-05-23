using System.Data.Linq;
using LabTwo.Cinema.BusinessLogic;
using LabTwo.Cinema.DataAccess.Database;

using LabTwo.Cinema.DataAccess.Repository;

using LabTwo.Cinema.Entities;

namespace LabTwo.Cinema.Presentation
{
    public class Program
    {
        private static CinemaConsole _cinemaConsole;
        private static CinemaLogic _cinemaLogic;
        private static Repository _repository;

        private static void Init()
        {
            //_repository = new Repository(new XmlDataBase(@"Data\XmlDB\"));
            _cinemaLogic = new CinemaLogic(new CinemaDataContext());
            _cinemaConsole = new CinemaConsole(_cinemaLogic);
        }

        public static void Main(string[] args)
        {
            Init();
            _cinemaConsole.Menu();
        }
    }
}