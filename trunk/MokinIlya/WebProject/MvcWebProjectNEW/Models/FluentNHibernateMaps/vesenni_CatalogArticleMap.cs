using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {
    
    
    public class VesenniCatalogArticleMap : ClassMap<VesenniCatalogArticle> {
        
        public VesenniCatalogArticleMap() {
			Table("vesenni_CatalogArticles");
			LazyLoad();
            Id(x => x.ArticleId).GeneratedBy.Guid().Column("ArticleId");
			References(x => x.VesenniCatalog).Column("CatalogId");
			References(x => x.AspnetUser).Column("AutorId");
			Map(x => x.Content).Column("Content");
			Map(x => x.TitleTag).Column("TitleTag").Length(250);
			Map(x => x.KeyWords).Column("KeyWords").Length(250);
			Map(x => x.Visits).Column("Visits");
        }
    }
}
