using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.Models
{
	public class Toodler
	{
		[Key]
		public int Toodler_ID { get; set; }

		[Required]
		[Display(Name = "First Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "First Name must be atleast 3 characters long", MinimumLength = 3)]
		public string First_Name { get; set; }


		[Required]
		[Display(Name = "Last Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Last Name must be atleast 3 characters long", MinimumLength = 3)]
		public string Last_Name { get; set; }


		[Display(Name = "ID Number")]
		[StringLength(maximumLength: 13, ErrorMessage = "SA ID Number must be exactly 13 digits long", MinimumLength = 13)]
		public string ID_Number { get; set; }


		[Required]
		[Display(Name = "Date of birth")]
		[DataType(dataType: DataType.Date)]
		public string Date_of_Birth { get; set; }

		[ForeignKey("Parent")]
		public int Parent_ID { get; set; }
		public Parent_Model Parent { get; set; }

		public List<Enrollment> enrollments { get; set; }


	}
}