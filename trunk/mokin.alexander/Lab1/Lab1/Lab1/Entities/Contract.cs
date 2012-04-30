using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Contract
    {
        public int id { get; private set; }
        public Client client { get; set; }
        public Agent agent { get; set; }
        public Builder builder { get; set; }
        public Project project { get; set; }

        public Contract(int id, Client client, Agent agent, Builder builder, Project project)
        {
            this.id = id;
            this.client = client;
            this.agent = agent;
            this.builder = builder;
            this.project = project;
        }

        public override string ToString()
        {
            return string.Format("Contract №{0}:\n   {1}   {2}   {3}   {4}",
                                 id, client.ToString(), agent.ToString(), builder.ToString(), project.ToString());
        }
    }
}
  