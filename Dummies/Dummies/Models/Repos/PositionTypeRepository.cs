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
	public class PositionTypeRepository : IPositionTypeRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<PositionType> AllByPositionTypeId(int positionTypeId)
		{
			return context.PositionTypes.Where(c => c.PositionTypeId == positionTypeId);
		}

		public IQueryable<PositionType> AllByPositionTypeIdIncluding(int positionTypeId, params Expression<Func<PositionType, object>>[] includeProperties)
		{
			IQueryable<PositionType> query = context.PositionTypes.Where(c => c.PositionTypeId == positionTypeId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public PositionType Find(int id)
		{
			return context.PositionTypes.Find(id);
		}

		public void InsertOrUpdate(PositionType positionType)
		{
			if (positionType.PositionTypeId == default(int))
			{
				// New entity
				context.PositionTypes.Add(positionType);
			}
			else
			{
				// Existing entity
				context.Entry(positionType).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var positionType = context.PositionTypes.Find(id);
			context.PositionTypes.Remove(positionType);
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

	public interface IPositionTypeRepository : IDisposable
	{
		IQueryable<PositionType> AllByPositionTypeId(int positionTypeId);
		IQueryable<PositionType> AllByPositionTypeIdIncluding(int positionTypeId, params Expression<Func<PositionType, object>>[] includeProperties);
		PositionType Find(int id);
		void InsertOrUpdate(PositionType positionTypeId);
		void Delete(int id);
		void Save();
	}
}