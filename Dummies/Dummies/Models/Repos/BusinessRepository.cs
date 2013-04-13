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
	public class BusinessRepository : IBusinessRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<Business> AllByBusinessId(int businessId)
		{
			return context.Businesses.Where(c => c.BusinessId == businessId);
		}

		public IQueryable<Business> AllByBusinessIdIncluding(int businessId, params Expression<Func<Business, object>>[] includeProperties)
		{
			IQueryable<Business> query = context.Businesses.Where(c => c.BusinessId == businessId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Business Find(int id)
		{
			return context.Businesses.Find(id);
		}

		public void InsertOrUpdate(Business business)
		{
			if (business.BusinessId == default(int))
			{
				// New entity
				context.Businesses.Add(business);
			}
			else
			{
				// Existing entity
				context.Entry(business).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var business = context.Businesses.Find(id);
			context.Businesses.Remove(business);
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

	public interface IBusinessRepository : IDisposable
	{
		IQueryable<Business> AllByBusinessId(int businessId);
		IQueryable<Business> AllByBusinessIdIncluding(int businessId, params Expression<Func<Business, object>>[] includeProperties);
		Business Find(int id);
		void InsertOrUpdate(Business businessId);
		void Delete(int id);
		void Save();
	}
}