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
	public class OpenPositionRepository : IOpenPositionRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<OpenPosition> AllByOpenPositionId(int openPositionId)
		{
			return context.OpenPositions.Where(c => c.OpenPositionId == openPositionId);
		}

		public IQueryable<OpenPosition> AllByOpenPositionIdIncluding(int openPositionId, params Expression<Func<OpenPosition, object>>[] includeProperties)
		{
			IQueryable<OpenPosition> query = context.OpenPositions.Where(c => c.OpenPositionId == openPositionId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public OpenPosition Find(int id)
		{
			return context.OpenPositions.Find(id);
		}

		public void InsertOrUpdate(OpenPosition openPosition)
		{
			if (openPosition.OpenPositionId == default(int))
			{
				// New entity
				context.OpenPositions.Add(openPosition);
			}
			else
			{
				// Existing entity
				context.Entry(openPosition).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var openPosition = context.OpenPositions.Find(id);
			context.OpenPositions.Remove(openPosition);
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

	public interface IOpenPositionRepository : IDisposable
	{
		IQueryable<OpenPosition> AllByOpenPositionId(int openPositionId);
		IQueryable<OpenPosition> AllByOpenPositionIdIncluding(int openPositionId, params Expression<Func<OpenPosition, object>>[] includeProperties);
		OpenPosition Find(int id);
		void InsertOrUpdate(OpenPosition openPositionId);
		void Delete(int id);
		void Save();
	}
}