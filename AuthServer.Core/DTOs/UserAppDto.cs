using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTOs
{
    public class UserAppDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }//identity user'daki verileri döneceğiz
        public string Email { get; set; }
        public string City { get; set; }
    }
}
