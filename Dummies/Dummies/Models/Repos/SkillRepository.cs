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
	public class SkillRepository : ISkillRepository
	{
		private readonly DummiesContext context = new DummiesContext();

		public IQueryable<Skill> AllBySkillId(int skillId)
		{
			return context.Skills.Where(c => c.SkillId == skillId);
		}

		public IQueryable<Skill> AllBySkillIdIncluding(int skillId, params Expression<Func<Skill, object>>[] includeProperties)
		{
			IQueryable<Skill> query = context.Skills.Where(c => c.SkillId == skillId);
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Skill Find(int id)
		{
			return context.Skills.Find(id);
		}

		public void InsertOrUpdate(Skill skill)
		{
			if (skill.SkillId == default(int))
			{
				// New entity
				context.Skills.Add(skill);
			}
			else
			{
				// Existing entity
				context.Entry(skill).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var skill = context.Skills.Find(id);
			context.Skills.Remove(skill);
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

	public interface ISkillRepository : IDisposable
	{
		IQueryable<Skill> AllBySkillId(int skillId);
		IQueryable<Skill> AllBySkillIdIncluding(int skillId, params Expression<Func<Skill, object>>[] includeProperties);
		Skill Find(int id);
		void InsertOrUpdate(Skill category);
		void Delete(int id);
		void Save();
	}
}