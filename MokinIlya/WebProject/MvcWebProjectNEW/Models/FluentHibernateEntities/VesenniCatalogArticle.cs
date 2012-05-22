using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcWebProjectNEW.Models {
    
    public class VesenniCatalogArticle {
        public VesenniCatalogArticle() { }
        public virtual System.Guid ArticleId { get; set; }
        public virtual VesenniCatalog VesenniCatalog { get; set; }
        public virtual AspnetUser AspnetUser { get; set; }
        public virtual string Content { get; set; }
        public virtual string TitleTag { get; set; }
        public virtual string KeyWords { get; set; }
        public virtual System.Nullable<int> Visits { get; set; }
    }
}
