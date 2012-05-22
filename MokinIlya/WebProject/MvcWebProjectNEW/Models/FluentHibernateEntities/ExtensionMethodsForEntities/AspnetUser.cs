using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebProjectNEW.Models
{
    public static class ExtensionClassForAspnetUser
    {
        public static AspnetUserIntermidiate ConvertToIntermidiateClass(this AspnetUser user)
        {
            AspnetUserIntermidiate result = new AspnetUserIntermidiate();
            result.UserId = user.UserId;
            result.UserName = user.UserName;
            result.LoweredUserName = user.LoweredUserName;
            result.MobileAlias = user.MobileAlias;
            result.IsAnonymous = user.IsAnonymous;
            result.LastActivityDate = user.LastActivityDate;

            result.Address = user.Address;
            result.CompaniName = user.CompaniName;
            result.ZipCode = user.ZipCode;
            result.Telephone1 = user.Telephone1;
            result.Telephone2 = user.Telephone2;
            result.FullName = user.FullName;
            result.OtherInformation = user.OtherInformation;

            return result;
        }
    }
}