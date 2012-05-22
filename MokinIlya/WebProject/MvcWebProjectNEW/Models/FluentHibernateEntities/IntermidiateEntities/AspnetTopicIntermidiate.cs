using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebProjectNEW.Models.VesenniDataAccess;

namespace MvcWebProjectNEW.Models
{
    public class VesenniTopicIntermidiate
    {
        public virtual System.Guid TopicId { get; set; }
        public virtual string TopicName { get; set; }

        public VesenniTopic ConvertToFinalClass(IRepository _repository)
        {
            VesenniTopic result = new VesenniTopic();
            result.TopicId = TopicId;
            result.TopicName = TopicName;
            result.VesenniMaterials = _repository.GetAll<VesenniMaterial>();

            return result;
        }
    }
}