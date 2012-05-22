using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcWebProjectNEW.Models {
    
    public class VesenniCatalog {
        public VesenniCatalog() {
			VesenniCatalogArticles = new List<VesenniCatalogArticle>();
        }
        public virtual System.Guid CatalogId { get; set; }
        public virtual VesenniCatalogTopic VesenniCatalogTopic { get; set; }
        public virtual IList<VesenniCatalogArticle> VesenniCatalogArticles { get; set; }
        public virtual string CatalogName { get; set; }
    }
}
