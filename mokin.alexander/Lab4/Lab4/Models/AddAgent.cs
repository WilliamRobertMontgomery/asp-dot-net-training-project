using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class AddAgent
    {        
        [Display(Name = "Введите имя агента")]
        [RegularExpression(@"[^</>]*", ErrorMessage = "Вы используете запрещенные символы")]
        [StringLength(20, ErrorMessage = "Слишком длинное", MinimumLength = 1)]
        [Required(ErrorMessage = "Обязательное поле")]
        public string agentName { get; set; }
    }
}