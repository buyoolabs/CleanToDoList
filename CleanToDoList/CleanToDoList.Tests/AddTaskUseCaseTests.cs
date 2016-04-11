using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleanToDoLIst.Domain.UseCases;

namespace CleanToDoList.Tests
{
    [TestClass]
    public class AddTaskUseCaseTests
    {
        [TestMethod]
        public void AddTaskWithGoodArgumentShouldReturnOK()
        {
            //Arrange
            IAddTaskUseCase addTaskUseCase = new AddTaskUseCase();

            //Act
            AddTaskResponse addTaskResponse = addTaskUseCase.Add(new AddTaskRequest()
            {
                Description = "Descripcion de test",
                DueDate = DateTime.MaxValue
            }
            );
            //Asset
            Assert.AreEqual("Task added succesfully", addTaskResponse.Result);
        }

        [TestMethod]
        public void AddTask_WithEmptyDescription_ShouldReturnError()
        {
            //Arrange
            IAddTaskUseCase addTaskUseCase = new AddTaskUseCase();

            //Act
            AddTaskResponse addTaskResponse = addTaskUseCase.Add(new AddTaskRequest()
            {
                Description = "",
                DueDate = DateTime.MaxValue
            }
            );
            //Asset
            Assert.AreEqual("Task not added: Description is required", addTaskResponse.Result);
        }

    }
}
