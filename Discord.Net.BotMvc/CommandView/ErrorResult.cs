using Discord.Commands;

namespace Discord.Net.BotMvc.CommandView
{
    public class ErrorResult : RuntimeResult
    {
        public ErrorResult(CommandError? error, string reason) : base(error, reason)
        {
        }

        public ErrorResult(string reason) : base(CommandError.Unsuccessful, reason)
        {
        }
    }
}