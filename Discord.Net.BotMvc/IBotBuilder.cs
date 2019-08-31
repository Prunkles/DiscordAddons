using System;
using Discord.Commands;
using Discord.WebSocket;

namespace Discord.Net.BotMvc
{
    public interface IBotBuilder
    {
        IServiceProvider Services { get; }

        DiscordSocketClient Client { get; }
        CommandService Commands { get; }
    }
}