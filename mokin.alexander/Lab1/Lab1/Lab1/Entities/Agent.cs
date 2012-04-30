using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Agent
    {
        public int id { get; private set; }
        public string name { get; set; }

        public Agent(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("Agent name: {0}\n", name);
        }

        public override bool Equals(Object obj)
        {
            Agent agent = (Agent)obj;
            return agent.id == agent.id && agent.name == agent.name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
