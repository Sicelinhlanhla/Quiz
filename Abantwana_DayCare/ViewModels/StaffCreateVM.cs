using Abantwana_DayCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.ViewModels
{
	public class StaffCreateVM
	{
		[Required]
		[Display(Name = "First Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Fist Name must be atleast 3 characters long", MinimumLength = 3)]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Fist Name must be atleast 3 characters long", MinimumLength = 3)]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Email")]
		[DataType(dataType: DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Phone Number")]
		[DataType(dataType: DataType.PhoneNumber)]
		[RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
		[StringLength(maximumLength: 10, ErrorMessage = "SA Contact Number must be exactly 10 digits long", MinimumLength = 10)]
		public string phone { get; set; }
		[Required]
		[Display(Name = "ID Number")]
		[StringLength(maximumLength: 13, ErrorMessage = "SA ID Number must be exactly 13 digits long", MinimumLength = 13)]
		public string ID_Number { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(150)]
		[Display(Name = "Physical Address")]
		public string address { get; set; }

		[Display(Name = "Picture")]
		public byte[] Picture { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Fist Name must be atleast 3 characters long", MinimumLength = 3)]
		public string qualification { get; set; }


		[Required]
		[Display(Name = "Number of Work")]
		[DataType(dataType: DataType.PhoneNumber)]
		[RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
		[StringLength(maximumLength: 10, ErrorMessage = "SA Contact Number must be exactly 10 digits long", MinimumLength = 10)]
		public string Number_Of_Work { get; set; }

		[Required]
		[Display(Name = "Previous Company Name")]
		[RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
		[StringLength(maximumLength: 35, ErrorMessage = "Company name must be atleast 3 characters long", MinimumLength = 3)]
		public string Previous_Company { get; set; }

		[Required]
		[Display(Name = "Previous Company Phone Number")]
		[DataType(dataType: DataType.PhoneNumber)]
		[RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
		[StringLength(maximumLength: 10, ErrorMessage = "SA Contact Number must be exactly 10 digits long", MinimumLength = 10)]
		public string Prev_CompanyPhone { get; set; }


		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }


		public int generateID()
		{
			ApplicationDbContext db = new ApplicationDbContext();

			var x = db.StaffMembers.Count();

			return x + 1;
		}
	}
}