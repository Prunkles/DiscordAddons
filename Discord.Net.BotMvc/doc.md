# Introduction

This library realise a MVC pattern for Discord.Net library. 

Discord.Net Modules (`ModuleBase`) is a Controller equivalent. 

There is also an available DI in all added services.

# Configuring
You can configure the bot the way you do it in an ASP project.
```
class MyBot : BotBase
{
    private IConfiguration _config;

    public MyBot(IConfiguration config)
        : base(config["token"], config["prefix"])
    {
        _config = config;
    }
    
    // Lets configure the bot
    protected override Configure(IBotBuilder botBuilder)
    {
        // Subscribe to some events
        botBuilder.Client.OnMessageRecieved += ConsoleLog;
        
        // Or add your own extensions-methods like `.Use*()` in ASP
        botBuilder.UsePosts(config => config.AllowCreting = true);
    }
    
    protected override ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(_config);
        
        services.AddPosts();
        
        services.AddDbContext<SomeDbContext>();
    }
    
    // Simple logging
    private Task ConsoleLog(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }
}
```

# Views

### StringMessageResult

Be sure to return the type `RuntimeResult`, not `StringMessageResult`, `ErrorResult`, or your `YourOwnResult : RuntimeResult`. Discord.Net allowed to do it only this way. (I hope it will be fixed in future releases of Discord.Net)

```c#
[Command("ping")]
public async Task<RuntimeResult> PingAsync()
{
    return new StringMessageResult("Pong!");
}
```
Prints `Pong!` message to the channel where this command was called.


### EmbedMessageResult & ErrorResult
```
[Command("help")]
public async Task<RuntimeResult> HelpAsync(string input)
{
    var result = _commandService.Search(input);
    if (!result.IsSuccess)
        // Here
        return new ErrorResult(result.Reason);
    
    var command = result.Commands.First();
    
    var eb = new EmbedBuilder()
        .WithTitle(command.Aliases.First())
        .AddField(command.Remarks, command.Summary);
    
    // And here
    return new EmbedMessageResult(eb.Build());
}
```
Prints coincident embed.

# Misc

There are also some stuff, such as 

### EmoteButton

that allow you to call some a method when a user emote the message.

You need to use the `IEmoteFactory` to create new EmoteButton using the method
`IEmoteButton Create(IEmote emote, ulong messageId, ButtonTrigger trigger);` , where `ButtonTrigger` is `delegate Task ButtonTrigger(IUser user)`

For example:

```
class SomeService
{
    public static readonly IEmote PlusEmote = new Emoji("\u2795");

    public SomeService(IEmoteFactory emoteFactory)
    {
        emoteFactory.Craete(PlusEmote, Messages.AddNewPostMessageId, OnButtonTriggered);
    }
    
    private async Task OnButtonTriggered(IUser user)
    {
        // do something
    }
}
```

### Many more usefulness will be added.