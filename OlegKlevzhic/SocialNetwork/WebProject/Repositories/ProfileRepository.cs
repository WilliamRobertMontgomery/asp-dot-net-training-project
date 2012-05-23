using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using WebProject.Models;
using WebProject.DataAccess.Entities;
using WebProject.DataAccess.Repositories;

namespace WebProject.Repositories
{
	public class ProfileRepository : Repository<Profile>
	{
		private IRepository<Profile> _profileRepository;
		private ISession _session;

		public ProfileRepository(ISession session)
			: base(session)
		{
			_session = session;
			_profileRepository = new Repository<Profile>(session);
		}

		public IEnumerable<Profile> GetProfilesBySearchModel(SearchModel model)
		{
			IEnumerable<Profile> profiles = GetAll();

			if (model.Age != 0)
			{
				profiles = profiles.Where(x => DateTime.Now.Year - x.BirthDate.Year == model.Age);
			}
			if (model.City != null && model.City != String.Empty)
			{
				profiles = profiles.Where(x => String.Equals(x.City, model.City, StringComparison.InvariantCultureIgnoreCase));
			}
			if (model.Country != null && model.Country != String.Empty)
			{
				profiles = profiles.Where(x => String.Equals(x.Country, model.Country, StringComparison.InvariantCultureIgnoreCase));
			}
			if (model.FirstName != null && model.FirstName != String.Empty)
			{
				profiles = profiles.Where(x => String.Equals(x.FirstName, model.FirstName, StringComparison.InvariantCultureIgnoreCase));
			}
			if (model.LastName != null && model.LastName != String.Empty)
			{
				profiles = profiles.Where(x => String.Equals(x.LastName, model.LastName, StringComparison.InvariantCultureIgnoreCase));
			}
			profiles = profiles.Where(x => String.Equals(x.Gender, model.Gender, StringComparison.InvariantCultureIgnoreCase));
			return profiles;
		}

		public Profile GetProfileByUser(User user)
		{
			/*using (ISession session = _sessionFactory.OpenSession())
			{
				return session.CreateCriteria(typeof(Profile)).Add(NHibernate.Criterion.Restrictions.Eq("Id_User", user.Id)).UniqueResult<Profile>();
			 }*/
			return _profileRepository.GetAll().SingleOrDefault(x => x.Id_User == user.Id);

		}

		public string GetFullName(Profile profile)
		{
			return String.Format("{0} {1}", profile.FirstName, profile.LastName);
		}

		public Profile GetProfileByFullName(string fullName)
		{
			string[] name = fullName.Split(' ');
			return _session.CreateCriteria<Profile>()
				.Add(NHibernate.Criterion.Restrictions.Eq("FirstName", name[0]))
				.Add(NHibernate.Criterion.Restrictions.Eq("LastName", name[1]))
				.UniqueResult<Profile>();
		}

		public Profile GetProfileByUserName(string userName)
		{
			User user = _session.CreateCriteria<User>()
				.Add(NHibernate.Criterion.Restrictions.Eq("UserName", userName))
				.UniqueResult<User>();

			return _session.CreateCriteria<Profile>()
				.Add(NHibernate.Criterion.Restrictions.Eq("Id_User", user.Id))
				.UniqueResult<Profile>();
		}
	}
}