﻿using Application.Commons;
using Application.DTO;
using Application.UserApplication.Query;
using Application.UserTaskApplication.Command;
using Application.UserTaskApplication.Query;
using Microsoft.AspNet.Identity;
using RealtAirTechExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtAirTechExam.Controllers
{
    [Authorize]
    public class UserTaskController : Controller
    {
        private IQuery<List<UserTaskDTO>> getAllUserTasksViaUserIdQuery;
        private IQuery<UserDTO> getUserViaAspeNetIdQuery;
        private ICommand<UserTaskDTO> createUserTaskCommand;
        private ICommand<int> deleteUserTaskCommand;
        private ICommand<int> markAsDoneUserTaskCommand;
        private ICommand<UserTaskDTO> updateUserTaskCommand;

        public UserTaskController()
        {
            createUserTaskCommand = new CreateUserTaskCommand();
            deleteUserTaskCommand = new DeleteUserTaskCommand();
            markAsDoneUserTaskCommand = new MarkUserTaskAsDoneCommand();
            updateUserTaskCommand = new UpdateUserTaskCommand();
        }
        // GET: UserTask
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            getAllUserTasksViaUserIdQuery = new GetAllUserTasksViaUserIdQuery(UserId);
            
            UserTasksViewModel viewModel = new UserTasksViewModel();
            viewModel.userTaskDTOs = getAllUserTasksViaUserIdQuery.ExecuteQuery();

            return View(viewModel);
        }

        public ActionResult CreateUserTasks()
        {
            CreateUserTasksViewModel createUserTasksViewModel = new CreateUserTasksViewModel();
            return View(createUserTasksViewModel);
        }

        [HttpPost]
        public ActionResult CreateUserTasks(CreateUserTasksViewModel model)
        {
            var userId = User.Identity.GetUserId();
            getUserViaAspeNetIdQuery = new GetUserViaAspNetIdQuery(userId);
            var CurrentUser = getUserViaAspeNetIdQuery.ExecuteQuery();

            model.userTaskDTO.UserId = CurrentUser.Id;

            createUserTaskCommand.ExecuteCommand(model.userTaskDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteUserTask(int Id)
        {
            deleteUserTaskCommand.ExecuteCommand(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarkAsDone(int Id)
        {
            markAsDoneUserTaskCommand.ExecuteCommand(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(UserTaskDTO userTaskdto)
        {
            return View(userTaskdto);
        }

        [HttpPost]
        public ActionResult EditUserTasks(UserTaskDTO userTaskdto)
        {
            updateUserTaskCommand.ExecuteCommand(userTaskdto);
            return RedirectToAction("Index");
        }
    }
}