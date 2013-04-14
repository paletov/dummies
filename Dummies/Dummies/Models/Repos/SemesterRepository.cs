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
	public class SemesterRepository : ISemesterRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<Semester> AllBySemesterId(int semesterId)
		{
			return context.Semesters.Where(c => c.SemesterId == semesterId);
		}

		public IQueryable<Semester> AllBySemesterIdIncluding(int semesterId, params Expression<Func<Semester, object>>[] includeProperties)
		{
			IQueryable<Semester> query = context.Semesters.Where(c => c.SemesterId == semesterId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Semester Find(int id)
		{
			return context.Semesters.Find(id);
		}

		public void InsertOrUpdate(Semester semester)
		{
			if (semester.SemesterId == default(int))
			{
				// New entity
				context.Semesters.Add(semester);
			}
			else
			{
				// Existing entity
				context.Entry(semester).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var semester = context.Semesters.Find(id);
			context.Semesters.Remove(semester);
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

	public interface ISemesterRepository : IDisposable
	{
		IQueryable<Semester> AllBySemesterId(int semesterId);
		IQueryable<Semester> AllBySemesterIdIncluding(int semesterId, params Expression<Func<Semester, object>>[] includeProperties);
		Semester Find(int id);
		void InsertOrUpdate(Semester semester);
		void Delete(int id);
		void Save();
	}
}