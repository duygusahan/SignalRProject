using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DtoLayer.IdentityDtos
{
    public class UserEditDto
    {
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
    }
}
