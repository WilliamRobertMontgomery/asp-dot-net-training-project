using System;
using System.Web.Security;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using WebProject.DataAccess.Entities;
using NHibernate;
using WebProject.Core;

namespace WebProject.Providers
{
	public class NHibernateMembershipProvider : MembershipProvider
	{
		#region Private

		private string _ApplicationName;
		private bool _EnablePasswordReset;
		private bool _EnablePasswordRetrieval = false;
		private bool _RequiresQuestionAndAnswer = false;
		private bool _RequiresUniqueEmail = true;
		private int _MaxInvalidPasswordAttempts;
		private int _PasswordAttemptWindow;
		private int _MinRequiredPasswordLength;
		private int _MinRequiredNonalphanumericCharacters;
		private string _PasswordStrengthRegularExpression;
		private MembershipPasswordFormat _PasswordFormat = MembershipPasswordFormat.Hashed;
		private static ISessionFactory _sessionFactory;
		private static ISession _session;

		#endregion

		#region Public Propeties

		public override string ApplicationName
		{
			get
			{
				return _ApplicationName;
			}
			set
			{
				_ApplicationName = value;
			}
		}

		public override bool EnablePasswordReset
		{
			get { return _EnablePasswordReset; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return _EnablePasswordRetrieval; }
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return _MaxInvalidPasswordAttempts; }
		}

		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return _MinRequiredNonalphanumericCharacters; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return _MinRequiredPasswordLength; }
		}

		public override int PasswordAttemptWindow
		{
			get { return _PasswordAttemptWindow; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return _PasswordFormat; }
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return _PasswordStrengthRegularExpression; }
		}

		public override bool RequiresQuestionAndAnswer
		{
			get { return _RequiresQuestionAndAnswer; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return _RequiresUniqueEmail; }
		}

		private static ISessionFactory SessionFactory
		{
			get { return _sessionFactory; }
		}

		#endregion

		#region Helper functions

		private string GetConfigValue(string configValue, string defaultValue)
		{
			if (String.IsNullOrEmpty(configValue))
				return defaultValue;

			return configValue;
		}

		private MembershipUser GetMembershipUserFromUser(User user)
		{
			MembershipUser membershipUser = new MembershipUser(typeof(WebProject.Providers.NHibernateMembershipProvider).Name,
												  user.UserName,
												  user.Id,
												  user.Email,
												  null,
												  null,
												  user.IsActivated,
												  user.IsLockedOut,
												  user.CreationDate,
												  DateTime.MinValue,
												  user.LastActivityDate,
												  DateTime.MinValue,
												  DateTime.MinValue);

			return membershipUser;
		}

		private bool CheckPassword(string password, string dbpassword)
		{
			string s = password.GetMD5Hash();
			if (s == dbpassword)
			{
				return true;
			}

			return false;
		}

		#endregion

		#region Private methods

		private IEnumerable<User> GetUsers()
		{
			IList<User> users = null;
			using (ISession session = SessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					users = session.CreateCriteria(typeof(User))
									.List<User>();
				}
			}
			return users;
		}

		private IList<User> GetUsersLikeUsername(string usernameToMatch)
		{
			IList<User> users = null;
			using (ISession session = SessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					users = session.CreateCriteria(typeof(User))
								.Add(NHibernate.Criterion.Restrictions.Like("Username", usernameToMatch))
								.List<User>();
				}
			}
			return users;

		}

		private IList<User> GetUsersLikeEmail(string emailToMatch)
		{
			IList<User> users = null;
			using (ISession session = SessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					users = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Like("Email", emailToMatch))
									.List<User>();
				}
			}
			return users;
		}

		#endregion

		#region Public methods

		public override void Initialize(string name, NameValueCollection config)
		{
			if (config == null)
			{
				throw new ArgumentNullException("config");
			}

			if (name == null || name.Length == 0)
			{
				name = "NHibernateMambershipProvider";
			}

			base.Initialize(name, config);

			_ApplicationName = GetConfigValue(config["applicationName"],

			System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

			_MaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));

			_PasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));

			_MinRequiredNonalphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredNonalphanumericCharacters"], "1"));

			_MinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "6"));

			_EnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));

			_PasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));

			_sessionFactory = SessionHelper.SessionFactory;

			_session = _sessionFactory.OpenSession();
		}

		public override bool ValidateUser(string userName, string password)
		{
			bool isValid = false;
			User user = null;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					user = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
									.UniqueResult<User>();

					if (user == null)
						return false;
					if (user.IsLockedOut)
						return false;

					if (CheckPassword(password, user.Password))
					{
						if (user.IsActivated)
						{
							isValid = true;
							user.LastActivityDate = DateTime.Now;
							user.IsOnLine = true;
							session.Update(user);
							transaction.Commit();
						}
					}
					else
					{
						isValid = false;
					}
				}
			}
			return isValid;
		}

		public override string GetUserNameByEmail(string emailAddress)
		{
			User user = null;
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					user = session.CreateCriteria(typeof(User))
										.Add(NHibernate.Criterion.Restrictions.Eq("Email", emailAddress))
										.UniqueResult<User>();
				}
			}
			if (user == null)
				return string.Empty;
			else
				return user.UserName;
		}

		public override MembershipUser GetUser(string userName, bool userIsOnline)
		{
			User user = null;
			MembershipUser membershipUser = null;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
									.UniqueResult<User>();

					if (user != null)
					{
						membershipUser = GetMembershipUserFromUser(user);
					}
				}
			}
			return membershipUser;
		}

		public override MembershipUser CreateUser(string userName, string password, string emailAddress, string passwordQuestion, string passwordAnswer, bool IsActivated, object providerUserKey, out MembershipCreateStatus status)
		{
			User user = null;
			Profile profile = null;

			ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(userName, password, true);

			OnValidatingPassword(args);
			if (args.Cancel)
			{
				status = MembershipCreateStatus.InvalidPassword;
				return null;
			}

			if (RequiresUniqueEmail && !string.IsNullOrEmpty(GetUserNameByEmail(emailAddress)))
			{
				status = MembershipCreateStatus.DuplicateEmail;
				return null;
			}

			MembershipUser membershipUser = GetUser(userName, false);

			if (membershipUser == null)
			{
				using (ISession session = _sessionFactory.OpenSession())
				{
					using (ITransaction transaction = session.BeginTransaction())
					{
						user = new User();
						user.UserName = userName;
						user.Password = password.GetMD5Hash();
						user.Email = emailAddress;
						user.IsActivated = true;
						user.IsLockedOut = false;
						user.CreationDate = DateTime.Now;
						user.LastActivityDate = DateTime.Now;

						session.Save(user);
						transaction.Commit();
					}
					using (ITransaction transaction = session.BeginTransaction())
					{
						profile = new Profile() { Id_User = user.Id };
						session.Save(profile);
						transaction.Commit();
					}
				}

				status = MembershipCreateStatus.Success;
				return GetUser(userName, false);
			}
			else
			{
				status = MembershipCreateStatus.DuplicateUserName;
			}
			return null;
		}

		public override bool ChangePassword(string userName, string oldPassword, string newPassword)
		{
			if (!ValidateUser(userName, oldPassword))
				return false;

			ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(userName, newPassword, true);

			OnValidatingPassword(args);

			if (args.Cancel)
				if (args.FailureInformation != null)
					throw args.FailureInformation;
				else
					throw new MembershipPasswordException("Change password canceled due to new password validation failure.");

			int rowsAffected = 0;
			User user = null;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = GetUserByUsername(userName);

					if (user != null)
					{
						user.Password = newPassword;
						session.Update(user);
						transaction.Commit();
						rowsAffected = 1;
					}
				}
			}

			if (rowsAffected > 0)
				return true;
			return false;
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			MembershipUserCollection users = new MembershipUserCollection();
			totalRecords = 0;
			IEnumerable<User> allUsers = null;
			int counter = 0;
			int startIndex = pageSize * pageIndex;
			int endIndex = startIndex + pageSize - 1;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					totalRecords = (Int32)session.CreateCriteria(typeof(User))
								.SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();

					if (totalRecords <= 0) { return users; }

					allUsers = session.CreateCriteria(typeof(User)).List<User>();
					foreach (User user in allUsers)
					{
						if (counter >= endIndex)
							break;
						if (counter >= startIndex)
						{
							MembershipUser mu = GetMembershipUserFromUser(user);
							users.Add(mu);
						}
						counter++;
					}

				}
				return users;
			}
		}

		public override bool DeleteUser(string userName, bool deleteAllRelatedData)
		{
			int rowsAffected = 0;
			User user = null;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = GetUserByUsername(userName);
					var profiles = (List<Profile>)(session.CreateCriteria(typeof(Profile)).List<Profile>());
					if (user != null)
					{
						session.Delete(user);
						transaction.Commit();
						rowsAffected = 1;
					}
				}
			}

			if (rowsAffected > 0)
				return true;
			return false;
		}

		public override bool UnlockUser(string userName)
		{
			User user = null;
			bool unlocked = false;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = GetUserByUsername(userName);

					if (user != null)
					{
						user.IsLockedOut = false;
						session.Update(user);
						transaction.Commit();
						unlocked = true;
					}
				}
			}
			return unlocked;
		}

		public override void UpdateUser(MembershipUser membershipUser)
		{
			User user = null;
			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = GetUserByUsername(membershipUser.UserName);
					if (user != null)
					{
						user.Email = membershipUser.Email;
						user.IsActivated = membershipUser.IsApproved;
						user.IsOnLine = membershipUser.IsOnline;
						session.Update(user);
						transaction.Commit();
					}
				}
			}
		}

		public override int GetNumberOfUsersOnline()
		{
			TimeSpan onlineSpan = new TimeSpan(0, System.Web.Security.Membership.UserIsOnlineTimeWindow, 0);
			DateTime compareTime = DateTime.Now.Subtract(onlineSpan);
			int numOnline = 0;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{

					numOnline = (Int32)session.CreateCriteria(typeof(User))
									   .Add(NHibernate.Criterion.Restrictions.Gt("IsOnline", compareTime))
									   .SetProjection(NHibernate.Criterion.Projections.Count("Id")).UniqueResult();
				}
			}
			return numOnline;
		}

		public bool LockUser(string userName)
		{
			User user = null;
			bool locked = false;

			using (ISession session = _sessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = GetUserByUsername(userName);

					if (user != null)
					{
						user.IsLockedOut = true;
						session.Update(user);
						transaction.Commit();
						locked = true;
					}
				}
			}
			return locked;
		}

		private User GetUserByUsername(string username)
		{
			User user = null;
			using (ISession session = SessionFactory.OpenSession())
			{
				using (ITransaction transaction = session.BeginTransaction())
				{
					user = session.CreateCriteria(typeof(User))
									.Add(NHibernate.Criterion.Restrictions.Eq("UserName", username))
									.UniqueResult<User>();
				}
			}
			return user;
		}

		#endregion

		#region NotImplementedException

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw new NotImplementedException();

		}

		public override string GetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override string ResetPassword(string username, string answer)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			return false;
		}

		#endregion
	}
}