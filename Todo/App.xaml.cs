using Todo.Helpers;
using NLog;
using Todo.ViewModels;
using Todo.BasePages;

namespace Todo;

public partial class App : Application
{
    public static WebApiHelper helper = new WebApiHelper();
    public static Logger logger = LogManager.GetLogger("f");
    public static Logger oplogger = NLog.LogManager.GetLogger("OPLog");
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
