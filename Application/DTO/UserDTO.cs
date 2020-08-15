using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string AspNetUser { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
