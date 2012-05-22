using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models;
using Lab4.Models.Repository;

namespace Lab4.Controllers
{
    public class AgentController : Controller
    {
        //
        // GET: /Agent/

        public ActionResult Index()
        {
            AgentRepository repository = new AgentRepository();

            var agents = repository.GetAll();

            var agentsToShow = new List<EditAgent>();

            foreach (var agent in agents)
            {
                agentsToShow.Add
                    (
                        new EditAgent
                        {
                            agentId = agent.id,
                            agentName = agent.name
                        }
                    );
            }

            return View(agentsToShow);
        }

        [HttpGet]
        public ActionResult AddAgent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAgent(AddAgent agent)
        {
            AgentRepository repository = new AgentRepository();

            Agents agentToAdd = new Agents
            {
                name = agent.agentName
            };

            repository.Save(agentToAdd);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int agentId)
        {
            AgentRepository repository = new AgentRepository();
            var agentToDelete = repository.GetById(agentId);
            repository.Delete(agentToDelete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int agentId)
        {
            AgentRepository repository = new AgentRepository();
            var agent = repository.GetById(agentId);
            var agentToEdit = new EditAgent { agentId = agent.id, agentName = agent.name };
            return View(agentToEdit);
        }

        [HttpPost]
        public ActionResult Edit(int agentId, EditAgent agent)
        {
            AgentRepository repository = new AgentRepository();

            Agents agentToUpdate = new Agents
            {
                id = agent.agentId,
                Contracts = repository.GetById(agentId).Contracts,
                name = agent.agentName
            };

            repository.Update(agentToUpdate);
            return RedirectToAction("Index");
        }

    }
}
