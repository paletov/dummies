using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("StudentProfile")]
	public class StudentProfile
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int StudentProfileId { get; set; }

		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public UserProfile UserProfile { get; set; }

		public string FacultyNumber { get; set; }

		public int SemesterId { get; set; }

		[ForeignKey("SemesterId")]
		public Semester Semester { get; set; }

		public int Year { get; set; }

		public ICollection<Skill> Skills { get; set; }

		public StudentProfile()
		{
		}

		public StudentProfile(int userId, string facultyNumber, int semesterId)
		{
			UserId = userId;
			FacultyNumber = facultyNumber;
			SemesterId = semesterId;
		}
	}
}