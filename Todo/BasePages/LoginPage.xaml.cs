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
        //VM_Authentication = new AuthenticationViewModel();

        //this.BindingContext = VM_Authentication;

        // 手指點擊事件 : https://learn.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/gestures/tap
        var tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped +=  async (s, e) => {
            await KeyboardExtensions.HideKeyboardAsync(this.Password, CancellationToken.None);  //取消顯示鍵盤
        };
        table.GestureRecognizers.Add(tapGestureRecognizer);

        #region 讀取動畫教學/範例
        // 讀取條: https://learn.microsoft.com/zh-tw/dotnet/api/microsoft.maui.controls.progressbar?view=net-maui-7.0
        // 轉圈圖: https://learn.microsoft.com/zh-tw/dotnet/maui/user-interface/controls/activityindicator
        // 因為要強加UI到grid上 所以要擴充ContentPage 比較好呼叫畫面元件 可以共用loading function
        //ActivityIndicator activityIndicator = new ActivityIndicator
        //{
        //    Color = Colors.Lime,
        //    IsRunning = true,
        //    HeightRequest = 50,
        //    WidthRequest = 50,
        //    IsVisible = true,
        //};

        //table.Children.Add(activityIndicator);

        #endregion
    }

    //private void OnAppearing(object sender, EventArgs e)
    //{
    //    var aa = AppShell.GetFlyoutBehavior(this); //Microsoft.Maui.FlyoutBehavior.Flyout

    //    AppShell ap = new AppShell(); //Microsoft.Maui.Controls.Shell
    //    var obj = Application.Current.MainPage; //Microsoft.Maui.Controls.Shell
    //    ap = obj as AppShell;
    //    AppShell.SetFlyoutBehavior(ap, (FlyoutBehavior)0); // 側邊滑動欄位 : 預設開啟 控制取消
    //}

    //private async void OnDisappearing(object sender, EventArgs e)
    //{
    //    await KeyboardExtensions.HideKeyboardAsync(this.Password, CancellationToken.None);  //取消顯示鍵盤
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