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
		public int StudentCourseId { get; set; }

		public int StudentProfileId { get; set; }

		[ForeignKey("StudentProfileId")]
		public StudentProfile StudentProfile { get; set; }

		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course Course { get; set; }

		public int Order { get; set; }

		public double Rating { get; set; }

		public StudentCourse(int studentProfileId, int courseId)
		{
			StudentProfileId = studentProfileId;
			CourseId = courseId;
		}
	}
}