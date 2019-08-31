namespace Discord.Net.BotMvc.CommandView
{
    public class EmbedResult : MessageResult
    {
        public EmbedResult(Embed embed) 
            : base(embed: embed)
        {
        }

        public static implicit operator EmbedResult(Embed embed)
        {
            return new EmbedResult(embed);
        }
    }
}