using Microsoft.Extensions.DependencyInjection;

namespace Discord.Net.BotMvc.Extensions.Button
{
    public static class EmoteButtonExtensions
    {
        public static IServiceCollection AddEmoteButton(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IEmoteButtonFactory, EmoteButtonFactory>();
        }
    }
}