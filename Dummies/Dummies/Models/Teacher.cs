using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Teacher")]
	public class Teacher
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public int SyncId { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		[StringLength(255)]
		public string Title { get; set; }

		[StringLength(255)]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[StringLength(255)]
		public string Department { get; set; }

		[StringLength(255)]
		public string Fullname { get; set; }

		[StringLength(255)]
		public string Position { get; set; }

		public ICollection<Course> Courses { get; set; }
	}
}