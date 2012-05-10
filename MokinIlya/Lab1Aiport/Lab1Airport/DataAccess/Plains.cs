using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1Airport.Entities;

namespace Lab1Airport
{
    public class AccessToPlanes : IRepository<Planes>
    {
        private int _lastId;

        public AccessToPlanes()
        {
            _lastId = 0;
        }

        public Planes GetElement(int id)
        {
            return DBAiportDataContext.Planes.SingleOrDefault(m => m.CodePlane == id);
        }

        public IEnumerable<Planes> GetAll()
        {
            return DBAiportDataContext.Planes;
        }

        public void AddElement(Planes element)
        {
            element.CodePlane = _lastId;
            _lastId += 1;

            DBAiportDataContext.Planes.Add(element);
        }

        public void UpdateElement(Planes element)
        {
            int updateElementIndex = DBAiportDataContext.Planes.FindIndex(x => x == element);
            Planes updateElement = GetElement(element.CodePlane);
            if (updateElement != null)
            {
                updateElement.NumberOfSeats = element.NumberOfSeats;
            }
            DBAiportDataContext.Planes[updateElementIndex] = updateElement;

        }

        public void DeleteElement(int id)
        {
            Planes element = GetElement(id);
            DBAiportDataContext.Planes.Remove(element);
        }

        public void DeleteElement(Planes element)
        {
            DeleteElement(element.CodePlane);
        }
    }
}
