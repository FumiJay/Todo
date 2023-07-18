//using AndroidX.Lifecycle;
using Todo.ViewModels;

namespace Todo;

public partial class TodoPage : ContentPage
{
    private TodoListViewModel _vm;
    public TodoPage(TodoListViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        this.BindingContext = vm;
    }

    private async void ButtonClicked(object sender, EventArgs e)
    {
        await AppShell.Current.GoToAsync(nameof(AddTodoPage));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.GetTodoList();
    }
}