using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcWebProjectNEW.Models {
    
    public class VesenniTopic {
        public VesenniTopic() {
			VesenniMaterials = new List<VesenniMaterial>();
        }
        public virtual System.Guid TopicId { get; set; }
        public virtual IList<VesenniMaterial> VesenniMaterials { get; set; }
        public virtual string TopicName { get; set; }

    }
}
