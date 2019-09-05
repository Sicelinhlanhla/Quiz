using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.Models
{
	public class Course
	{

		[Key]
		public int Course_ID { get; set; }

		[Required]
		[Display(Name = "Title")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Course name must be atleast 3 characters long", MinimumLength = 3)]
		public string Title { get; set; }

		[Required]
		[Display(Name = "Credits")]
		public string Credits { get; set; }


		[Required]
		[Display(Name = "Description")]
		[DataType(DataType.MultilineText)]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Last Name must be atleast 3 characters long", MinimumLength = 3)]
		public string Description { get; set; }

		public List<Enrollment> enrollments { get; set; }



	}
}