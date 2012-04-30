using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class AgentRepository : IRepository<Agent>
    {
        private const string filePath = "Agents.txt";

        public Agent GetItem(int id)
        {
            return GetAll().FirstOrDefault(agent => agent.id == id);
        }

        public IEnumerable<Agent> GetAll()
        {
            string[] agents = null;
            string[] agentFields;
            try
            {
                agents = File.ReadAllLines(filePath);
            }
            catch
            {
                return new Agent[] { new Agent(0, null) }.Select(x => x);
            }
            return agents.Select(agent =>
            {
                agentFields = agent.Split(',');
                return new Agent(Int32.Parse(agentFields[0]), agentFields[1]);
            });
        }

        public bool Add(Agent item)
        {
            FileInfo fi = new FileInfo(filePath);
            StreamWriter streamWriter = fi.AppendText();
            streamWriter.WriteLine(item.id.ToString() + ',' + item.name);
            streamWriter.Close();
            return true;
        }

        public bool Delete(int id)
        {
            var agents = GetAll().Where(agent => agent.id != id);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var agent in agents)
            {
                streamWriter.WriteLine(agent.id.ToString() + ',' + agent.name);
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(Agent item)
        {
            var agents = GetAll().Where(agent => agent.id != item.id && agent.name != item.name);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var agent in agents)
            {
                streamWriter.WriteLine(agent.id.ToString() + ',' + agent.name);
            }
            streamWriter.Close();
            return true;
        }
    }
}
