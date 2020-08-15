using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealtAirTechExam.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public readonly RealAirTechExamContext context;

        public UserController()
        {
            context = new RealAirTechExamContext();
        }

        [HttpPost]
        public HttpResponseMessage CreateUser(User user)
        {
            try
            {
                context.Users.Add(user);
                context.Save();
                return Request.CreateResponse(HttpStatusCode.OK, user.Id);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }        
        }

        [HttpGet]
        public User GetUserViaAspNetId(string UserId)
        {
            var user = context.Users.Where(x => x.AspNetUser.Contains(UserId)).FirstOrDefault();
            return user;
        }
    }
}
