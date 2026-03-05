using System.Windows;
using RegraphikApp.Data;

namespace RegraphikApp;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        Database.InitializeDatabase();
        base.OnStartup(e);
    }
}