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
	public class PersonalOfferRepository : IPersonalOfferRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<PersonalOffer> AllByPersonalOfferId(int personalOfferId)
		{
			return context.PersonalOffers.Where(c => c.PersonalOfferId == personalOfferId);
		}

		public IQueryable<PersonalOffer> AllByPersonalOfferIdIncluding(int personalOfferId, params Expression<Func<PersonalOffer, object>>[] includeProperties)
		{
			IQueryable<PersonalOffer> query = context.PersonalOffers.Where(c => c.PersonalOfferId == personalOfferId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public PersonalOffer Find(int id)
		{
			return context.PersonalOffers.Find(id);
		}

		public void InsertOrUpdate(PersonalOffer personalOffer)
		{
			if (personalOffer.PersonalOfferId == default(int))
			{
				// New entity
				context.PersonalOffers.Add(personalOffer);
			}
			else
			{
				// Existing entity
				context.Entry(personalOffer).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var personalOffer = context.PersonalOffers.Find(id);
			context.PersonalOffers.Remove(personalOffer);
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

	public interface IPersonalOfferRepository : IDisposable
	{
		IQueryable<PersonalOffer> AllByPersonalOfferId(int personalOfferId);
		IQueryable<PersonalOffer> AllByPersonalOfferIdIncluding(int personalOfferId, params Expression<Func<PersonalOffer, object>>[] includeProperties);
		PersonalOffer Find(int id);
		void InsertOrUpdate(PersonalOffer personalOfferId);
		void Delete(int id);
		void Save();
	}
}