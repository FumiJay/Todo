using CommunityToolkit.Maui.Core.Platform;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Todo.Services;
using Todo.ViewModels;

namespace Todo.BasePages;

public partial class LoginPage : ContentPage
{
    //private IAuthentication _authentication;
    private AuthenticationViewModel VM_Authentication { get; set; }
    public LoginPage()
    {
        InitializeComponent();
        //_authentication = ia; 
        VM_Authentication = new AuthenticationViewModel();

        this.BindingContext = VM_Authentication;
        //this.Appearing += OnAppearing;
        //this.Disappearing += OnDisappearing;
    }

    //private void LoginButton_Clicked(object sender, EventArgs e)
    //{
    //    // �]���n�j�[UI��grid�W �ҥH�n�X�RContentPage ����n�I�s�e������ �i�H�@��loading function
    //    ActivityIndicator activityIndicator = new ActivityIndicator
    //    {
    //        Color = Colors.Lime,
    //        IsRunning = true,
    //        HeightRequest = 50,
    //        WidthRequest = 50,
    //        IsVisible = true,
    //    };

    //    table.Children.Add(activityIndicator);
    //}

    //private void OnAppearing(object sender, EventArgs e)
    //{
    //    var aa = AppShell.GetFlyoutBehavior(this); //Microsoft.Maui.FlyoutBehavior.Flyout

    //    AppShell ap = new AppShell(); //Microsoft.Maui.Controls.Shell
    //    var obj = Application.Current.MainPage; //Microsoft.Maui.Controls.Shell
    //    ap = obj as AppShell;
    //    AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)0); // ����ư���� : �w�]�}�� �������
    //}

    //private async void OnDisappearing(object sender, EventArgs e)
    //{
    //    AppShell ap = new AppShell();
    //    var obj = Application.Current.MainPage;
    //    ap = obj as AppShell;
    //    AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)1);
    //    await KeyboardExtensions.HideKeyboardAsync(this.Password, CancellationToken.None);  //���������L
    //}

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