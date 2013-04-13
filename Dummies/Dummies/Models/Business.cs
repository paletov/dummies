using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Business")]
	public class Business
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int BusinessId { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
	}
}