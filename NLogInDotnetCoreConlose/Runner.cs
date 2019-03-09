using Microsoft.Extensions.Logging;

namespace NLogInDotnetCoreConlose
{
    public class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void DoAction(string name)
        {
            
            _logger.LogDebug("Doing hard work! {Action}", name);
            _logger.LogInformation("Doing hard work! {Action}", name);
            _logger.LogError("working error! {Action}", name);
        }


    }
}
