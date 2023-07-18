using Todo.ViewModels;

namespace Todo.Pages 
{
    public partial class AuthPage : ContentPage
    {
        public AuthPage(AuthViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        private async void RegisterRoute(object sender, EventArgs e)
        {
            await AppShell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}

