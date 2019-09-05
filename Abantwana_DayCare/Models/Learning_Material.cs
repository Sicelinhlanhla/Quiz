using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.Models
{
	public class Learning_Material
	{
		[Key]
		public int Material_ID { get; set; }

		public byte[] material { get; set; }

		[Required]
		[Display(Name = "Description")]
		[DataType(DataType.MultilineText)]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Last Name must be atleast 3 characters long", MinimumLength = 3)]
		public string  Description { get; set; }


		public List<Quiz> quiz { get; set; }
	}
}