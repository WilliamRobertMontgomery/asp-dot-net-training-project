using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Builder
    {
        public int id { get; private set; }
        public string name { get; set; }

        public Builder(int id, string name)
        {
            this.id = id;
            this.name = name;            
        }

        public override string ToString()
        {
            return string.Format("Builder name: {0}\n", name);
        }

        public override bool Equals(Object obj)
        {
            Builder builder = (Builder)obj;
            return builder.id == builder.id && builder.name == builder.name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
