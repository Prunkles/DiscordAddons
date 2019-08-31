namespace Discord.Net.BotMvc.Extensions.Button
{
    public static class Extensions
    {
        public static IEmoteButton Create(this IEmoteButtonFactory emoteButtonFactory, IEmote emote, ulong messageId)
        {
            var emoteButton = emoteButtonFactory.Create(emote, messageId, null);
            return emoteButton;
        }
    }
}