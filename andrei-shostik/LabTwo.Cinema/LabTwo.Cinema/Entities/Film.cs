using System;

namespace LabTwo.Cinema.Entities
{
    [Serializable]
    public partial class Film : EntityBase
    {
        public Film(string id, string title, string genre, int year)
        {
            ID = id;
            Title = title;
            Genre = genre;
            Year = year;
        }

        public Film(string title, string genre, int year)
        {
            FilmID = FilmID;
            Title = title;
            Genre = genre;
            Year = year;
        }

        public override string ToString()
        {
            return String.Join("|", ID, Title, Year, Genre);
        }

        public static bool operator ==(Film a, Film b)
        {
            if (ReferenceEquals(a, b)) return true;
            return b != null && (a != null && (a.Title == b.Title && a.Genre == b.Genre && a.Year == b.Year));
        }

        public static bool operator !=(Film a, Film b)
        {
            return !(a == b);
        }

        public bool Equals(Film other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Title, Title) && other.Year == Year && Equals(other.Genre, Genre) /*&& Equals(other.ID, ID)*/;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Film)) return false;
            return Equals((Film)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Title != null ? Title.GetHashCode() : 0);
                var i = (result * 397) ^ Year;
                if (i != null) result = (int)i;
                result = (result * 397) ^ (Genre != null ? Genre.GetHashCode() : 0);
                return result;
            }
        }
    }
}