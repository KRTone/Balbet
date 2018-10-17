using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balbet.DAL.ModelsDTO
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Passport { get; set; }
        public DateTime Age { get; set; }
    }
}
