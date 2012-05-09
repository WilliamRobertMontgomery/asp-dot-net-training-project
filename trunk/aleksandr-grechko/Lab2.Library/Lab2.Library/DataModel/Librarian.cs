using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2.Library.DataModel
{
	public partial class Librarian
	{

		public Librarian(Guid id, string fullName, LibraryDepartment department)
			: this()
		{
			Id = id;
			FullName = fullName;
			Department = department;
		}

		public Librarian(string fullName, LibraryDepartment department)
			: this()
		{
			Id = Guid.NewGuid();
			FullName = fullName;
			Department = department;
		}

		public override string ToString()
		{
			return String.Join(" ", FullName, Department.Name);
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Librarian))
			{
				return false;
			}
			return LibrarianCompare(this, obj as Librarian);
		}

		public static bool operator ==(Librarian a, Librarian b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return LibrarianCompare(a, b);
		}

		private static bool LibrarianCompare(Librarian a, Librarian b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			return a.Id == b.Id &&
				a.FullName == b.FullName &&
				a.Department == b.Department;
		}

		public static bool operator !=(Librarian a, Librarian b)
		{
			return !(a == b);
		}


		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

	}
}
