using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("StudentCourse")]
	public class StudentCourse
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int StudentId { get; set; }

		[ForeignKey("StudentId")]
		public Student Student { get; set; }

		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course Course { get; set; }

		public bool IsTaken { get; set; }

		public int Order { get; set; }

		public double Rating { get; set; }
	}
}