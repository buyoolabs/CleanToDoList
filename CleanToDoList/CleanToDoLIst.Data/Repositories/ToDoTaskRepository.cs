using CleanToDoLIst.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanToDoLIst.Domain.Entities;
using Newtonsoft.Json;

namespace CleanToDoLIst.Data.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private  readonly string path;
        public ToDoTaskRepository(string path)
        {
           this.path = path;
        }
        public void Save(ToDoTask toDoTask)
        {
            string toDoTaskToAdd = JsonConvert.SerializeObject(toDoTask);
            System.IO.File.WriteAllText(this.path, toDoTaskToAdd);

        }
    }
}
