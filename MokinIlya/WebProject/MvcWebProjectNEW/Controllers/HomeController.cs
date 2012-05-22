using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using MvcWebProjectNEW.Models.VesenniDataAccess;
using MvcWebProjectNEW.Models;
using System.Text;
using System.Web.Security;

namespace MvcWebProjectNEW.Controllers
{
    public class HomeController : Controller
    {
        //Для получения Репозитория
        internal readonly IRepository _repository;
        internal VesenniMaterial _index;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string Id)
        {
            //Проверка _index на null + присвоение начальных значений
            ValidateIndex();

            GetContent(Id, ViewBag);

            return View();
        }

        
        //Вспомогательные методы
        internal void GetContent(string Id, dynamic ViewBag)
        {
            if (Id == null || Id.ToUpper() == "index".ToUpper())
            {
                ViewBag.Content = new HtmlString(_index.Content);
                ViewBag.Title = _index.TitleTag;
                _index.Visits = _index.Visits == null ? 1 : _index.Visits + 1;
                _repository.UpdateEntity(_index);
                return;
            }

            try
            {
                var temp = _repository.GetAll<VesenniMaterial>().Single(page => page.Path.ToUpper() == Id.ToUpper());
                ViewBag.Content = new HtmlString(temp.Content);
                ViewBag.Title = temp.TitleTag;
                temp.Visits = temp.Visits == null ? 1 : temp.Visits+1;
                _repository.UpdateEntity(temp);
            }

            catch
            {
                ViewBag.Content = new HtmlString("<h1>Error 404</h1>");
                ViewBag.Title = "Error";
            }
        }

        internal void ValidateIndex()
        {
            try
            {
                if (_index == null)
                {
                    _index = _repository.GetAll<VesenniMaterial>().Single(page => page.Path.ToUpper() == "INDEX");
                }
            }
            catch
            {
                _index = new VesenniMaterial();
                _index.Content = "<h1>Error 404</h1>";
                _index.TitleTag = "Error";
            }
        }
    }
}
