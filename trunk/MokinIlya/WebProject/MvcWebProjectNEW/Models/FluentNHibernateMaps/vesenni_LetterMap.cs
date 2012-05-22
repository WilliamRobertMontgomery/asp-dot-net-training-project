using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace MvcWebProjectNEW.Models
{
    public class VesenniLetterMap : ClassMap<VesenniLetter>
    {

        public VesenniLetterMap()
        {
            Table("vesenni_Letters");
            LazyLoad();
            Id(x => x.LetterId).GeneratedBy.Guid().Column("LetterId");
            References(x => x.AspnetUser).Column("UserId");
            Map(x => x.Content).Column("Content");
            Map(x => x.DateSend).Column("DateSend");
            Map(x => x.Title).Column("Title").Length(500);
        }
    }


}