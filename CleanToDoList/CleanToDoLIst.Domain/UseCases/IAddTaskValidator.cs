using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanToDoLIst.Domain.UseCases
{
    public interface IAddTaskValidator
    {
        bool Validate(AddTaskRequest addTaskRequest);
    }
}
