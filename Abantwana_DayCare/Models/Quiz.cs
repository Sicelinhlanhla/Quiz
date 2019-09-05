using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.Models
{
	public class Quiz
	{
		[Key]
		public int Quiz_ID { get; set; }

		public string Question { get; set; }

		public string Answer { get; set; }

		public string A { get; set; }

		public string B { get; set; }

		public string C { get; set; }

		public string D { get; set; }



		[ForeignKey("Learning")]
		public int Learning_ID { get; set; }
		public Learning_Material Learning { get; set; }

		public List<Enrollment> enrollments { get; set; }

	}
}