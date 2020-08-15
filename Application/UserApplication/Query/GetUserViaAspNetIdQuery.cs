using Application.Commons;
using Application.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserApplication.Query
{
    public class GetUserViaAspNetIdQuery : IQuery<UserDTO>
    {
        private readonly RealAirTechExamContext context;
        string AspNetUserId;
        public GetUserViaAspNetIdQuery(string AspNetUserId)
        {
            context = new RealAirTechExamContext();
            this.AspNetUserId = AspNetUserId;
        }

        public UserDTO ExecuteQuery()
        {
            var user = context.Users.Where(x => x.AspNetUser.Contains(AspNetUserId))
                .Select(x => new UserDTO()
                {
                    AspNetUserId = x.AspNetUser,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName
                }).FirstOrDefault();

            return user;
        }
    }
}
