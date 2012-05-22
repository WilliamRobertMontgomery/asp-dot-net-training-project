using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using Lab1.DataAccess;

namespace Lab1.Business
{
    public static class ClientLogic
    {
        public static bool ChooseAgent(Client client)
        {
            var agents = new AgentRepository().GetAll().ToArray();
            int agentId;
            
            Random randomize = new Random();
            int indexOfAgent = randomize.Next(0, agents.Count() - 1);
            
            agentId = agents[indexOfAgent].id;
            
            return AgentLogic.Apply(client, agentId);
        }

        //public static bool ChooseAgent()
        //{
        //    var agents = new AgentRepository().GetAll().ToArray();
        //    int agentId;

        //    var clients = new ClientRepository().GetAll();
        //    int clientId = 0;
        //    string clientName;
        //    if (clients.Last().id == 0)
        //    {
        //        clientId = 1;
        //    }
        //    else
        //    {
        //        clientId = clients.Last().id + 1;
        //    }
        //    clientName = "Client" + clientId.ToString();

        //    Random randomize = new Random();
        //    int indexOfAgent = randomize.Next(0, agents.Count() - 1);

        //    agentId = agents[indexOfAgent].id;

        //    return AgentLogic.Apply(new Client);
        //}
    }
}
