﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1.Library.Entities
{
	public class Reader
	{
		public Guid Id { get; private set; }
		public string FullName { get; private set; }
		public string Address { get; private set; }

		public Reader(string fullName, string address)
		{
			Id = Guid.NewGuid();
			FullName = fullName;
			Address = address;
		}

		public Reader(Guid id, string fullName, string address)
		{
			Id = id;
			FullName = fullName;
			Address = address;
		}

		public override string ToString()
		{
			return String.Join(" ", FullName, Address);
		}

		public override bool Equals(Object obj)
		{
			if (obj == null || !(obj is Reader))
			{
				return false;
			}
			return ReaderCompare(this, obj as Reader);
		}

		public static bool operator ==(Reader a, Reader b)
		{
			if (((object)a == null) ^ ((object)b == null))
			{
				return false;
			}
			return ReaderCompare(a, b);
		}

		private static bool ReaderCompare(Reader a, Reader b)
		{
			if (Object.ReferenceEquals(a, b))
			{
				return true;
			}
			return a.Id == b.Id &&
				a.FullName == b.FullName &&
				a.Address == b.Address;
		}

		public static bool operator !=(Reader a, Reader b)
		{
			return !(a == b);
		}


		public override int GetHashCode()
		{
			return (Id + FullName + Address).GetHashCode();
		}
	}
}