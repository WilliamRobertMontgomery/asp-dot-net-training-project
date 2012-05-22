using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebProjectNEW.Models
{
    public class VesenniLetter
    {
        public VesenniLetter() { }
        public virtual System.Guid LetterId { get; set; }
        public virtual AspnetUser AspnetUser { get; set; }
        public virtual string Content { get; set; }
        public virtual System.Nullable<System.DateTime> DateSend { get; set; }
        public virtual string Title { get; set; }
    }


}