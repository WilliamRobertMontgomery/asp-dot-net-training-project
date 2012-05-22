using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4.Models.Repository;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Это главная страница. Здесь вы можете выбрать одно из перечисленных ниже действий";

            return View();
        }

        [HttpGet]
        public ActionResult MakeContract()
        {
            @ViewBag.Agents = new AgentRepository().GetAll();
            @ViewBag.Builders = new BuilderRepository().GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult MakeContract(MakeContractModel contract)
        {
            Clients client;
            
            //если клиент с таким именем уже существует, то берем его
            //если нет то создаем новый
            try
            {
                client = new ClientRepository()
                   .GetAll()
                   .Where(x => x.name.TrimEnd() == contract.clientName).First();
            }
            catch
            {
                //создаем клиента
                client = new Clients
                {
                    name = contract.clientName
                };                
            }

            Projects project = new Projects
            {
                description = contract.projectDescription,
                name = contract.projectName,
                deadline = DateTime.Now.AddDays(20.0)
            };            

            Agents agent = new AgentRepository().GetAll().Where(x => x.name.TrimEnd() == contract.agentName).First();

            Builders builder = new BuilderRepository().GetAll().Where(x => x.name.TrimEnd() == contract.builderName).First();


            Contracts contractToAdd = new Contracts()              
            {
                agentId = agent.id,
                builderId = builder.id,                
                clientId = client.id,
                Clients = client,
                projectId = project.id,
                Projects = project
            };

            new ContractRepository().Save(contractToAdd);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ShowContracts()
        {
            ContractRepository repository = new ContractRepository();
            var contractsToShow = new List<ShowContractModel>();
            var contracts = repository.GetAll();
            foreach (var contract in contracts)
            {
                contractsToShow.Add
                    (
                        new ShowContractModel
                        {
                            agentName = contract.Agents.name,
                            builderName = contract.Builders.name,
                            clientName = contract.Clients.name,
                            ContractId = contract.id,
                            projectDescription = contract.Projects.description,
                            projectName = contract.Projects.name,
                            projectDeadLine = contract.Projects.deadline
                        }
                    );
            }

            return View(contractsToShow);
        }

        public ActionResult Delete(int contractId)
        {
            var repository = new ContractRepository();
            Contracts contract = repository.GetById(contractId);
            repository.Delete(contract);
            return RedirectToAction("SHowContracts");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
