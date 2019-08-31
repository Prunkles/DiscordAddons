using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord.Net.BotMvc
{
    public class CommandHandler
    {
        public delegate Task ErrorHandler(Optional<CommandInfo> command, ICommandContext context, IResult result);

        private readonly string _prefix;
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _serviceProvider;

        public CommandHandler(string prefix, DiscordSocketClient client, CommandService commands, IServiceProvider serviceProvider)
        {
            _client = client;
            _commands = commands;
            _serviceProvider = serviceProvider;
            _prefix = prefix;
        }

        public async Task InstallCommandsAsync()
        {
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message == null || message.Author.IsBot) 
                return;

            var argPos = 0;
            
            if (message.HasStringPrefix(_prefix, ref argPos) || 
                message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                await _commands.ExecuteAsync(context, argPos, _serviceProvider);
            }
        }

        
    }
}