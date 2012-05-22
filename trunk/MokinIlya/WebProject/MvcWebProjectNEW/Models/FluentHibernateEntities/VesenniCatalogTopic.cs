using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcWebProjectNEW.Models {
    
    public class VesenniCatalogTopic {
        public VesenniCatalogTopic() {
			VesenniCatalogs = new List<VesenniCatalog>();
        }
        public virtual System.Guid CatalogTopicId { get; set; }
        public virtual IList<VesenniCatalog> VesenniCatalogs { get; set; }
        public virtual string CatalogTopicName { get; set; }
    }
}
