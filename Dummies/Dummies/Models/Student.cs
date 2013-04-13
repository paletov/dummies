using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Student")]
	public class Student
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int SyncId { get; set; }

		public int FacultyNumber { get; set; }

		[StringLength(127)]
		public string Name { get; set; }

		[StringLength(255)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public int SemesterId { get; set; }

		[ForeignKey("SemesterId")]
		public Semester Semester { get; set; }

		public int Year { get; set; }

		[StringLength(127)]
		public string BankAccount { get; set; }

		[MaxLength]
		public byte[] ProfilePicture { get; set; }

		public ICollection<Skill> Skills { get; set; }
	}
}