using System;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public partial class Cashier : EntityBase
    {
        public Cashier(string id, string firstName, string lastName)
        {
            ID = id;
            CashierID = CashierID;
            FirstName = firstName;
            LastName = lastName;
        }

        public Cashier(string firstName, string lastName)
        {
            CashierID = CashierID;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return String.Join("|", ID, FirstName, LastName);
        }

        public static bool operator ==(Cashier a, Cashier b)
        {
            if (ReferenceEquals(a, b)) return true;
            return b != null && (a != null && (a.FirstName == b.FirstName && a.LastName == b.LastName));
        }

        public static bool operator !=(Cashier a, Cashier b)
        {
            return !(a == b);
        }

        public bool Equals(Cashier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.FirstName, FirstName) && Equals(other.LastName, LastName)/* && Equals(other.ID, ID)*/;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Cashier)) return false;
            return Equals((Cashier)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^
                       (LastName != null ? LastName.GetHashCode() : 0);
            }
        }
    }
}