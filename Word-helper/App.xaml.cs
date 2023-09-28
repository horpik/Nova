
using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;
using System.Windows;
using Word_helper.Src.Commands;
using Word_helper.Src.ViewModels;

namespace Word_helper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly MainWindow mainWindow;
        public App(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
