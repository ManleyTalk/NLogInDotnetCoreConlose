using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using System;

namespace NLogInDotnetCoreConlose
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger("*");
            logger.Info("这个信息");
            logger.Debug("这个调试");
            logger.Error("这个是错误");
            var servicesProvider = BuildDi();
            var runner = servicesProvider.GetRequiredService<Runner>();
            runner.DoAction("runner Action");

            var runner2 = servicesProvider.GetRequiredService<Runner2>();
            runner.DoAction("runner2 Action");

            Console.WriteLine("Press ANY key to exit");
            Console.ReadLine();

            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }

        private static ServiceProvider BuildDi()
        {            

            return new ServiceCollection()
                .AddLogging(builder => {
                    builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    builder.AddNLog(new NLogProviderOptions
                    {
                        CaptureMessageTemplates = true,
                        CaptureMessageProperties = true
                    });
                })
                .AddTransient<Runner>()
                .AddTransient<Runner2>()
                .BuildServiceProvider();
        }
    }
}
