using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("PositionType")]
	public class PositionType
	{
		public int PositionTypeId { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		public ICollection<OpenPosition> Positions { get; set; }
	}
}