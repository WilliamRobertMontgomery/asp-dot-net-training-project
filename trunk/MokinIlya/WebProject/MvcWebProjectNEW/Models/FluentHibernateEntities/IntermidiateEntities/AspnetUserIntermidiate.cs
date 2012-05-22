using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebProjectNEW.Models.VesenniDataAccess;
using System.ComponentModel.DataAnnotations;

namespace MvcWebProjectNEW.Models
{
    public class AspnetUserIntermidiate
    {
        [Display(Name = "Id")]
        public virtual System.Guid UserId { get; set; }
        [Display(Name = "Логин")]
        public virtual string UserName { get; set; }
        [Display(Name = "LoweredUserName")]
        public virtual string LoweredUserName { get; set; }
        [Display(Name = "MobileAlias")]
        public virtual string MobileAlias { get; set; }
        [Display(Name = "IsAnonymous")]
        public virtual bool IsAnonymous { get; set; }
        [Display(Name = "LastActivityDate")]
        public virtual System.DateTime LastActivityDate { get; set; }

        [Display(Name = "Адрес")]
        public virtual string Address { get; set; }
        [Display(Name = "Название компании")]
        public virtual string CompaniName { get; set; }
        [Display(Name = "Почтовый индекс")]
        public virtual string ZipCode { get; set; }
        [Display(Name = "Телефон 1")]
        public virtual string Telephone1 { get; set; }
        [Display(Name = "Телефон 2")]
        public virtual string Telephone2 { get; set; }
        [Display(Name = "Полное имя")]
        public virtual string FullName { get; set; }
        [Display(Name = "Дополнительно")]
        public virtual string OtherInformation { get; set; }

        public AspnetUser ConvertToFinalClass(IRepository _repository)
        {
            AspnetUser result = new AspnetUser();
            result.UserId = UserId;
            result.VesenniCatalogArticles = _repository.GetAll<VesenniCatalogArticle>();
            result.VesenniMaterials = _repository.GetAll<VesenniMaterial>();
            result.VesenniLetters = _repository.GetAll<VesenniLetter>();
            result.UserName = UserName;
            result.LoweredUserName = LoweredUserName;
            result.MobileAlias = MobileAlias;
            result.IsAnonymous = IsAnonymous;
            result.LastActivityDate = LastActivityDate;

            result.Address = Address;
            result.CompaniName = CompaniName;
            result.ZipCode = ZipCode;
            result.Telephone1 = Telephone1;
            result.Telephone2 = Telephone2;
            result.FullName = FullName;
            result.OtherInformation = OtherInformation;

            return result;
        }

    }
}