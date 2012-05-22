using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models;
using Lab4.Models.Repository;

namespace Lab4.Controllers
{
    public class BuilderController : Controller
    {
        //
        // GET: /Builder/

        public ActionResult Index()
        {
            BuilderRepository repository = new BuilderRepository();

            var builders = repository.GetAll();

            var buildersToShow = new List<EditBuilder>();

            foreach (var builder in builders)
            {
                buildersToShow.Add
                    (
                        new EditBuilder
                        {
                            builderId = builder.id,
                            builderName = builder.name
                        }
                    );
            }

            return View(buildersToShow);
        }

        [HttpGet]
        public ActionResult AddBuilder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBuilder(AddBuilder builder)
        {
            BuilderRepository repository = new BuilderRepository();

            Builders builderToAdd = new Builders
            {
                name = builder.builderName
            };

            repository.Save(builderToAdd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int builderId)
        {
            BuilderRepository repository = new BuilderRepository();
            var builderToDelete = repository.GetById(builderId);
            repository.Delete(builderToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int builderId)
        {
            BuilderRepository repository = new BuilderRepository();
            var builder = repository.GetById(builderId);
            var builderToEdit = new EditBuilder { builderId = builder.id, builderName = builder.name };
            return View(builderToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int builderId, EditBuilder builder)
        {
            BuilderRepository repository = new BuilderRepository();

            Builders builderToUpdate = new Builders
            {
                id = builder.builderId,
                Contracts = repository.GetById(builderId).Contracts,
                name = builder.builderName
            };

            repository.Update(builderToUpdate);
            return RedirectToAction("Index");
        }

    }
}
