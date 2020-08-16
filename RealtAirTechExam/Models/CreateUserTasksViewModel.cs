using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtAirTechExam.Models
{
    public class CreateUserTasksViewModel
    {
        public CreateUserTasksViewModel()
        {
            userTaskDTO = new UserTaskDTO();
        }
        public UserTaskDTO userTaskDTO { get; set; }
    }
}