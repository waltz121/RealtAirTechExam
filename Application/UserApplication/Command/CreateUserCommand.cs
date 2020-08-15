using Application.Commons;
using Application.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApplication.Command
{
    public class CreateUserCommand : ICommand<UserDTO>
    {
        private readonly RealAirTechExamContext context;
        public CreateUserCommand()
        {
            context = new RealAirTechExamContext();
        }

        public void ExecuteCommand(UserDTO obj)
        {
            User user = new User()
            {
                AspNetUser = obj.AspNetUserId,
                FirstName = obj.FirstName,
                Id = obj.Id,
                LastName = obj.LastName,
                MiddleName = ""
            };

            context.Users.Add(user);
            context.Save();
        }
    }
}
