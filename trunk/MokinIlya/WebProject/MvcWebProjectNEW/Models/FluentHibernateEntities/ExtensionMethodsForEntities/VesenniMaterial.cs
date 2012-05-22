using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebProjectNEW.Models
{
    public static class ExtensionClassForVesenniTopic
    {
        public static VesenniMaterialIntermidiate ConvertToIntermidiateClass( this VesenniMaterial material)
        {
            VesenniMaterialIntermidiate result = new VesenniMaterialIntermidiate();
            result.ContentId = material.ContentId;
            result.VesenniTopicId = material.VesenniTopic.TopicId;
            result.UserId = material.AspnetUser.UserId;
            result.Content = material.Content;
            result.KeyWords = material.KeyWords;
            result.Visits = material.Visits;
            result.TitleTag = material.TitleTag;
            result.Path = material.Path;
            result.Description = material.Description;

            return result;
        }
    }
}