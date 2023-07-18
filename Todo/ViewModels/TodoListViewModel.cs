using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Services;

namespace Todo.ViewModels
{
    //[QueryProperty(nameof(TodoItem), "TodoItem")]
    public partial class TodoListViewModel : ObservableObject
    {
        public ObservableCollection<TodoItemModel> Todos { get; set; } = new ObservableCollection<TodoItemModel>();
        private readonly ITodoService _todoService;

        public TodoListViewModel(ITodoService todoService)
        {
            _todoService = todoService;
        }


        [RelayCommand]
        public async void GetTodoList()
        {
            Todos.Clear();
            var todoList = await _todoService.GetTodos();
            if (todoList?.Count > 0)
            {
                foreach (var todo in todoList)
                {
                    Todos.Add(todo);
                }
            }
        }

        [RelayCommand]
        public async void EditTodo(TodoItemModel todoItemModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("TodoItem", todoItemModel);

            await AppShell.Current.GoToAsync(nameof(AddTodoPage), navParam);
        }

        [RelayCommand]
        public async void DeleteTodo(TodoItemModel todoItemModel)
        {
            var del = await _todoService.DeleteTodo(todoItemModel);
            GetTodoList();
        }
    }
}
