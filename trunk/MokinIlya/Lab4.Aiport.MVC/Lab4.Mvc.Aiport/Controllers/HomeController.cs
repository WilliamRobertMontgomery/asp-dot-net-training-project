using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Mvc.Aiport.BusinessLogic;
using Lab4.Mvc.Aiport.DataAccess;

namespace Lab4.Mvc.Aiport.Controllers
{
    public class HomeController : Controller
    {
        private CCashier Cashier;

        public HomeController()
        {
            //Инициализуруем и заполняем необходимые объекты
            DataAccessBank Bank = new DataAccessBank();
            DataAccessBasicReis BasicReis = new DataAccessBasicReis();
            DataAccessReis Reis = new DataAccessReis();
            DataAccessClients Clients = new DataAccessClients();
            DataAccessPlains Plains = new DataAccessPlains();

            Cashier = new CCashier(ref Bank, ref BasicReis, ref Reis, ref Clients, ref Plains);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Выберите действие";

            return View();
        }

        //Генерация новых рейсов
        [HttpGet]
        public ActionResult Generate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Generate(string t, string d)
        {
            DateTime time = DateTime.Parse(t);
            int days = Int32.Parse(d);

            ViewBag.Message = Cashier.GenerateReis(time, days);
            return View();
        }

        //Покупка
        [HttpGet]
        public ActionResult Sell()
        {
            Lab4.Mvc.Aiport.Models.DBAiportDataContext reises = new Models.DBAiportDataContext();
            return View(reises.BasicReis);
        }

        [HttpPost]
        public ActionResult Sell(string destination,string nowTime)
        {


            ViewBag.Message = Cashier.Sell(destination, DateTime.Parse(nowTime));

            Lab4.Mvc.Aiport.Models.DBAiportDataContext reises = new Models.DBAiportDataContext();
             
            return View(reises.BasicReis);
        }

        //Бронирование
        [HttpGet]
        public ActionResult Reserve()
        {
            Lab4.Mvc.Aiport.Models.DBAiportDataContext reises = new Models.DBAiportDataContext();
            return View(reises.BasicReis);
        }

        [HttpPost]
        public ActionResult Reserve(string destination, string nowTime)
        {


            ViewBag.Message = Cashier.Reserve(destination, DateTime.Parse(nowTime));

            Lab4.Mvc.Aiport.Models.DBAiportDataContext reises = new Models.DBAiportDataContext();

            return View(reises.BasicReis);
        }

        //Завершение бронирования
        [HttpGet]
        public ActionResult FinishReserve()
        {
            Lab4.Mvc.Aiport.Models.DBAiportDataContext clients = new Models.DBAiportDataContext();
            return View(clients.Clients);
        }

        
        [HttpPost]
        public ActionResult FinishReserve(string Code)
        {


            ViewBag.Message = Cashier.FinishReserve(Int32.Parse(Code));

            Lab4.Mvc.Aiport.Models.DBAiportDataContext clients = new Models.DBAiportDataContext();

            return View(clients.Clients);
        }


        public ActionResult ShowAllClients()
        {

            Lab4.Mvc.Aiport.Models.DBAiportDataContext clients = new Models.DBAiportDataContext();

            return View(clients.Clients);
        }
    }
}
