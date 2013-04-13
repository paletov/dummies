using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Course")]
	public class Course
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Key]
		public int SyncId { get; set; }

		[StringLength(256)]
		public string Name { get; set; }

		[StringLength(8)]
		public string Group { get; set; }
	}
}