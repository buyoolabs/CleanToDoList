using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanToDoLIst.Domain.UseCases;
using CleanToDoLIst.Domain.Repositories;
using CleanToDoLIst.Data.Repositories;
using CleanToDoLIst.Domain.Entities;
using Newtonsoft.Json;

namespace CleanToDoList.Tests
{
    [TestClass]
    public class AddedNoDescription
    {
        string path = @"AddedNoDescription.json";
        [TestMethod]
        public void GivenTaskWithoutDescriptionAndNoPreviousTaskWhenAddTaskThenTaskIsNotPersisted()
        {
            AddTaskRequest request = GivenTaskWithoutDescriptionAndNoPreviousTask();
            WhenAddTask(request);
            ThenTaskIsNotPersisted(request);
        }



        private AddTaskRequest GivenTaskWithoutDescriptionAndNoPreviousTask()
        {
            string description = "";
            DateTime date = DateTime.Now.AddDays(3);

            return new AddTaskRequest() { Description = description, DueDate = date };
        }

        private void WhenAddTask(AddTaskRequest request)
        {
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(path);
            AddTaskUseCase useCase = new AddTaskUseCase(toDoTaskRepository);
            useCase.Add(request);
        }

        private void ThenTaskIsNotPersisted(AddTaskRequest request)
        {
            Assert.IsFalse(System.IO.File.Exists(path));

        }
    }
}
