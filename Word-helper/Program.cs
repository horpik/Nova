using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using Word_helper.Src.Commands;
using Word_helper.Src.ViewModels;
using System.Windows.Input;
using Serilog.Events;
using Serilog;
using Serilog.Formatting.Json;

namespace Word_helper
{
    public class Program
    {
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]

        public static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<ICommand, CreateDocumentsCommand>();
                    services.AddSingleton<CreateDocumentsViewModel>();
                    services.AddSingleton<MainWindow>(s => new MainWindow()
                    {
                        DataContext = s.GetRequiredService<CreateDocumentsViewModel>()
                    });
                })
                .Build();
            var app = host.Services.GetRequiredService<App>();
            app?.Run();

            // TODO Логирование не работает
            /*Log.Logger = new LoggerConfiguration()
                            .WriteTo.File(new JsonFormatter(), "important.json")
                            .WriteTo.File("all.logs",
                                          restrictedToMinimumLevel: LogEventLevel.Warning,
                                          fileSizeLimitBytes: 4096,
                                          rollingInterval: RollingInterval.Day)
                            .MinimumLevel.Debug()
                            .CreateLogger();*/

        }
    }
}