using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("BachelorProgramme")]
	public class BachelorProgramme
	{
		[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int BachelorProgrammeId { get; set; }

		public int SyncId { get; set; }

		[StringLength(256)]
		public string Name { get; set; }
	}
}