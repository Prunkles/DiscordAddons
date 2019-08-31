using System.Threading.Tasks;
using Discord.Commands;

namespace Discord.Net.BotMvc.CommandView
{
    public class MessageResult : RuntimeResult, IMessageResult
    {
        private readonly string _text;
        private readonly bool _isTts;
        private readonly Embed _embed;
        private readonly RequestOptions _options;

        public MessageResult(string text = null, bool isTts = false, Embed embed = null, RequestOptions options = null) 
            : base(null, null)
        {
            _text = text;
            _isTts = isTts;
            _embed = embed;
            _options = options;
        }

        public async Task Send(ICommandContext context)
        {
            await context.Channel.SendMessageAsync(_text, _isTts, _embed, _options);
        }
    }
}