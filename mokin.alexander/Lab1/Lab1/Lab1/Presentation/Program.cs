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
        }

        static void CreateBase()
        {
            AgentRepository agentRepository = new AgentRepository();
            for (int i = 1; i <= 10; i++)
            {
                agentRepository.Add(new Agent(i, "Agent" + i.ToString()));
            }

            BuilderRepository builderRepository = new BuilderRepository();
            for (int i = 1; i <= 3; i++)
            {
               builderRepository.Add(new Builder(i, "Builder" + i.ToString()));
            }
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
            var projects = new ProjectRepository().GetAll();
            ContractRepository contractRepository = new ContractRepository();
            foreach (var project in projects)
            {
                if (project.id == 0)
                    return;

                if (project.deadLine < DateTime.Now)
                {
                    var contracts = contractRepository.GetAll().ToArray();
                    var variable = contracts.Where(contract => contract.project.id == project.id).First();
                    contractRepository.Delete(variable);
                    new ProjectRepository().Delete(project);
                }
            }
        }

        static void ShowContracts()
        {
            var contracts = new ContractRepository().GetAll();
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            foreach (var contract in contracts)
            {
                Console.WriteLine(contract.ToString());
            }
            Console.WriteLine(contracts.Count());
        }

        static Client GenerateClient()
        {
            Random randomize = new Random();
            int clientId = randomize.Next(1, 10);  
            string clientName = "Client" + clientId.ToString();
            return new Client(clientId, clientName);
        }
    }
}
