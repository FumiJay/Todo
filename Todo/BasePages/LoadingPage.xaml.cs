namespace Todo.BasePages;

using Todo.Extensions;
using Todo.MyModels;
using Todo.Services;
using Todo.ViewModels;

public partial class LoadingPage : ContentPage
{
    //https://www.c-sharpcorner.com/blogs/building-a-login-flow-with-net-maui
    public LoadingPage()
    {
        InitializeComponent();
        //MainThread.BeginInvokeOnMainThread(async () =>
        //{
        //    await RemoveLoginStatus();
        //});
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (await isAuthenticated())
        {
            //await Navigation.PushAsync(new MainPage());
            //await AppShell.Current.GoToAsync(nameof(MainPage));
            await AppShell.Current.GoToAsync("///MainPage");
        }
        else
        {
            #region MyRegion
            //AuthenticationViewModel vm = new AuthenticationViewModel(_authentication);
            //await Navigation.PushAsync(new LoginPage(vm)); 
            #endregion
            //await AppShell.Current.GoToAsync(nameof(LoginPage));
            await AppShell.Current.GoToAsync("///login");
        }

        base.OnNavigatedTo(args);
    }

    async Task<bool> isAuthenticated()
    {
        await Task.Delay(500);
        var hasAuth = GlobalData.ApiToken.IsNullOrEmpty();

        //AuthenticationViewModel vm = new AuthenticationViewModel(_authentication);
        //AppShell ap = new AppShell();
        var obj = Application.Current.MainPage;
        //ap = obj as AppShell;
        AppShell.SetFlyoutBehavior(obj as AppShell, (FlyoutBehavior)Convert.ToInt32(!hasAuth)); // 側邊滑動欄位 : 預設開啟 控制取消

        return !(hasAuth == true);
    }

    //async Task<int> OpenFlyout()
    //{
    //    await Task.Delay(100);
        
    //    return (await isAuthenticated() == true ? 0 : 1);
    //}

    //async Task RemoveLoginStatus()
    //{
    //    await Task.Delay(500);
    //    SecureStorage.Remove("hasAuth");
    //    //SecureStorage.RemoveAll();
    //}
}