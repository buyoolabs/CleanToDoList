using CleanToDoLIst.Domain.Entities;
using CleanToDoLIst.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanToDoLIst.Domain.UseCases
{
    public class AddTaskUseCase : IAddTaskUseCase
    {
        private readonly IToDoTaskRepository toDoTaskRepository;
        public AddTaskUseCase(IToDoTaskRepository toDoTaskRepository)
        {
            this.toDoTaskRepository = toDoTaskRepository;
        }

        public AddTaskResponse Add(AddTaskRequest addTaskUseCaseRequestMessage)
        {
            //validación 
            /*IAddTaskValidator addTaskValidator = null;
            bool IsValid = addTaskValidator.Validate(addTaskUseCaseRequestMessage);*/
            //mapeo mensaje de entrada a entity de dominio
            ToDoTask toDoTask = null;
            try
            {
                toDoTask = new ToDoTask(addTaskUseCaseRequestMessage.Description, addTaskUseCaseRequestMessage.DueDate);              
            }
            catch (Exception ex)
            {
                var errorMessage = "Task not added: "+ex.Message;
                return new AddTaskResponse { Result = errorMessage };
            }

            toDoTaskRepository.Save(toDoTask);

            return new AddTaskResponse { Result = "Task added succesfully" };

        }
    }
}
