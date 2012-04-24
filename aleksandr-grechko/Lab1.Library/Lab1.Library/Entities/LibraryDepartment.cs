using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.Entities
{
	public class LibraryDepartment
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public bool IsAbonement { get; private set; }

		public LibraryDepartment(Guid id, string name, bool isAbonement)
		{
			Id = id;
			Name = name;
			IsAbonement = isAbonement;
		}

		public LibraryDepartment(string name, bool isAbonement)
		{
			Id = Guid.NewGuid();
			Name = name;
			IsAbonement = isAbonement;
		}

		public override string ToString()
		{
			return Name;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is LibraryDepartment))
			{
				return false;
			}
			return LibraryDepartmentCompare(this, obj as LibraryDepartment);
		}

		public static bool operator ==(LibraryDepartment a, LibraryDepartment b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return LibraryDepartmentCompare(a, b);
		}

		private static bool LibraryDepartmentCompare(LibraryDepartment a, LibraryDepartment b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			return a.Id == b.Id && a.Name == b.Name;
		}

		public static bool operator !=(LibraryDepartment a, LibraryDepartment b)
		{
			return !(a == b);
		}


		public override int GetHashCode()
		{
			return (Id + Name + IsAbonement).GetHashCode();
		}

	}
}
