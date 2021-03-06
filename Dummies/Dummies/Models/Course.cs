﻿using System;
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
		public int CourseId { get; set; }

		[StringLength(256)]
		public string Name { get; set; }

		[StringLength(8)]
		public string Group { get; set; }

		public double Credits { get; set; }

		[StringLength(15)]
		public string Semester { get; set; }

		public int BachelorProgrammeId { get; set; }

		[ForeignKey("BachelorProgrammeId")]
		public BachelorProgramme BachelorProgramme { get; set; }

		public int Year { get; set; }

		public ICollection<OpenPosition> OpenPositions { get; set; }

		public Course(string name, string group, double credits, string semester, int bachelorProgrammeId, int year)
		{
			Name = name;
			Group = group;
			Credits = credits;
			Semester = semester;
			BachelorProgrammeId = bachelorProgrammeId;
			Year = year;
		}
	}
}