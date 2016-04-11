using CleanToDoLIst.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanToDoList.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = args[0];
            string description = args[1];
            string dueDate = args[2];

            Console.WriteLine( Add(description, dueDate));
            Console.Read();

        }

        private static string Add(string description, string dueDate)
        {
            IAddTaskUseCase addTaskUseCase = null;

            AddTaskResponse addTaskResponse = addTaskUseCase.Add(new AddTaskRequest()
            {
                Description = description,
                DueDate = DateTime.Parse(dueDate) }
            );

            return addTaskResponse.Result;

        }


    }
}
