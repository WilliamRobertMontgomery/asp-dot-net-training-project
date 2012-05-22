using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebProjectNEW.Models.VesenniDataAccess;
using MvcWebProjectNEW.Models;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MvcWebProjectNEW.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        private readonly IRepository _repository;

        public ProfileController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult ShowProfile()
        {
            Guid userId = (Guid) Membership.GetUser(User.Identity.Name).ProviderUserKey;
            return View(_repository.GetById<AspnetUser>(userId).ConvertToIntermidiateClass());
        }

        [HttpGet]
        public ActionResult EditProfile(Guid id)
        {
            return View(_repository.GetById<AspnetUser>(id).ConvertToIntermidiateClass());
        }

        [HttpPost]
        public ActionResult EditProfile(AspnetUserIntermidiate profile)
        {
            _repository.UpdateEntity(profile.ConvertToFinalClass(_repository));
            return RedirectToAction("ShowProfile");
        }

        public ActionResult SendLetter(string letterContent,string letterTitle)
        {
            Guid userId = (Guid) Membership.GetUser(User.Identity.Name).ProviderUserKey;
            var letter = new VesenniLetter
            {
                Title = letterTitle,
                Content = letterContent,
                AspnetUser = _repository.GetById<AspnetUser>(userId),
                DateSend = DateTime.Now
            };
            _repository.AddEntity(letter);


            return View(letter);
        }

    }
}
