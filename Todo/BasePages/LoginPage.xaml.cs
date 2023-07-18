using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Todo.ViewModels;

namespace Todo.BasePages;

public partial class LoginPage : ContentPage
{
    public LoginPage(AuthenticationViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;

        //this.Appearing += OnAppearing;
        this.Disappearing += OnDisappearing;
    }

    private void OnAppearing(object sender, EventArgs e)
    {
        //var obj = Application.Current.MainPage;

        AppShell ap = new AppShell(); 
        var obj = Application.Current.MainPage;
        ap = obj as AppShell;
        AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)0); // 側邊滑動欄位 : 預設開啟 控制取消
    }

    private async void OnDisappearing(object sender, EventArgs e)
    {
        AppShell ap = new AppShell();
        var obj = Application.Current.MainPage;
        ap = obj as AppShell;
        AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)1);
        await KeyboardExtensions.HideKeyboardAsync(this.Password, CancellationToken.None);  //取消顯示鍵盤
    }

    //private async void LoginButton_Clicked(object sender, EventArgs e)
    //{
    //    if (IsCredentialCorrect(Username.Text = "admin", Password.Text = "1234"))
    //    {
    //        await SecureStorage.SetAsync("hasAuth", "true");
    //        await Shell.Current.GoToAsync("///loading");
    //        //await AppShell.Current.GoToAsync(nameof(AuthPage));
    //        //await Navigation.PushAsync(new AllNotesPage());
    //    }
    //    else
    //    {
    //        await DisplayAlert("Login failed", "Uusername or password if invalid", "Try again");
    //    }
    //}

    //bool IsCredentialCorrect(string username, string password)
    //{
    //    return Username.Text == "admin" && Password.Text == "1234";
    //}
}