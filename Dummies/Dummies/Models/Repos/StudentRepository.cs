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
	public class StudentRepository : IStudentRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<Student> AllByStudentId(int studentId)
		{
			return context.Students.Where(c => c.StudentId == studentId);
		}

		public IQueryable<Student> AllByStudentIdIncluding(int studentId, params Expression<Func<Student, object>>[] includeProperties)
		{
			IQueryable<Student> query = context.Students.Where(c => c.StudentId == studentId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Student Find(int id)
		{
			return context.Students.Find(id);
		}

		public void InsertOrUpdate(Student student)
		{
			if (student.StudentId == default(int))
			{
				// New entity
				context.Students.Add(student);
			}
			else
			{
				// Existing entity
				context.Entry(student).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var student = context.Students.Find(id);
			context.Students.Remove(student);
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

	public interface IStudentRepository : IDisposable
	{
		IQueryable<Student> AllByStudentId(int studentId);
		IQueryable<Student> AllByStudentIdIncluding(int studentId, params Expression<Func<Student, object>>[] includeProperties);
		Student Find(int id);
		void InsertOrUpdate(Student student);
		void Delete(int id);
		void Save();
	}
}