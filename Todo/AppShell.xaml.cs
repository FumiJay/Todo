using Todo.Pages;
using Todo.BasePages;
using Todo.ViewModels;
using Todo.Services;

namespace Todo;

public partial class AppShell : Shell 
{
    public AppShell()
    {
        //https://learn.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/shell/navigation

        //https://github.com/jfversluis/MauiShellAppTemplate/blob/main/MauiShellApp/AppShell.xaml

        InitializeComponent();

        Routing.RegisterRoute(nameof(AddTodoPage), typeof(AddTodoPage));

        // register
        Routing.RegisterRoute(nameof(AuthPage), typeof(AuthPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        //Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        //Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));

        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
        Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));

        Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));

        //this.Appearing += OnAppearing;
        //this.Disappearing += OnDisappearing;
    }

    private async void LogoutButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Are you sure?", "You will be logged out.", "Yes", "No"))
        {
            Authentication ser = new Authentication();
            await ser.DoLogout();
            //SecureStorage.RemoveAll();
            await Shell.Current.DisplayAlert("Status: Logout Success", "Logout Success", "Ok");
            this.FlyoutIsPresented = false; //側邊滑動欄位 : 關閉已開啟狀態
            await AppShell.Current.GoToAsync("///loading");
        }
    }

    //private void OnAppearing(object sender, EventArgs e)
    //{

    //    AppShell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled);
    //    //Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
    //}

    //private void OnDisappearing(object sender, EventArgs e)
    //{
    //    //AppShell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
    //    Shell.SetFlyoutBehavior(this, FlyoutBehavior.Flyout);
    //}
}
