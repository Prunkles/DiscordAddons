using System;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord.Net.BotMvc
{
    public class BotBuilder : IBotBuilder
    {
        public IServiceProvider Services { get; set; }
        public DiscordSocketClient Client { get; set; }
        public CommandService Commands { get; set; }
    }
}