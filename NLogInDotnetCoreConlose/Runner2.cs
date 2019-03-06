using Microsoft.Extensions.Logging;

namespace NLogInDotnetCoreConlose
{
    public class Runner2 
    {
        private readonly ILogger<Runner2> _logger;

        public Runner2(ILogger<Runner2> logger)
        {
            _logger = logger;
        }

        public void DoAction(string name)
        {
            _logger.LogDebug(20, "Doing hard work! {Action}", name);
        }
    }
}
