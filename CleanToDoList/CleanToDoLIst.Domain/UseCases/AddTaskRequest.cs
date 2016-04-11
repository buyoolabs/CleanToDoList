using System;

namespace CleanToDoLIst.Domain.UseCases
{
    public class AddTaskRequest
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}