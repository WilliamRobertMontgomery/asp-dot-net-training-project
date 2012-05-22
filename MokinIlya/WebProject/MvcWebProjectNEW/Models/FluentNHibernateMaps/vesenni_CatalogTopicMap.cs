using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {
    
    
    public class VesenniCatalogTopicMap : ClassMap<VesenniCatalogTopic> {
        
        public VesenniCatalogTopicMap() {
			Table("vesenni_CatalogTopics");
			LazyLoad();
            Id(x => x.CatalogTopicId).GeneratedBy.Guid().Column("CatalogTopicId");
			Map(x => x.CatalogTopicName).Column("CatalogTopicName").Length(250);
			HasMany(x => x.VesenniCatalogs).KeyColumn("CatalogTopicId");
        }
    }
}
