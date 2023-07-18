using Camera.MAUI;
using Capture.Vision.Maui;
using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Todo.BasePages;
using Todo.Pages;
using Todo.Services;
using Todo.ViewModels;

namespace Todo;

public static class MauiProgram
{
    //private static readonly IAuthentication _authentication;
    public static MauiApp CreateMauiApp()
	{
        //https://learn.microsoft.com/zh-tw/dotnet/maui/fundamentals/app-lifecycle

        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCameraView()
            .UseNativeCameraView()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        #region 安卓應用程式 - 行動控制
        //            .ConfigureLifecycleEvents(events =>
        //            {
        //#if ANDROID
        //                events.AddAndroid(android => android
        //                    .OnActivityResult((activity, requestCode, resultCode, data) => LogEvent(nameof(AndroidLifecycle.OnActivityResult), requestCode.ToString()))
        //                    .OnStart((activity) => LogEvent(nameof(AndroidLifecycle.OnStart)))
        //                    .OnCreate((activity, bundle) => LogEvent(nameof(AndroidLifecycle.OnCreate)))
        //                    .OnBackPressed((activity) => LogEvent(nameof(AndroidLifecycle.OnBackPressed)) && false)
        //                    .OnStop(async (activity) =>
        //                    {
        //                        LogEvent(nameof(AndroidLifecycle.OnStop));
        //                        await _authentication.DoLogout();
        //                    }));
        //#endif
        //                static bool LogEvent(string eventName, string type = null)
        //                {
        //                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
        //                    return true;
        //                }
        //            }); 
        #endregion

        // Add TodoItem Service
        builder.Services.AddSingleton<ITodoService, TodoService>();
        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<ICameraService, CameraService>();
        builder.Services.AddSingleton<IAuthentication, Authentication>();

        // Add Views
        builder.Services.AddSingleton<AddTodoPage>();
        builder.Services.AddSingleton<TodoPage>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<AuthPage>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<LoadingPage>();
        //builder.Services.AddSingleton<AboutPage>();
        //builder.Services.AddSingleton<NotePage>();

        // Add ViewModel
        builder.Services.AddSingleton<TodoListViewModel>();
        builder.Services.AddSingleton<AddUpdateTodoViewModel>();
        builder.Services.AddSingleton<AuthViewModel>();
        builder.Services.AddSingleton<AuthenticationViewModel>();

        return builder.Build();
    }
}
