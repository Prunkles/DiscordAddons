namespace Discord.Net.BotMvc.CommandView
{
    public static class CommandViewExtensions
    {
        public static void UseViews(this IBotBuilder botBuilder, CommandViewService.ErrorHandler errorHandler)
        {
            var commandView = new CommandViewService(errorHandler);
            botBuilder.Commands.CommandExecuted += commandView.OnCommandExecutedAsync;
        }
    }
}