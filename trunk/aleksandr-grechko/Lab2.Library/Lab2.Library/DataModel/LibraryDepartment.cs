using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Library.DataModel
{
	public partial class LibraryDepartment
	{
		public LibraryDepartment(Guid id, string name, bool isAbonement)
			: this()
		{
			Id = id;
			Name = name;
			IsAbonement = isAbonement;
		}

		public LibraryDepartment(string name, bool isAbonement)
			: this()
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
			return Id.GetHashCode();
		}

	}
}
