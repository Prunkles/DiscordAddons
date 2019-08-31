using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Discord.Net.BotMvc.Extensions
{
    public static class LoggerExtensions
    {
        public static IBotBuilder UseCommandLogger(this IBotBuilder botBuilder)
        {
            var logger = botBuilder.Services.GetService<ILogger>();
            
            botBuilder.Commands.Log += message =>
            {
                logger.LogInformation(message.ToString());
                return Task.CompletedTask;
            };

            return botBuilder;
        }
    }
}

