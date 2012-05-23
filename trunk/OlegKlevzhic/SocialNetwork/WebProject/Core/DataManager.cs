using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using NHibernate;
using WebProject.Repositories;
using WebProject.DataAccess.Repositories;
using WebProject.DataAccess.Entities;
using WebProject.Providers;

namespace WebProject.Core
{
	public class DataManager
	{
		private ISession _session;
		private NHibernateMembershipProvider _membershipRepository;
		private NHibernateRoleProvider _roleRepository;
		private UserRepository _userRepository;
		private ProfileRepository _profileRepository;
		private IRepository<Message> _messageRepository;


		public DataManager(ISession session)
		{
			_session = session;
		}

		public UserRepository UserRepository
		{
			get
			{
				if (_userRepository == null)
				{
					_userRepository = new UserRepository(_session);
				}
				return _userRepository;
			}
		}

		public ProfileRepository ProfileRepository
		{
			get
			{
				if (_profileRepository == null)
				{
					_profileRepository = new ProfileRepository(_session);
				}
				return _profileRepository;
			}
		}

		public NHibernateMembershipProvider MembershipRepository
		{
			get
			{
				if (_membershipRepository == null)
				{
					_membershipRepository = (Membership.Provider as NHibernateMembershipProvider);
				}
				return _membershipRepository;
			}
		}

		public NHibernateRoleProvider RoleRepository
		{
			get
			{
				if (_roleRepository == null)
				{
					_roleRepository = (Roles.Provider as NHibernateRoleProvider);
				}
				return _roleRepository;
			}
		}

		public IRepository<Message> MessageRepository
		{
			get
			{
				if (_messageRepository == null)
				{
					_messageRepository = new Repository<Message>(_session);
				}
				return _messageRepository;
			}
		}

	}
}