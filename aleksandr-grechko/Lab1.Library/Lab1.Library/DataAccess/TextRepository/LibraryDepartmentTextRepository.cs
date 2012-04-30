using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1.Library.Entities;
using System.IO;
using System.Xml.Linq;

namespace Lab1.Library.DataAccess
{
    public class LibraryDepartmentTextRepository : LibraryDepartmentRepository
    {

		private const string FileName = @"Text\Departments.txt";

		private const int RecordSize = 256;

		private const int MaxRecordStringLength = (RecordSize - 2) / 2;

		public LibraryDepartmentTextRepository()
		{
			if (!Directory.GetParent(FileName).Exists) Directory.GetParent(FileName).Create();
			if (!File.Exists(FileName)) File.Create(FileName).Close();
		}

		public override LibraryDepartment GetItem(Guid id)
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
			{
				while (binaryReader.PeekChar() != -1)
				{
					string[] arrayString = binaryReader.ReadString().Split('|');
					if (arrayString[0] == id.ToString())
					{
						return CreateLibraryDepartment(arrayString);
					}
				}
				return null;
			}
		}

		public override IEnumerable<LibraryDepartment> GetItems()
		{
			using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
			{
				while (binaryReader.PeekChar() != -1)
				{
					yield return CreateLibraryDepartment(binaryReader.ReadString().Split('|'));
				}
			}
		}

		public override void Save(LibraryDepartment item)
		{
			int i = 0;
			using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
			{
				while (binaryReader.PeekChar() != -1)
				{
					string[] arrayString = binaryReader.ReadString().Split('|');
					if (arrayString[0] == item.Id.ToString()) break;
					i = i + 1;
				}
			}
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FileName, FileMode.Open, FileAccess.Write), Encoding.Unicode))
			{
				binaryWriter.Seek(i * RecordSize, SeekOrigin.Begin);
				StringBuilder str = new StringBuilder(String.Join("|", item.Id.ToString(), item.Name, item.IsAbonement.ToString()));
				str.Append("|");
				str.Length = MaxRecordStringLength;
				binaryWriter.Write(str.ToString());
			}
		}

		public override void Remove(LibraryDepartment item)
		{
			Remove(item.Id);
		}

		public override void Remove(Guid id)
		{
			List<String> listString = new List<String>();
			using (BinaryReader binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open), Encoding.Unicode))
			{
				while (binaryReader.PeekChar() != -1)
				{
					string str = binaryReader.ReadString();
					string[] arrayString = str.Split('|');
					if (arrayString[0] != id.ToString())
					{
						listString.Add(str);
					}
				}
			}
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(FileName, FileMode.Create, FileAccess.Write), Encoding.Unicode))
			{
				foreach (string s in listString)
				{
					binaryWriter.Write(s);
				}
			}
		}

		private LibraryDepartment CreateLibraryDepartment(string[] arrayString)
		{
			return new LibraryDepartment(new Guid(arrayString[0]), arrayString[1], Convert.ToBoolean(arrayString[2]));
		}

    }
}
