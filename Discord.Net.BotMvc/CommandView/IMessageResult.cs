using System.Threading.Tasks;
using Discord.Commands;

namespace Discord.Net.BotMvc.CommandView
{
    public interface IMessageResult : IResult
    {
        Task Send(ICommandContext context);
    }
}