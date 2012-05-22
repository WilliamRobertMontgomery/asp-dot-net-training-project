using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using MvcWebProjectNEW.Models.VesenniDataAccess;
using MvcWebProjectNEW.Models;
using System.Web.Security;

namespace MvcWebProjectNEW.Controllers
{
    [Authorize(Roles = "admin, moderator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        //Для получения Репозитория
        private readonly IRepository _repository;

        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
       
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// Отображает список материалов
        /// </summary>
        public ActionResult ShowMaterials()
        {
            return View(_repository.GetAll<VesenniMaterial>());
        }
       
        /// <summary>
        /// Создание нового материала
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult CreateMaterials()
        {
            ViewData["my"] = _repository.GetAll<VesenniTopic>();
            ViewBag.Topics = _repository.GetAll<VesenniTopic>();
            return View();
        }
        
        /// <summary>
        /// Сохранение нового материала
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateMaterials(VesenniMaterialIntermidiate model)
        {
            model.UserId = (Guid) Membership.GetUser(User.Identity.Name).ProviderUserKey;
            _repository.AddEntity(model.ConvertToFinalClass(_repository));
            ViewBag.Success += "Материал добавлен";
            ViewBag.Topics = _repository.GetAll<VesenniTopic>();
            return View();
        }

        /// <summary>
        /// Редактирование материала
        /// </summary>
        /// <param name="Id"></param>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult EditMaterial( Guid Id )
        {
            ViewBag.Topics = _repository.GetAll<VesenniTopic>();
            return View(_repository.GetById<VesenniMaterial>(Id).ConvertToIntermidiateClass());
        }

        /// <summary>
        /// Обновление материала
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditMaterial(VesenniMaterialIntermidiate model)
        {
            _repository.UpdateEntity(model.ConvertToFinalClass(_repository));
            return RedirectToAction("ShowMaterials");
        }

        /// <summary>
        /// Удаление материала
        /// </summary>
        /// <param name="Id"></param>
        public ActionResult DeleteMaterial(Guid Id)
        {
            _repository.DeleteById<VesenniMaterial>(Id);
            ViewBag.Topics = _repository.GetAll<VesenniTopic>();
            return RedirectToAction("ShowMaterials");
        }

        /// <summary>
        /// Отображает список топиков (для материалов)
        /// </summary>
        public ActionResult ShowTopics()
        {
            return View(_repository.GetAll<VesenniTopic>());
        }

        /// <summary>
        /// Редактирование топка
        /// </summary>
        /// <param name="Id"></param>
        [HttpGet]
        public ActionResult EditTopic(Guid Id)
        {
            return View(_repository.GetById<VesenniTopic>(Id).ConvertToIntermidiateClass());
        }

        //Обновление топика
        [HttpPost]
        public ActionResult EditTopic(VesenniTopicIntermidiate model)
        {
            _repository.UpdateEntity(model.ConvertToFinalClass(_repository));
            ViewBag.Success += "Тема обновлена";
            return View(_repository.GetById<VesenniTopic>(model.TopicId).ConvertToIntermidiateClass());
        }
        
        /// <summary>
        /// Создание нового топика
        /// </summary>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult CreateTopic()
        {
            return View();
        }

        /// <summary>
        /// Сохранение нового топика
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateTopic(VesenniTopic model)
        {
            _repository.AddEntity(model);
            ViewBag.Success += "Тема добавлена";
            return View();
        }

        /// <summary>
        /// Удаление топика
        /// </summary>
        /// <param name="Id"></param>
        public ActionResult DeleteTopic(Guid Id)
        {
            _repository.DeleteById<VesenniTopic>(Id);
            return RedirectToAction("ShowTopics");
        }
        /// <summary>
        ////Отобоажает список юзеров
        /// </summary>
        public ActionResult ShowUsers()
        {
            return View(_repository.GetAll<AspnetUser>());
        }

        /// <summary>
        /// Удаляет пользователя по имени
        /// </summary>
        public ActionResult DeleteUser(string name)
        {
            Membership.DeleteUser(name);
            return RedirectToAction("ShowUsers");
        }

        public ActionResult ShowProfile(Guid userId)
        {
            return View(_repository.GetById<AspnetUser>(userId).ConvertToIntermidiateClass());
        }

        /// <summary>
        /// Редактирование профиля юзера 
        /// </summary>
        /// <param name="Id"></param>
        [HttpGet]
        public ActionResult EditUser(Guid Id)
        {
            return View(_repository.GetById<AspnetUser>(Id).ConvertToIntermidiateClass());
        }

        /// <summary>
        /// Сохранение нового профиля 
        /// </summary>
        /// <param name="Id"></param>
        [HttpPost]
        public ActionResult EditUser(AspnetUserIntermidiate user)
        {
            _repository.UpdateEntity(user.ConvertToFinalClass(_repository));
            return View(user);
        }

        /// <summary>
        /// Форма Сброс пароля
        /// </summary>
        /// <param name="userName"></param>
        [HttpGet]
        public ActionResult ChangePassword(string userName)
        {
            ViewBag.UserName = userName;
            return View();
        }

        /// <summary>
        /// Сброс пароля
        /// </summary>
        [HttpPost]
        public ActionResult ChangePassword()
        {
            string userName = Request.Form["userName"];
            MembershipUser currentUser = Membership.GetUser(userName);
            ViewBag.UserName = userName;
            ViewBag.NewPass = "Новый пароль: "+ currentUser.ResetPassword();
            return View();
        }

        /// <summary>
        /// Удаление роли пользователя
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        public ActionResult DeleteRole(string userName, string role)
        {
            Roles.RemoveUserFromRole(userName, role);
            return RedirectToAction("EditUser");
        }

        /// <summary>
        /// Добавление роли к пользователю
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="role"></param>
        public ActionResult AddRole(string userName, string role)
        {
            Roles.AddUserToRole(userName, role);
            return RedirectToAction("EditUser");
        }

        /// <summary>
        /// Отображает список писем для администрации
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowLetters()
        {
            return View(_repository.GetAll<VesenniLetter>().OrderBy(x=>x.DateSend));
        }

        /// <summary>
        /// Просмотр конкретного письма
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult SeeLetter(Guid Id)
        {
            return View(_repository.GetById<VesenniLetter>(Id));
        }

        /// <summary>
        /// Удаление письма по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DeleteLetter(Guid Id)
        {
            _repository.DeleteById<VesenniLetter>(Id);
            return RedirectToAction("ShowLetters");
        }
    }
}
