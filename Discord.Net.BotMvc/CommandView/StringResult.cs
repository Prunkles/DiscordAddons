namespace Discord.Net.BotMvc.CommandView
{
    public class StringResult : MessageResult
    {
        public StringResult(string text)
            : base(text: text)
        {
        }
        
        public static implicit operator StringResult(string text)
        {
            return new StringResult(text);
        }
    }
}