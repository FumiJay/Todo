using Todo.Models;
using Todo.Services;
using Todo.ViewModels;

namespace Todo;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage(AddUpdateTodoViewModel vm)
    {
		InitializeComponent();
        this.BindingContext = vm;
    }

}