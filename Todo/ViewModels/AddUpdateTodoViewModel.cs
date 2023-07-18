using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Services;

namespace Todo.ViewModels
{
    public partial class AddUpdateTodoViewModel : ObservableObject
    {
        [ObservableProperty]
        private TodoItemModel _todoItem = new TodoItemModel();
        private readonly ITodoService _todoService;

        public AddUpdateTodoViewModel(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [RelayCommand]
        public async void AddUpdateTodo()
        {
            int res = -1;
            if (TodoItem.TodoId > 0)
            {
                res = await _todoService.UpdateTodo(TodoItem);
            }
            else
            {
                res = await _todoService.AddTodo(new Models.TodoItemModel
                {
                    Title = TodoItem.Title,
                    IsDone = false,
                });
            }

            if (res > 0)
            {
                await Shell.Current.DisplayAlert("Status: Todo Saved", "The Todo Items Saved", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Status: Wrong", "Something is wrong", "Ok");
            }
        }
    }
}
