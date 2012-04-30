using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Entities
{
    public class Project
    {
        public int id { get; private set; }
        public string name { get; set; }
        public DateTime deadLine { get; set; }

        public Project(int id, string name, DateTime deadLine)
        {
            this.id = id;
            this.name = name;
            this.deadLine = deadLine;
        }

        public override string ToString()
        {
            return string.Format("Project name: {0}; \n   Project DeadLine: {1};", name, deadLine);
        }

        public override bool Equals(Object obj)
        {
            Project project = (Project)obj;
            return project.id == project.id && project.name == project.name && project.deadLine == deadLine;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
