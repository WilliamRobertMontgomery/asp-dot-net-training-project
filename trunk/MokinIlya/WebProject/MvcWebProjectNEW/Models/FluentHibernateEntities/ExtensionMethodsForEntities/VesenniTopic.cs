using System.Collections.Generic;
using System.Text;
using System;
using MvcWebProjectNEW.Models.VesenniDataAccess;


namespace MvcWebProjectNEW.Models
{

    public static class ExtensionClassForVesenniMaterial
    {

        public static VesenniTopicIntermidiate ConvertToIntermidiateClass(this VesenniTopic topic)
        {
            VesenniTopicIntermidiate result = new VesenniTopicIntermidiate();
            result.TopicId = topic.TopicId;
            result.TopicName = topic.TopicName;

            return result;
        }
    }
}
