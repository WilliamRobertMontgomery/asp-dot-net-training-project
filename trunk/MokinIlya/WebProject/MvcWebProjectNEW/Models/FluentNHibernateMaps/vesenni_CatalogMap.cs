using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {
    
    
    public class VesenniCatalogMap : ClassMap<VesenniCatalog> {
        
        public VesenniCatalogMap() {
			Table("vesenni_Catalog");
			LazyLoad();
            Id(x => x.CatalogId).GeneratedBy.Guid().Column("CatalogId");
			References(x => x.VesenniCatalogTopic).Column("CatalogTopicId");
			Map(x => x.CatalogName).Column("CatalogName").Length(250);
			HasMany(x => x.VesenniCatalogArticles).KeyColumn("CatalogId");
        }
    }
}
