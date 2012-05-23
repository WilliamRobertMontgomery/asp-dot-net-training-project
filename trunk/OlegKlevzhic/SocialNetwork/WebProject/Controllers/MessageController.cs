using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using WebProject.Models;
using WebProject.Core;
using WebProject.DataAccess.Entities;

namespace WebProject.Controllers
{
	[Authorize]
	public class MessageController : Controller
	{
		private ISession _session;

		public MessageController(ISession session)
		{
			_session = session;
		}

		public ActionResult ReceivedMessages()
		{
			DataManager _dataManager = new DataManager(_session);
			IEnumerable<Message> messages = _dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name).GetMessages;
			List<MessageModel> messageModels = new List<MessageModel>();
			if (messages != null)
			{
				foreach (var message in messages)
				{
					messageModels.Add(new MessageModel()
					{
						Autor = message.NameGetUser,
						DateTime = message.Date,
						Id = message.Id,
						Text = message.Text
					});
				}
				ViewData["Messages"] = messageModels;
			}
			else
			{
				ViewData["Messages"] = new List<MessageModel>();
			}
			return View();
		}

		public ActionResult TheMessages()
		{
			DataManager _dataManager = new DataManager(_session);
			IEnumerable<Message> messages = _dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name).SendMessages;
			List<MessageModel> messageModels = new List<MessageModel>();
			if (messages != null)
			{
				foreach (var message in messages)
				{
					messageModels.Add(new MessageModel()
					{
						Autor = message.NameGetUser,
						DateTime = message.Date,
						Id = message.Id,
						Text = message.Text
					});
				}
				ViewData["Messages"] = messageModels;
			}
			else
			{
				ViewData["Messages"] = new List<MessageModel>();
			}
			return View();
		}

		public ActionResult Create(Guid? id = null)
		{
			DataManager _dataManager = new DataManager(_session);
			List<SelectListItem> items = new List<SelectListItem>();
			if (id == null)
			{
				var friends = _dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name).Friends;
				foreach (var friend in friends)
				{
					items.Add(new SelectListItem() { Text = _dataManager.ProfileRepository.GetFullName(friend) });
				}
				ViewData["Friends"] = items;
			}
			else
			{
				var friend = _dataManager.ProfileRepository.Get((Guid)id);
				items.Add(new SelectListItem() { Text = _dataManager.ProfileRepository.GetFullName(friend) });
				ViewData["Friends"] = items;
			}

			return View();
		}

		[HttpPost]
		public ActionResult Create(CreateMessageModel message)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				DataManager dataManager = new DataManager(_session);
				Profile sendProfile = dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name);
				Profile getProfile = dataManager.ProfileRepository.GetProfileByFullName(message.Friend);
				sendProfile.SendMessage(getProfile, message.Text);
				_session.Save(sendProfile);
				_session.Save(getProfile);
				transaction.Commit();
			}
			return RedirectToAction("TheMessages");
		}

		public ActionResult Delete(Guid id)
		{
			using (ITransaction transaction = _session.BeginTransaction())
			{
				DataManager dataManager = new DataManager(_session);
				Message message = dataManager.MessageRepository.Get(id);
				Profile profile = dataManager.ProfileRepository.GetProfileByUserName(User.Identity.Name);
				profile.RemoveMessage(message);
				_session.Save(profile);
				transaction.Commit();
			}
			return RedirectToAction("ReceivedMessages");
		}

		public ActionResult Details(Guid id)
		{
			DataManager dataManager = new DataManager(_session);
			var message = dataManager.MessageRepository.Get(id);
			ViewData["TitleMessage"] = "Autor: " + message.NameSendUser + "; Addressee: " + message.NameGetUser + "; Date: " + message.Date.ToString("dd:MM:yyyy:HH:mm");
			MessageModel messageModel = new MessageModel()
			{
				Id = message.Id,
				Text = message.Text
			};
			return View(messageModel);
		}
	}
}
