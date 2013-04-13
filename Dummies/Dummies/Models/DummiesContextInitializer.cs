using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebMatrix.WebData;
using System.Web.Security;

namespace Dummies.Models
{
	public class DummiesContextInitializer : DropCreateDatabaseIfModelChanges<DummiesContext>
	{
		protected override void Seed(DummiesContext context)
		{
			base.Seed(context);
			SeedMembership();
		}

		private void SeedMembership()
		{
			WebSecurity.InitializeDatabaseConnection("DefaultConnection",
				"UserProfile", "UserId", "UserName", autoCreateTables: true);

			var roles = (SimpleRoleProvider)Roles.Provider;
			var membership = (SimpleMembershipProvider)Membership.Provider;

			if (!roles.RoleExists("Student"))
			{
				roles.CreateRole("Student");
			}
			if (!roles.RoleExists("Teacher"))
			{
				roles.CreateRole("Teacher");
			}
			if (!roles.RoleExists("Bussines"))
			{
				roles.CreateRole("Bussines");
			}
			//if (membership.GetUser("sallen", false) == null)
			//{
			//    membership.CreateUserAndAccount("sallen", "imalittleteapot");
			//}
			//if (!roles.GetRolesForUser("sallen").Contains("Admin"))
			//{
			//    roles.AddUsersToRoles(new[] { "sallen" }, new[] { "admin" });
			//}
		}
	}
}