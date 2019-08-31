using System.Threading.Tasks;
using Discord.Commands;

namespace Discord.Net.BotMvc.CommandView
{
    public class CommandViewService
    {
        public delegate Task ErrorHandler(Optional<CommandInfo> command, ICommandContext context, IResult result);
        
        private readonly ErrorHandler _errorHandler;

        public CommandViewService(ErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }
        
        public async Task OnCommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (result == null)
                return;
            
            if (!result.IsSuccess)
            {
                await _errorHandler(command, context, result);
                return;
            }

            if (result is IMessageResult messageResult)
            {
                await messageResult.Send(context);
                
                return;
            }
        }
    }
}