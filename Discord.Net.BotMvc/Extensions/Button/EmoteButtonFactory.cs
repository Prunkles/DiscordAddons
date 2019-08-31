using Discord;
using Discord.WebSocket;

namespace Discord.Net.BotMvc.Extensions.Button
{
    public class EmoteButtonFactory : IEmoteButtonFactory
    {
        private readonly DiscordSocketClient _client;

        public EmoteButtonFactory(DiscordSocketClient client)
        {
            _client = client;
        }

        public IEmoteButton Create(IEmote emote, ulong messageId, ButtonTrigger trigger)
        {
            var emoteButton = new EmoteButton(_client, emote, messageId, trigger);
            return emoteButton;
        }
    }
}
