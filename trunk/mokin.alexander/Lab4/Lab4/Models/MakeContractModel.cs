using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class MakeContractModel
    {
        [Display(Name = "Введите имя клиента")]
        [RegularExpression(@"[^</>]*", ErrorMessage = "Вы используете запрещенные символы")]
        [StringLength(20, ErrorMessage = "Слишком длинное", MinimumLength = 1)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string clientName { get; set; }

        public string builderName { get; set; }

        public string agentName { get; set; }

        [Display(Name = "Введите название проекта")]
        [RegularExpression(@"[^</>]*", ErrorMessage = "Вы используете запрещенные символы")]
        [StringLength(20, ErrorMessage = "Слишком длинное", MinimumLength = 1)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string projectName { get; set; }

        [Display(Name = "Введите описание проекта")]
        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"[^</>]*", ErrorMessage = "Вы используете запрещенные символы")]
        [StringLength(300, ErrorMessage = "Слишком длинное", MinimumLength = 1)]
        public string projectDescription { get; set; }
    }
}