using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebProject.Models
{
	public class MessageModel
	{
		[Required]
		[DisplayName("Id")]
		public Guid Id { get; set; }


		[Required]
		[DisplayName("Autor")]
		public string Autor { get; set; }

		[Required]
		[DisplayName("DateTime")]
		public DateTime DateTime { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[DisplayName("Text")]
		public string Text { get; set; }
	}

	public class CreateMessageModel
	{
		[Required]
		[DisplayName("Friend")]
		public string Friend { get; set; }

		[Required]
		[DataType(DataType.MultilineText)]
		[DisplayName("Text")]
		public string Text { get; set; }
	}
}