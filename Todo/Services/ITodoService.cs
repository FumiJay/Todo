using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface ITodoService
    {
        Task<List<TodoItemModel>> GetTodos();
        Task<int> AddTodo(TodoItemModel todoItemModel);
        Task<int> DeleteTodo(TodoItemModel todoItemModel);
        Task<int> UpdateTodo(TodoItemModel todoItemModel);
    }
}
