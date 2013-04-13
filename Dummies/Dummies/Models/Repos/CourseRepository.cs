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
	public class CourseRepository : ICourseRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<Course> AllByCourseId(int courseId)
		{
			return context.Courses.Where(c => c.CourseId == courseId);
		}

		public IQueryable<Course> AllByCourseIdIncluding(int courseId, params Expression<Func<Course, object>>[] includeProperties)
		{
			IQueryable<Course> query = context.Courses.Where(c => c.CourseId == courseId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Course Find(int id)
		{
			return context.Courses.Find(id);
		}

		public void InsertOrUpdate(Course course)
		{
			if (course.CourseId == default(int))
			{
				// New entity
				context.Courses.Add(course);
			}
			else
			{
				// Existing entity
				context.Entry(course).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var course = context.Courses.Find(id);
			context.Courses.Remove(course);
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

	public interface ICourseRepository : IDisposable
	{
		IQueryable<Course> AllByCourseId(int courseId);
		IQueryable<Course> AllByCourseIdIncluding(int courseId, params Expression<Func<Course, object>>[] includeProperties);
		Course Find(int id);
		void InsertOrUpdate(Course courseId);
		void Delete(int id);
		void Save();
	}
}