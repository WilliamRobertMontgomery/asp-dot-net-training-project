using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {
    
    
    public class VesenniTopicMap : ClassMap<VesenniTopic> {
        
        public VesenniTopicMap() {
			Table("vesenni_Topics");
			LazyLoad();
            Id(x => x.TopicId).GeneratedBy.Guid().Column("TopicId");
			Map(x => x.TopicName).Column("TopicName").Length(250);
			HasMany(x => x.VesenniMaterials).KeyColumn("TopicId");
        }
    }
}
