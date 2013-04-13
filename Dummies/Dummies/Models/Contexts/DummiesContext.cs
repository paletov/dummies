using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dummies.Models.Contexts
{
	public class DummiesContext : DbContext
	{
		public DbSet<UserProfile> UserProfiles { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<BachelorProgramme> BachelorProgrammes { get; set; }
		public DbSet<Semester> Semesters { get; set; }
		public DbSet<StudentCourse> StudentCourseRelations { get; set; }
		public DbSet<Business> Businesses { get; set; }
		public DbSet<OpenPosition> OpenPositions { get; set; }
		public DbSet<PositionType> PositionTypes { get; set; }
		public DbSet<PersonalOffer> PersonalOffers { get; set; }

		public DummiesContext()
			: base("DefaultConnection")
		{
			Configuration.ProxyCreationEnabled = false;
		}

		//http://www.codeproject.com/Articles/234606/Creating-a-Many-To-Many-Mapping-Using-Code-First
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			//modelBuilder.Entity<Meeting>()
			//               .HasMany<Contact>(m => m.Contacts)
			//               .WithMany(x => x.Meetings)
			//               .Map(x =>
			//               {
			//                   x.MapLeftKey("ContactId");
			//                   x.MapRightKey("MeetingId");
			//                   x.ToTable("ContactsMeetings");
			//               });
		}
	}
}