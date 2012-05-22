using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebProjectNEW.Models.VesenniDataAccess;

namespace MvcWebProjectNEW.Models
{
    public class VesenniMaterialIntermidiate
    {
        public VesenniMaterialIntermidiate() { }
        public System.Guid ContentId { get; set; }
        public Guid VesenniTopicId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string KeyWords { get; set; }
        public int? Visits { get; set; }
        public string TitleTag { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }

        public VesenniMaterial ConvertToFinalClass(IRepository _repository )
        {
            VesenniMaterial result = new VesenniMaterial();
            result.ContentId = ContentId;
            result.VesenniTopic = _repository.GetById<VesenniTopic>(VesenniTopicId);
            result.AspnetUser = _repository.GetById<AspnetUser>(UserId);
            result.Content = Content;
            result.KeyWords = KeyWords;
            result.Visits = Visits;
            result.TitleTag = TitleTag;
            result.Path = Path;
            result.Description = Description;

            return result;
        }
    }
}