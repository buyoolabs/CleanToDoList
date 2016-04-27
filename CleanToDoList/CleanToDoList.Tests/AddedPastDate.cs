using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanToDoLIst.Domain.UseCases;
using CleanToDoLIst.Domain.Repositories;
using CleanToDoLIst.Data.Repositories;
using Newtonsoft.Json;
using CleanToDoLIst.Domain.Entities;

namespace CleanToDoList.Tests
{
    [TestClass]
    public class AddedPastDate
    {
        string path = @"AddedPastDate.json";
        [TestMethod]
        public void GivenTaskWithPastDateWhenAddTaskThenTaskIsNotPersisted()
        {
            AddTaskRequest givenTask = GivenTaskWithPastDate();
            WhenAddTask(givenTask);
            ThenTaskIsNotPersisted(givenTask);

        }
        private AddTaskRequest GivenTaskWithPastDate()
        {
            string description = "Esta es una descripción";
            DateTime pastDate = DateTime.Now.AddDays(-1);
            AddTaskRequest addTaskRequest = new AddTaskRequest { Description = description, DueDate = pastDate };
            return addTaskRequest;
        }

        private void WhenAddTask(AddTaskRequest givenTask)
        {
            IToDoTaskRepository toDoTaskRepository = new ToDoTaskRepository(path);
            AddTaskUseCase useCase = new AddTaskUseCase(toDoTaskRepository);
            useCase.Add(givenTask);
        }

        private void ThenTaskIsNotPersisted(AddTaskRequest givenTask)
        {
            Assert.IsFalse(System.IO.File.Exists(path));
        }




    }
}
