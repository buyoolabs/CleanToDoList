using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanToDoLIst.Domain.Entities
{
    public class ToDoTask
    {
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public DateTime DueDate { get; private set; }

        public ToDoTask(string description, DateTime dueDate)
        {
            if(string.IsNullOrEmpty(description))
            {
                throw new Exception("Description is required");
            }
            if(DueDateIsExpired(dueDate))
            {
                throw new Exception("Due date is in the past");
            }
            Description = description;
            DueDate = dueDate;
            Completed = false;
        }

        private bool DueDateIsExpired(DateTime dueDate)
        {
            return  dueDate.Subtract(DateTime.Now).Days<0;
        }
    }
}
