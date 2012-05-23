using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebProject.Models
{
	public class SearchModel
	{
		[Required]
		[DisplayName("FirstName")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("LastName")]
		public string LastName { get; set; }

		[Required]
		[DisplayName("Age")]
		public int Age { get; set; }

		[Required]
		[DisplayName("Gender")]
		public string Gender { get; set; }

		[Required]
		[DisplayName("Country")]
		public string Country { get; set; }

		[Required]
		[DisplayName("City")]
		public string City { get; set; }
	}
}