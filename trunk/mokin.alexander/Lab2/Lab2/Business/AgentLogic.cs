using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using Lab1.DataAccess;
namespace Lab1.Business 
{
    public static class AgentLogic
    {
        public static bool Apply(Client client, int agentId)
        {
            int builderId = BuilderLogic.AskBuilders();
            if (builderId != -1)
            {
                int projectId = BuilderLogic.AskForTheProject();
                client.id = AddClient(client);
                bool contractIsMade = MakeContract(client.id, agentId, builderId, projectId);
                
                return true;
            }
            return false;
        }

        public static bool MakeContract(int clientId, int agentId, int builderId, int projectId)
        {
            ContractRepository contractRepository = new ContractRepository();

            Contract contract = new Contract();
            contract.agentId = agentId;
            contract.clientId = clientId;
            contract.builderId = builderId;
            contract.projectId = projectId;

            contractRepository.Add(contract);

            return true;
        }

        public static int AddClient(Client client)
        {
            ClientRepository clientRepository = new ClientRepository(); 
            try
            {
                return clientRepository.GetAll().Where(_client => _client.name.Split(' ')[0] == client.name).First().id;
            }
            catch
            {
                new ClientRepository().Add(client);
                return client.id;
            }
        }

    }
}
