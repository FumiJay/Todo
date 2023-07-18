using Todo.ViewModels;

namespace Todo.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(AuthViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }
}