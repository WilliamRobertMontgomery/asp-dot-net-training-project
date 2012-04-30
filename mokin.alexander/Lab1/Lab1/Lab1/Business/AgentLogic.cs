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
                new ClientRepository().Add(client);
                bool contractIsMade = MakeContract(client.id, agentId, builderId, projectId);
                
                return true;
            }
            return false;
        }

        public static bool MakeContract(int clientId, int agentId, int builderId, int projectId)
        {
            ContractRepository contractRepository = new ContractRepository();
            int contractId;
            try
            {
                contractId = contractRepository.GetAll().Last().id;
            }
            catch
            {
                contractId = 1;
                contractRepository.Add( new Contract(contractId,
                                        new ClientRepository().GetItem(clientId),
                                        new AgentRepository().GetItem(agentId),
                                        new BuilderRepository().GetItem(builderId),
                                        new ProjectRepository().GetItem(projectId)));
                return true;
            }
            contractId = contractId + 1;
            contractRepository.Add(new Contract(contractId,
                                   new ClientRepository().GetItem(clientId),
                                   new AgentRepository().GetItem(agentId),
                                   new BuilderRepository().GetItem(builderId),
                                   new ProjectRepository().GetItem(projectId)));
            return true;
        }

    }
}
