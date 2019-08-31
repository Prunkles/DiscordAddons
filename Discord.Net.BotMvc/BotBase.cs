using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Discord.Net.BotMvc
{
    public abstract class BotBase
    {
        protected IServiceProvider Services { get; private set; }
        
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        
        private readonly string _prefix;
        private readonly string _token;

        protected BotBase(string token, string prefix)
            : this(token, prefix, 
                new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Debug,
                },
                new CommandServiceConfig()
                {
                    CaseSensitiveCommands = true,
                    DefaultRunMode = RunMode.Async,
                    LogLevel = LogSeverity.Debug,
                })
        {
        }

        protected BotBase(string token, string prefix, DiscordSocketConfig discordConfig, CommandServiceConfig commandsConfig)
        {
            _prefix = prefix;
            _token = token;
            
            _client = new DiscordSocketClient(discordConfig);
            
            _commands = new CommandService(commandsConfig);
        }

        public async Task Start()
        {
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task Setup()
        {
            // Configure services
            
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddSingleton(_client);
            serviceCollection.AddSingleton(_commands);
            serviceCollection.AddSingleton(provider => new CommandHandler(_prefix, _client, _commands, provider));
            ConfigureServices(serviceCollection);

            Services = serviceCollection.BuildServiceProvider();

            // Configure bot
            
            await Services.GetService<CommandHandler>().InstallCommandsAsync();
            
            Configure(new BotBuilder()
            {
                Services = Services,
                Client = _client,
                Commands = _commands,
            });
            
            // Login
            await _client.LoginAsync(TokenType.Bot, _token);
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        protected virtual void Configure(IBotBuilder builder)
        {
        }
    }
}