﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dummies.Models
{
	[Table("Semester")]
	public class Semester
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int SemesterId { get; set; }

		[StringLength(8)]
		public string Season { get; set; }

		public int StartYear { get; set; }

		public int EndYear { get; set; }

		public Semester(string season, int startYear, int endYear)
		{
			Season = season;
			StartYear = startYear;
			EndYear = endYear;
		}
	}
}