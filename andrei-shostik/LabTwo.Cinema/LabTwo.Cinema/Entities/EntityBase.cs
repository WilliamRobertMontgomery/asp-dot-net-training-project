using System;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public abstract class EntityBase
    {
        public string ID { get; set; }

        protected EntityBase()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}