using System.Collections.Generic; 
using System.Text; 
using System;
using MvcWebProjectNEW.Models.VesenniDataAccess; 


namespace MvcWebProjectNEW.Models {
    
    public class VesenniMaterial {
        public VesenniMaterial() { }
        public virtual System.Guid ContentId { get; set; }
        public virtual VesenniTopic VesenniTopic { get; set; }
        public virtual AspnetUser AspnetUser { get; set; }
        public virtual string Content { get; set; }
        public virtual string KeyWords { get; set; }
        public virtual System.Nullable<int> Visits { get; set; }
        public virtual string TitleTag { get; set; }
        public virtual string Path { get; set; }
        public virtual string Description { get; set; }
    }
}
