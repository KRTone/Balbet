using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Balbet.WEB.Models
{
    public class PassportViewModel
    {
        public PassportViewModel() { }
        public PassportViewModel(string fullPassport)
        {
            this.Seria = string.Join(null, fullPassport.Take(4).ToArray());
            this.Code = string.Join(null, fullPassport.Skip(4).ToArray());
        }
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Only numbers 4 of seria + 6 numbers of code")]
        public string Seria { get; set; }
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Only numbers 4 of seria + 6 numbers of code")]
        public string Code { get; set; }
    }
}