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
	public class BachelorProgrammeRepository : IBachelorProgrammeRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<BachelorProgramme> AllByBachelorProgrammeId(int bachelorProgrammeId)
		{
			return context.BachelorProgrammes.Where(c => c.BachelorProgrammeId == bachelorProgrammeId);
		}

		public IQueryable<BachelorProgramme> AllByBachelorProgrammeIdIncluding(int bachelorProgrammeId, params Expression<Func<BachelorProgramme, object>>[] includeProperties)
		{
			IQueryable<BachelorProgramme> query = context.BachelorProgrammes.Where(c => c.BachelorProgrammeId == bachelorProgrammeId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public BachelorProgramme Find(int id)
		{
			return context.BachelorProgrammes.Find(id);
		}

		public void InsertOrUpdate(BachelorProgramme bachelorProgramme)
		{
			if (bachelorProgramme.BachelorProgrammeId == default(int))
			{
				// New entity
				context.BachelorProgrammes.Add(bachelorProgramme);
			}
			else
			{
				// Existing entity
				context.Entry(bachelorProgramme).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var bachelorProgramme = context.BachelorProgrammes.Find(id);
			context.BachelorProgrammes.Remove(bachelorProgramme);
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

	public interface IBachelorProgrammeRepository : IDisposable
	{
		IQueryable<BachelorProgramme> AllByBachelorProgrammeId(int bachelorProgrammeId);
		IQueryable<BachelorProgramme> AllByBachelorProgrammeIdIncluding(int bachelorProgrammeId, params Expression<Func<BachelorProgramme, object>>[] includeProperties);
		BachelorProgramme Find(int id);
		void InsertOrUpdate(BachelorProgramme bachelorProgramme);
		void Delete(int id);
		void Save();
	}
}