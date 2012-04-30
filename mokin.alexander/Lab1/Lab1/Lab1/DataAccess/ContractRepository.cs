using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Entities;
using System.IO;

namespace Lab1.DataAccess
{
    public class ContractRepository : IRepository<Contract>
    {
        private const string filePath = "Contracts.txt";

        public Contract GetItem(int id)
        {
            return GetAll().FirstOrDefault(contract => contract.id == id);
        }

        public IEnumerable<Contract> GetAll()
        {
            string[] contracts = null;
            string[] contractFields;
            try
            {
                contracts = File.ReadAllLines(filePath);
            }
            catch
            {
                return new Contract[] { new Contract(0, null, null, null, null) }.Select(x => x);
            }
            return contracts.Select(contract =>
            {
                contractFields = contract.Split(',');
                return new Contract(Int32.Parse(contractFields[0]),
                                    new ClientRepository().GetItem(Int32.Parse(contractFields[1])),
                                    new AgentRepository().GetItem(Int32.Parse(contractFields[2])),
                                    new BuilderRepository().GetItem(Int32.Parse(contractFields[3])),
                                    new ProjectRepository().GetItem(Int32.Parse(contractFields[4])));
            });
        }

        public bool Add(Contract item)
        {
            FileInfo fi = new FileInfo(filePath);
            StreamWriter streamWriter = fi.AppendText();
            streamWriter.WriteLine( item.id.ToString() + ',' +
                                    item.client.id.ToString() + ',' +
                                    item.agent.id.ToString() + ',' +
                                    item.builder.id.ToString() + ',' +
                                    item.project.id.ToString()
                                  );
            streamWriter.Close();
            return true;
        }

        public bool Delete(int id)
        {
            var contracts = GetAll().Where(contract => contract.id != id);
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var contract in contracts)
            {
                streamWriter.WriteLine(
                                     '\n' + contract.id.ToString() + ',' +
                                     contract.client.id.ToString() + ',' +
                                     contract.agent.id.ToString() + ',' +
                                     contract.builder.id.ToString() + ',' +
                                     contract.project.id.ToString()
                                   );
            }
            streamWriter.Close();
            return true;
        }

        public bool Delete(Contract item)
        {
            var contracts = GetAll().Where(contract => contract.id != item.id).ToArray();
            StreamWriter streamWriter = new StreamWriter(filePath);
            foreach (var contract in contracts)
            {
                streamWriter.WriteLine(
                                     contract.id.ToString() + ',' +
                                     contract.client.id.ToString() + ',' +
                                     contract.agent.id.ToString() + ',' +
                                     contract.builder.id.ToString() + ',' +
                                     contract.project.id.ToString()
                                   );
            }
            streamWriter.Close();
            return true;
        }
    }
}
