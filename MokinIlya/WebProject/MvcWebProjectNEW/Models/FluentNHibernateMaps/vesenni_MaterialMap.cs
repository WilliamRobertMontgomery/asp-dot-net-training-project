using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {
    
    
    public class VesenniMaterialMap : ClassMap<VesenniMaterial> {
        
        public VesenniMaterialMap() {
			Table("vesenni_Materials");
			LazyLoad();
            Id(x => x.ContentId).GeneratedBy.Guid().Column("ContentId");
			References(x => x.VesenniTopic).Column("TopicId");
			References(x => x.AspnetUser).Column("AutorId");
			Map(x => x.Content).Length(80000).Column("Content");
			Map(x => x.KeyWords).Column("KeyWords").Length(250);
			Map(x => x.Visits).Column("Visits");
			Map(x => x.TitleTag).Column("TitleTag").Length(250);
			Map(x => x.Path).Column("Path").Length(250);
            Map(x => x.Description).Column("Description").Length(300);
        }
    }
}
