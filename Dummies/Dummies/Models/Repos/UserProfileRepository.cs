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
	public class UserProfileRepository : IUserProfileRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<UserProfile> AllByUserProfileId(int userProfileId)
		{
			return context.UserProfiles.Where(c => c.UserId == userProfileId);
		}

		public IQueryable<UserProfile> AllByUserProfileIdIncluding(int userProfileId, params Expression<Func<UserProfile, object>>[] includeProperties)
		{
			IQueryable<UserProfile> query = context.UserProfiles.Where(c => c.UserId == userProfileId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public UserProfile Find(int id)
		{
			return context.UserProfiles.Find(id);
		}

		public void InsertOrUpdate(UserProfile userProfile)
		{
			if (userProfile.UserId == default(int))
			{
				// New entity
				context.UserProfiles.Add(userProfile);
			}
			else
			{
				// Existing entity
				context.Entry(userProfile).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var userProfile = context.UserProfiles.Find(id);
			context.UserProfiles.Remove(userProfile);
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

	public interface IUserProfileRepository : IDisposable
	{
		IQueryable<UserProfile> AllByUserProfileId(int userProfileId);
		IQueryable<UserProfile> AllByUserProfileIdIncluding(int userProfileId, params Expression<Func<UserProfile, object>>[] includeProperties);
		UserProfile Find(int id);
		void InsertOrUpdate(UserProfile userProfile);
		void Delete(int id);
		void Save();
	}
}