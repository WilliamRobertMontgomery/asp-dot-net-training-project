using System;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public partial class Order : EntityBase
    {
        public Order(string id, Visitor visitor, Cashier cashier, Film film, DateTime dateTime)
        {
            ID = id;
            Visitor = visitor;
            Cashier = cashier;
            Film = film;
            DataSale = dateTime;
        }

        public Order(Visitor visitor, Cashier cashier, Film film, DateTime dateTime)
        {
            Visitor = visitor;
            Cashier = cashier;
            Film = film;
            DataSale = dateTime;
        }

        public override string ToString()
        {
            return String.Join("|", ID, Visitor.FirstName, Visitor.LastName, Film.Title, Film.Year, Cashier.LastName, DataSale);
        }

        public static bool operator ==(Order a, Order b)
        {
            if (ReferenceEquals(a, b)) return true;
            return a.Equals(b) && b.Equals(a);
        }

        public static bool operator !=(Order a, Order b)
        {
            return !(a == b);
        }

        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Visitor, Visitor) && Equals(other.Cashier, Cashier) && Equals(other.Film, Film) &&
                   other.DataSale.Equals(DataSale) && Equals(other.ID, ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Order)) return false;
            return Equals((Order)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Visitor != null ? Visitor.GetHashCode() : 0);
                result = (result * 397) ^ (Cashier != null ? Cashier.GetHashCode() : 0);
                result = (result * 397) ^ (Film != null ? Film.GetHashCode() : 0);
                result = (result * 397) ^ DataSale.GetHashCode();
                return result;
            }
        }
    }
}