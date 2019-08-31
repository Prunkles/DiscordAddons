using System.Threading.Tasks;
using Discord.Commands;

namespace Discord.Net.BotMvc.CommandView
{
    public interface IMessageResult : IResult
    {
        /// <summary>
        /// This method is used to send the result of returned in the command result as message on the channel.
        /// </summary>
        /// <param name="context">Context equal to the module context.</param>
        Task Send(ICommandContext context);
    }
}