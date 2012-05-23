using System;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public partial class Seat
    {
        public Seat(string id, string seatnumber)
        {
            OrderID = id;
            SeatNumber = seatnumber;
        }

        public const int MaxSeats = 80;

        public override string ToString()
        {
            return string.Format("{0}|{1}", OrderID, SeatNumber);
        }

        public static bool operator ==(Seat a, Seat b)
        {
            if (ReferenceEquals(a, b)) return true;
            return a.Equals(b) && b.Equals(a);
        }

        public static bool operator !=(Seat a, Seat b)
        {
            return !(a == b);
        }

        public bool Equals(Seat other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._OrderID, _OrderID) && Equals(other._SeatNumber, _SeatNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Seat)) return false;
            return Equals((Seat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_OrderID != null ? _OrderID.GetHashCode() : 0) * 397) ^ (_SeatNumber != null ? _SeatNumber.GetHashCode() : 0);
            }
        }
    }
}