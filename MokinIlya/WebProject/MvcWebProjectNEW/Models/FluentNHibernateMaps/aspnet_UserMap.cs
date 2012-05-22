using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models {


    public class AspnetUserMap : ClassMap<AspnetUser>
    {

        public AspnetUserMap()
        {
            Table("aspnet_Users");
            LazyLoad();
            Id(x => x.UserId).GeneratedBy.Guid().Column("UserId");
            Map(x => x.UserName).Column("UserName").Not.Nullable().Length(256);
            Map(x => x.LoweredUserName).Column("LoweredUserName").Not.Nullable().Length(256);
            Map(x => x.MobileAlias).Column("MobileAlias").Length(16);
            Map(x => x.IsAnonymous).Column("IsAnonymous").Not.Nullable();
            Map(x => x.LastActivityDate).Column("LastActivityDate").Not.Nullable();
            HasMany(x => x.VesenniCatalogArticles).KeyColumn("AutorId");
            HasMany(x => x.VesenniMaterials).KeyColumn("AutorId");
            HasMany(x => x.VesenniLetters).KeyColumn("UserId");

            Map(x => x.Address).Column("Address").Length(250);
            Map(x => x.CompaniName).Column("CompaniName").Length(250);
            Map(x => x.ZipCode).Column("ZipCode").Length(16);
            Map(x => x.Telephone1).Column("Telephone1").Length(16);
            Map(x => x.Telephone2).Column("Telephone2").Length(16);
            Map(x => x.FullName).Column("FullName").Length(250);
            Map(x => x.OtherInformation).Column("OtherInformation").Length(500);

        }
    }

}
