using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Dummies.Models.Contexts;

namespace Dummies.Models.Repos
{
	public class StudentProfileRepository : IStudentProfileRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<StudentProfile> AllByStudentProfileId(int studentProfileId)
		{
			return context.StudentProfiles.Where(c => c.StudentProfileId == studentProfileId);
		}

		public IQueryable<StudentProfile> AllByStudentProfileIdIncluding(int semesterId, params Expression<Func<StudentProfile, object>>[] includeProperties)
		{
			IQueryable<StudentProfile> query = context.StudentProfiles.Where(c => c.StudentProfileId == studentProfileId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public StudentProfile Find(int id)
		{
			return context.StudentProfiles.Find(id);
		}

		public void InsertOrUpdate(StudentProfile studentProfile)
		{
			if (studentProfile.SemesterId == default(int))
			{
				// New entity
				context.StudentProfiles.Add(studentProfile);
			}
			else
			{
				// Existing entity
				context.Entry(studentProfile).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var studentProfile = context.StudentProfiles.Find(id);
			context.StudentProfiles.Remove(studentProfile);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}

	public interface IStudentProfileRepository : IDisposable
	{
		IQueryable<StudentProfile> AllByStudentProfileId(int studentProfileId);
		IQueryable<StudentProfile> AllByStudentProfileIdIncluding(int semesterId, params Expression<Func<StudentProfile, object>>[] includeProperties);
		StudentProfile Find(int id);
		void InsertOrUpdate(StudentProfile studentProfile);
		void Delete(int id);
		void Save();
	}
}