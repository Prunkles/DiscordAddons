using System;
using System.Threading.Tasks;
using Discord;

namespace Discord.Net.BotMvc.Extensions.Button
{
    public delegate Task ButtonTrigger(IUser user);
    
    public interface IEmoteButton : IDisposable
    {
        IEmote Emote { get; }
        
        ulong MessageId { get; }

        event ButtonTrigger Triggered;
    }
}