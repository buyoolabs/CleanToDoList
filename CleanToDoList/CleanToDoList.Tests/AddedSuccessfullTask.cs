using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanToDoLIst.Domain.UseCases;
using Newtonsoft.Json;
using CleanToDoLIst.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using CleanToDoLIst.Domain.Repositories;
using CleanToDoLIst.Data.Repositories;

namespace CleanToDoList.Tests
{
    [TestClass]
    public class AddedSuccessfullTask
    {
        string path = @"tasks.json";

        [TestMethod]
        public void GivenADescriptionAndValidDateWhenAddTaskThenTaskIsPersisted()
        {
            AddTaskRequest request = GivenADescriptionAndValidDate();
            WhenAddTask(request);
            ThenTaskIsPersisted(request);
        }



        private AddTaskRequest GivenADescriptionAndValidDate()
        {
            string description = "Mi primera tarea";
            DateTime date = DateTime.Now.AddDays(3);

            return new AddTaskRequest() { Description = description, DueDate = date };
        }

        private void WhenAddTask(AddTaskRequest request)
        {
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(path);
            AddTaskUseCase useCase = new AddTaskUseCase(toDoTaskRepository);
            useCase.Add(request);
        }

        private void ThenTaskIsPersisted(AddTaskRequest request)
        {
            string text = System.IO.File.ReadAllText(path);
            ToDoTask todoTask = JsonConvert.DeserializeObject<ToDoTask>(text);

            string insertedDescription = todoTask.Description;
            DateTime insertedDueDate = todoTask.DueDate;

            Assert.AreEqual(insertedDescription, request.Description);
            Assert.AreEqual(insertedDueDate, request.DueDate);

        }































        //[TestMethod]
        //public void AddTaskWithGoodArgumentShouldReturnOK()
        //{
        //    //Arrange
        //    IAddTaskUseCase addTaskUseCase = new AddTaskUseCase();

        //    //Act
        //    AddTaskResponse addTaskResponse = addTaskUseCase.Add(new AddTaskRequest()
        //    {
        //        Description = "Descripcion de test",
        //        DueDate = DateTime.MaxValue
        //    }
        //    );
        //    //Asset
        //    Assert.AreEqual("Task added succesfully", addTaskResponse.Result);
        //}

        //[TestMethod]
        //public void AddTask_WithEmptyDescription_ShouldReturnError()
        //{
        //    //Arrange
        //    IAddTaskUseCase addTaskUseCase = new AddTaskUseCase();

        //    //Act
        //    AddTaskResponse addTaskResponse = addTaskUseCase.Add(new AddTaskRequest()
        //    {
        //        Description = "",
        //        DueDate = DateTime.MaxValue
        //    }
        //    );
        //    //Asset
        //    Assert.AreEqual("Task not added: Description is required", addTaskResponse.Result);
        //}

    }
}
