using Discord;

namespace Discord.Net.BotMvc.Extensions.Button
{
    public interface IEmoteButtonFactory
    {
        IEmoteButton Create(IEmote emote, ulong messageId, ButtonTrigger trigger);
    }
}