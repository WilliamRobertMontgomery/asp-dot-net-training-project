using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Principal;

namespace Lab4.Library.Test.Controllers
{
	public class MockHttpContext : HttpContextBase
	{
		private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

		public override IPrincipal User
		{
			get
			{
				return _user;
			}
			set
			{
				base.User = value;
			}
		}
	}
}
