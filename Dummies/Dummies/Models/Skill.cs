using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Skill")]
	public class Skill
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int SkillId { get; set; }

		[StringLength(255)]
		public string Name { get; set; }
	}
}