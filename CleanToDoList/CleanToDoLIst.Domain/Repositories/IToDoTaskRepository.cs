using CleanToDoLIst.Domain.Entities;

namespace CleanToDoLIst.Domain.Repositories
{
    public interface IToDoTaskRepository
    {
        void Save(ToDoTask toDoTask);
    }
}