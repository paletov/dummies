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
	public class StudentCourseRepository : IStudentCourseRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<StudentCourse> AllByStudentCourseId(int openPositionId)
		{
			return context.StudentCourseRelations.Where(c => c.StudentCourseId == openPositionId);
		}

		public IQueryable<StudentCourse> AllByStudentCourseIdIncluding(int studentCourseId, params Expression<Func<StudentCourse, object>>[] includeProperties)
		{
			IQueryable<StudentCourse> query = context.StudentCourseRelations.Where(c => c.StudentCourseId == studentCourseId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public StudentCourse Find(int id)
		{
			return context.StudentCourseRelations.Find(id);
		}

		public void InsertOrUpdate(StudentCourse studentCourse)
		{
			if (studentCourse.StudentCourseId == default(int))
			{
				// New entity
				context.StudentCourseRelations.Add(studentCourse);
			}
			else
			{
				// Existing entity
				context.Entry(studentCourse).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var studentCourse = context.StudentCourseRelations.Find(id);
			context.StudentCourseRelations.Remove(studentCourse);
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

	public interface IStudentCourseRepository : IDisposable
	{
		IQueryable<StudentCourse> AllByStudentCourseId(int studentCourseId);
		IQueryable<StudentCourse> AllByStudentCourseIdIncluding(int studentCourseId, params Expression<Func<StudentCourse, object>>[] includeProperties);
		StudentCourse Find(int id);
		void InsertOrUpdate(StudentCourse studentCourseId);
		void Delete(int id);
		void Save();
	}
}