using System;
using System.Data.Linq;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public partial class Visitor : EntityBase
    {
        public Visitor(string id, string firstName, string lastName, int pasportNumber)
        {
            ID = id;
            VisitorID = ID;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = pasportNumber;
        }

        public Visitor(string firstName, string lastName, int pasportNumber, EntitySet<Order> orders)
        {
            _Orders = orders;
            VisitorID = ID;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = pasportNumber;
        }

        public override string ToString()
        {
            return String.Join("|", ID, FirstName, LastName, PassportNumber);
        }

        public static bool operator ==(Visitor a, Visitor b)
        {
            if (ReferenceEquals(a, b)) return true;
            return b != null && (a != null && (a.FirstName == b.FirstName && a.LastName == b.LastName && a.PassportNumber == b.PassportNumber));
            //a.Equals(b) && b.Equals(a);
        }

        public static bool operator !=(Visitor a, Visitor b)
        {
            return !(a == b);
        }

        public bool Equals(Visitor other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.FirstName, FirstName) && Equals(other.LastName, LastName) &&
                   other.PassportNumber == PassportNumber /*&& Equals(other.ID, ID)*/;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Visitor)) return false;
            return Equals((Visitor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (FirstName != null ? FirstName.GetHashCode() : 0);
                result = (result * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
                result = (result * 397) ^ PassportNumber;
                return result;
            }
        }
    }
}