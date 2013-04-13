using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Course")]
	public class Student
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Key]
		public int SyncId { get; set; }

		[StringLength(128)]
		public string Name { get; set; }

		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public Course Course { get; set; }

		public int Year { get; set; }

		[StringLength(128)]
		public string BankAccount { get; set; }
	}
}