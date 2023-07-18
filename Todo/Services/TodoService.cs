using CommunityToolkit.Mvvm.Input;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;


namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private SQLiteAsyncConnection _connection;

        public TodoService()
        {
            _setDb();
        }

        private async void _setDb()
        {
            if (_connection == null)
            {
                // C:\Users\Fumi\AppData\Local\db.sqlite
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db.sqlite");
                _connection = new SQLiteAsyncConnection(dbPath);
                await _connection.CreateTableAsync<TodoItemModel>();
            }
        }

        public Task<int> AddTodo(TodoItemModel todoItemModel)
        {
            return _connection.InsertAsync(todoItemModel);
        }

        public async Task<List<TodoItemModel>> GetTodos()
        {
            var todos = await _connection.Table<TodoItemModel>().ToListAsync();
            return todos;
        }

        Task<int> ITodoService.DeleteTodo(TodoItemModel todoItemModel)
        {
            return _connection.DeleteAsync(todoItemModel);
        }

        Task<int> ITodoService.UpdateTodo(TodoItemModel todoItemModel)
        {
            return _connection.UpdateAsync(todoItemModel);
        }

    }
}
