using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;

namespace Discord.Net.BotMvc.Extensions.Alerts
{
    public class Alert
    {
//        private static readonly ICollection<Task> ReplyQueue;
//
//        static Alert()
//        {
//            ReplyQueue = new List<Task>();
//        }

        public static async Task Reply(ITextChannel channel, string text, int delayMs)
        {
            var message = await channel.SendMessageAsync(text);

            await Task.Delay(delayMs);

            try
            {
                await message.DeleteAsync();
            }
            // TODO: Specify a specific exception
            catch (Exception e)
            {
                Console.WriteLine(e);
                // ignored
            }
        }
    }
}