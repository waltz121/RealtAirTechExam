using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RealtAirTechExam.WebApi.Controllers
{
    public class UserTaskController : ApiController
    {
        public readonly RealAirTechExamContext context;

        public UserTaskController()
        {
            context = new RealAirTechExamContext();
        }

        [HttpGet]
        public List<UserTask> GetAllUserTasksViaUserId(string UserId)
        {
            var user = context.Users.Where(x => x.AspNetUser.Contains(UserId)).FirstOrDefault();

            return user.UserTasks.ToList();
        }

        [HttpPost]
        public HttpResponseMessage AddUserTask(UserTask userTask)
        {
            try
            {
                context.UserTasks.Add(userTask);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, userTask.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage DeleteUserTask(int id)
        {
            try
            {
                var UserTask = context.UserTasks.Where(x => x.Id == id).FirstOrDefault();
                context.Delete(UserTask);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage UserTaskMarkAsDone(UserTask userTask)
        {
            try
            {
                userTask.IsDone = true;
                context.Update(userTask);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, userTask.Id);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateUserTask(UserTask userTask)
        {
            try
            {
                context.Update(userTask);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, userTask.Id);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage BatchUpdateUserTasks(List<UserTask> userTasks)
        {
            try
            {
                foreach (var i in userTasks)
                {
                    context.Update(i);
                }

                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Success!");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

           
        }
    }
}
