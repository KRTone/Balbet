using Balbet.WEB.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Balbet.WEB.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Please, enter login"), 
            MinLength(1, ErrorMessage ="MinLength = 1"), 
            MaxLength(8, ErrorMessage ="MaxLength = 8"), 
            RegularExpression(@"^[a-zA-Z][a-zA-Z0-9]{1,8}$", ErrorMessage = "Have to start with letter and can contain only chars and digits")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Please, enter password"),
            MinLength(1, ErrorMessage = "MinLength = 1"),
            MaxLength(8, ErrorMessage = "MaxLength = 8"),
            RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[\d]).{1,8}$", ErrorMessage = "Can contain only chars/digits and have to contain one or more digits")]
        public string Password { get; set; }
        [RegularExpression("^[а-яА-Я]{0,30}$", ErrorMessage ="Only russian chars (0-30)")]
        public string FirstName { get; set; }
        [RegularExpression("^[а-яА-Я]{0,30}$", ErrorMessage = "Only russian chars (0-30)")]
        public string LastName { get; set; }
        [RegularExpression("^[МЖ]{1}$", ErrorMessage = "Only russian chars \"М or Ж\"")]
        public string Sex { get; set; }
        public PassportViewModel Passport { get;set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [BirthDay(18)]
        public DateTime Age { get; set; }
    }
}