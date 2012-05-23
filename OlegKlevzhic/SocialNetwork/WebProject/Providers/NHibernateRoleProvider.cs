using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Text;
using WebProject.Core;
using WebProject.DataAccess.Entities;
using NHibernate;

namespace WebProject.Providers
{
	public class NHibernateRoleProvider : RoleProvider
	{
		#region private

		private string connectionString;
		private static ISessionFactory _sessionFactory;

		#endregion

		#region Properties
		/// <summary>Gets the session factory.</summary>
		private static ISessionFactory SessionFactory
		{
			get { return _sessionFactory; }
		}

		#endregion

		#region Helper methods

		private string GetConfigValue(string configValue, string defaultValue)
		{
			if (String.IsNullOrEmpty(configValue))
				return defaultValue;

			return configValue;
		}

		private Role GetRole(string roleName)
		{
			Role role = null;
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					role = session.CreateCriteria(typeof(Role))
						.Add(NHibernate.Criterion.Restrictions.Eq("RoleName", roleName))
						.UniqueResult<Role>();

					IList<User> users = role.UsersInRole;
				}
			}
			return role;
		}

		#endregion

		#region Public Methods

		public override void Initialize(string name, NameValueCollection config)
		{

			if (config == null)
				throw new ArgumentNullException("config");

			if (name == null || name.Length == 0)
				name = "FNHRoleProvider";

			if (String.IsNullOrEmpty(config["description"]))
			{
				config.Remove("description");
				config.Add("description", "Sample Fluent Nhibernate Role provider");
			}

			base.Initialize(name, config);

			connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SocialNetwork"].ConnectionString;

			_sessionFactory = SessionHelper.SessionFactory;
		}

		public override void AddUsersToRoles(string[] userNames, string[] roleNames)
		{
			foreach (string roleName in roleNames)
			{
				if (!RoleExists(roleName))
					throw new ProviderException(String.Format("Роль '{0}' не найдена.", roleName));
			}

			foreach (string userName in userNames)
			{
				if (userName.Contains(","))
					throw new ArgumentException(String.Format("Пользователь '{0}'не найден.", userName));
				//is user not exiting //throw exception

				foreach (string rolename in roleNames)
				{
					if (IsUserInRole(userName, rolename))
						throw new ProviderException(String.Format("Пользователь '{0}' уже в роли '{1}'.", userName, rolename));
				}
			}

			User user = null;
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					foreach (string username in userNames)
					{
						foreach (string rolename in roleNames)
						{
							user = session.CreateCriteria(typeof(User))
										.Add(NHibernate.Criterion.Restrictions.Eq("UserName", username))
										.UniqueResult<User>();

							if (user != null)
							{
								Role role = session.CreateCriteria(typeof(Role))
										.Add(NHibernate.Criterion.Restrictions.Eq("RoleName", rolename))
										.UniqueResult<Role>();

								user.AddRole(role);
							}
						}
						session.SaveOrUpdate(user);
					}
					transaction.Commit();
				}
			}
		}

		public override void CreateRole(string roleName)
		{
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Role role = new Role();
					role.RoleName = roleName;
					session.Save(role);
					transaction.Commit();
				}
			}
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			if (!RoleExists(roleName))
				throw new ProviderException("Роль не найдена.");

			if (throwOnPopulatedRole && GetUsersInRole(roleName).Length > 0)
				throw new ProviderException("Невозможно удалить роль принадлежащую некоторым пользователям.");

			bool deleted = false;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Role role = GetRole(roleName);
					session.Delete(role);
					transaction.Commit();
					deleted = true;
				}
			}

			return deleted;
		}

		public override string[] GetAllRoles()
		{
			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					IList<Role> allRoles = session.CreateCriteria(typeof(Role))
									.List<Role>();

					foreach (Role role in allRoles)
					{
						sb.Append(role.RoleName + ",");
					}
				}
			}

			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
				return sb.ToString().Split(',');
			}

			return new string[0];
		}

		public override string[] GetRolesForUser(string userName)
		{
			User user = null;
			IList<Role> userRoles = null;
			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
									.UniqueResult<User>();

					if (user != null)
					{
						userRoles = user.Roles;
						foreach (Role r in userRoles)
						{
							sb.Append(r.RoleName + ",");
						}
					}
				}
			}

			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
				return sb.ToString().Split(',');
			}
			return new string[0];
		}

		public override string[] GetUsersInRole(string roleName)
		{
			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					Role role = session.CreateCriteria(typeof(Role))
									.Add(NHibernate.Criterion.Restrictions.Eq("RoleName", roleName))
									.UniqueResult<Role>();

					IList<User> users = role.UsersInRole;

					foreach (User user in users)
					{
						sb.Append(user.UserName + ",");
					}
				}
			}

			if (sb.Length > 0)
			{

				sb.Remove(sb.Length - 1, 1);
				return sb.ToString().Split(',');
			}

			return new string[0];
		}

		public override bool IsUserInRole(string userName, string roleName)
		{
			bool userIsInRole = false;
			User user = null;
			IList<Role> userRoles = null;
			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
									.UniqueResult<User>();

					if (user != null)
					{
						userRoles = user.Roles;
						foreach (Role role in userRoles)
						{
							if (role.RoleName.Equals(roleName))
							{
								userIsInRole = true;
								break;
							}
						}
					}
				}
			}
			return userIsInRole;
		}

		public override void RemoveUsersFromRoles(string[] userNames, string[] roleNames)
		{
			foreach (string roleName in roleNames)
			{
				if (!RoleExists(roleName))
					throw new ProviderException(String.Format("Role name {0} not found.", roleName));
			}

			foreach (string userName in userNames)
			{
				foreach (string roleName in roleNames)
				{
					if (!IsUserInRole(userName, roleName))
						throw new ProviderException(String.Format("User {0} is not in role {1}.", userName, roleName));
				}
			}

			User user = null;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					foreach (string userName in userNames)
					{
						user = session.CreateCriteria(typeof(User))
							.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
							.UniqueResult<User>();

						var rolesToDelete = new List<Role>();
						foreach (string roleName in roleNames)
						{
							IList<Role> roles = user.Roles;
							foreach (Role role in roles)
							{
								if (role.RoleName.Equals(roleName))
									rolesToDelete.Add(role);

							}
						}
						foreach (Role roleToDelete in rolesToDelete)
							user.RemoveRole(roleToDelete);

						session.SaveOrUpdate(user);
					}
					transaction.Commit();
				}
			}
		}

		public override bool RoleExists(string roleName)
		{
			bool exists = false;

			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					Role role = session.CreateCriteria(typeof(Role))
										.Add(NHibernate.Criterion.Restrictions.Eq("RoleName", roleName))
										.UniqueResult<Role>();
					if (role != null)
						exists = true;
				}
			}
			return exists;
		}

		public override string[] FindUsersInRole(string roleName, string userNameToMatch)
		{
			StringBuilder sb = new StringBuilder();
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					Role role = session.CreateCriteria(typeof(Role))
									.Add(NHibernate.Criterion.Restrictions.Eq("RoleName", "NHibernateRoleProvider"))
									.UniqueResult<Role>();

					IList<User> users = role.UsersInRole;
					if (users != null)
					{
						foreach (User user in users)
						{
							if (String.Compare(user.UserName, userNameToMatch, true) == 0)
								sb.Append(user.UserName + ",");
						}
					}
				}
				if (sb.Length > 0)
				{
					sb.Remove(sb.Length - 1, 1);
					return sb.ToString().Split(',');
				}
				return new string[0];
			}
		}

		#endregion

		public override string ApplicationName
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
