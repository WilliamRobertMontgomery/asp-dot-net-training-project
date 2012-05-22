using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class ShowContractModel
    {
        public int ContractId { get; set; }

        public string clientName { get; set; }

        public string builderName { get; set; }

        public string agentName { get; set; }

        public string projectName { get; set; }

        public string projectDescription { get; set; }

        public DateTime projectDeadLine { get; set; }
    }
}