using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Abantwana_DayCare.Models
{
	public class Enrollment
	{

		[Key]
		public int Enrollment_ID { get; set; }


		[ForeignKey("Course")]
		public int Course_ID { get; set; }

		[ForeignKey("Toodler")]
		public int Toodler_ID { get; set; }

		[ForeignKey("Quiz")]
		public int Quiz_ID { get; set; }


		public string Grade { get; set; }

		public Course Course { get; set; }
		public Toodler Toodler { get; set; }
		public Quiz Quiz { get; set; }
	}
}