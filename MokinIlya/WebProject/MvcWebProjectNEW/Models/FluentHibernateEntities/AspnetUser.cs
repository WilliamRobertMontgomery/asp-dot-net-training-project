using System.Collections.Generic; 
using System.Text; 
using System; 


namespace MvcWebProjectNEW.Models {
    
    public class AspnetUser {
        public AspnetUser() {
			VesenniCatalogArticles = new List<VesenniCatalogArticle>();
			VesenniMaterials = new List<VesenniMaterial>();
            VesenniLetters = new List<VesenniLetter>();
        }
        public virtual System.Guid UserId { get; set; }
        public virtual IList<VesenniCatalogArticle> VesenniCatalogArticles { get; set; }
        public virtual IList<VesenniMaterial> VesenniMaterials { get; set; }
        public virtual IList<VesenniLetter> VesenniLetters { get; set; }
        public virtual string UserName { get; set; }
        public virtual string LoweredUserName { get; set; }
        public virtual string MobileAlias { get; set; }
        public virtual bool IsAnonymous { get; set; }
        public virtual System.DateTime LastActivityDate { get; set; }

        public virtual string Address { get; set; }
        public virtual string CompaniName { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Telephone1 { get; set; }
        public virtual string Telephone2 { get; set; }
        public virtual string FullName { get; set; }
        public virtual string OtherInformation { get; set; }

    }
}
