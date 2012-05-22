using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.DataAccess;
using Lab1.Entities;
using Lab1.Business;
using System.Threading;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CreateBase();

            Timer timer = new Timer(new TimerCallback(Program.RealTimeTest), null, 0, 2000);
            Console.ReadLine();
            timer.Dispose();
            //RealTimeTest(new Object());
            //Project pr = new Project();
            //pr = new ProjectRepository().GetAll().First();
            //Console.WriteLine(pr.id);
            //Console.WriteLine(pr.name);
            //Console.WriteLine(pr.deadLine);
            //pr.id = 0;
            //new ProjectRepository().Delete(pr);
           
            //Console.ReadLine();
        }

        public static void RealTimeTest(object s)
        {
            CheckContracts();
            Client client = GenerateClient();
            if (ClientLogic.ChooseAgent(client))
            {
                ShowContracts();
            }
            else
            {
                Console.WriteLine("Application is not accepted");
            }

        }

        static void CheckContracts()
        {
            ContractRepository contractRepository = new ContractRepository();
            ProjectRepository projectRepository = new ProjectRepository();
            var projects = projectRepository.GetAll();
            foreach (var project in projects)
            {
                if (project.id == 0)
                    return;

                if (project.deadLine < DateTime.Now)
                {
                    var contractToDelete = contractRepository.GetAll().
                                           Where(contract => contract.projectId == project.id).First();
                    contractRepository.Delete(contractToDelete);
                    projectRepository.Delete(project);
                }
            }
        }

        static void ShowContracts()
        {
            var contracts = new ContractRepository().GetAll();
            ProjectRepository projectRepository = new ProjectRepository();
            Console.WriteLine("************************************");
            //Console.CursorLeft = 0;
            //Console.CursorTop = 0;
            foreach (var contract in contracts)
            {
                Console.WriteLine("Contract №{0}", contract.id);
                Console.WriteLine("  Client's name: {0}", new ClientRepository().GetItem(contract.clientId).name);
                Console.WriteLine("  Builder's name: {0}", new BuilderRepository().GetItem(contract.builderId).name);
                Console.WriteLine("  Agent's name: {0}", new AgentRepository().GetItem(contract.agentId).name);
                Console.WriteLine("  Project's name: {0}", projectRepository.GetItem(contract.projectId).name);
                Console.WriteLine("  Project's deadLine: {0}", projectRepository.GetItem(contract.projectId).deadLine);
            }
            Console.WriteLine(contracts.Count());
        }

        static Client GenerateClient()
        {
            Random randomize = new Random();
            int clientId = randomize.Next(1, 10);  
            string clientName = "Client" + clientId.ToString();
            Client client = new Client();
            client.name = clientName; 
            return client;
        }
    }
}
