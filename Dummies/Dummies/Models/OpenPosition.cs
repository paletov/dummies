using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("OpenPosition")]
	public class OpenPosition
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int OpenPositionId { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		public int BusinessUserId { get; set; }

		[ForeignKey("BusinessUserId")]
		public UserProfile BusinessUser { get; set; }

		public int PositionTypeId { get; set; }

		[ForeignKey("PositionTypeId")]
		public PositionType PositionType { get; set; }

		public ICollection<Course> Courses { get; set; }
	}
}