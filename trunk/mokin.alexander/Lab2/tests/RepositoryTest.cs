namespace tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Lab1.DataAccess;
    using Lab1.Entities;


    [TestFixture]
    public class RepositoryTest
    {
        [Test]
        public void AgentRepositoryTest()
        {
            AgentRepository repository = new AgentRepository();
            Agent expectedAgent = new Agent
            {
                name = "agensomeagent"
            };

            repository.Add(expectedAgent);


            Agent realAgent = repository.GetAll().Last();

            Assert.AreEqual(expectedAgent.name, realAgent.name);

            repository.Delete(realAgent);


            realAgent = repository.GetAll().Last();

            Assert.AreNotEqual(expectedAgent.name, realAgent.name);

        }

        [Test]
        public void BuilderRepositoryRepositoryTest()
        {
            BuilderRepository repository = new BuilderRepository();
            Builder expectedBuilder = new Builder { name = "BuildersomeBuilder" };

            repository.Add(expectedBuilder);


            Builder realBuilder = repository.GetAll().Last();

            Assert.AreEqual(expectedBuilder.name, realBuilder.name);

            repository.Delete(realBuilder);

            realBuilder = repository.GetAll().Last();

            Assert.AreNotEqual(expectedBuilder.name, realBuilder.name);

        }

        [Test]
        public void ClientRepositoryTest()
        {
            ClientRepository repository = new ClientRepository();
            Client expectedClient = new Client { name = "clientsomeclient" };

            repository.Add(expectedClient);

            Client realClient = repository.GetAll().Last();

            Assert.AreEqual(expectedClient, realClient);

            repository.Delete(realClient);


            realClient = repository.GetAll().Last();

            Assert.AreNotEqual(expectedClient.name, realClient.name);

        }

        [Test]
        public void ProjectRepositoryTest()
        {
            ProjectRepository repository = new ProjectRepository();
            DateTime time = DateTime.MinValue;
            Project expectedProject = new Project { name = "projectsomeproject", deadLine = time };

            repository.Add(expectedProject);


            Project realProject = repository.GetAll().Last();

            Assert.AreEqual(expectedProject.name, realProject.name);
            Assert.AreEqual(expectedProject.deadLine, realProject.deadLine);

            repository.Delete(realProject);


            realProject = repository.GetAll().Last();

            Assert.AreNotEqual(expectedProject.name, realProject.name);
            Assert.AreNotEqual(expectedProject.deadLine, realProject.deadLine);

        }

        [Test]
        public void ContractRepositoryTest()
        {
            ContractRepository repository = new ContractRepository();
            Contract expectedContract = new Contract 
            { 
                agentId = 10,
                builderId = 10,
                clientId = 10,
                projectId = 10
            };

            repository.Add(expectedContract);


            Contract realContract = repository.GetAll().Last();

            Assert.AreEqual(expectedContract, realContract);

            repository.Delete(realContract);


            realContract = repository.GetAll().Last();

            Assert.AreNotEqual(expectedContract, realContract);

        }

    }

}
