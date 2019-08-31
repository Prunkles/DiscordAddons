using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using JetBrains.Annotations;

namespace Discord.Net.BotMvc.Extensions.Button
{
    public class EmoteButton : IEmoteButton
    {
        private readonly DiscordSocketClient _client;
        
        public EmoteButton(DiscordSocketClient client, IEmote emote, ulong messageId, ButtonTrigger triggered)
        {
            _client = client;
            Emote = emote;
            MessageId = messageId;
            Triggered += triggered;
            
            _client.ReactionAdded += OnReactionAdded;
        }

        public IEmote Emote { get; set; }
        
        public ulong MessageId { get; set; }

        public event ButtonTrigger Triggered;
        
        private async Task OnReactionAdded(Cacheable<IUserMessage, ulong> cacheableMessage, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (cacheableMessage.Id != MessageId || // If it is not current message
                !reaction.Emote.Equals(Emote) || // If it is not current emote
                reaction.User.Value.IsBot) // If use is bot
                return;
         
            var message = cacheableMessage.HasValue
                ? cacheableMessage.Value
                : (IUserMessage) await channel.GetMessageAsync(cacheableMessage.Id);

            var user = reaction.User.Value;

            if (Triggered != null) await Triggered(user);

            await message.RemoveReactionAsync(Emote, user);
        }

        public void Dispose()
        {
            _client.ReactionAdded -= OnReactionAdded;
        }
    }
}