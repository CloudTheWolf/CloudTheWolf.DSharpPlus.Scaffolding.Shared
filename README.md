![CloudTheWolf.DSharpPlus.Scaffolding](https://github.com/CloudTheWolf/CloudTheWolf.DSharpPlus.Scaffolding/raw/main/banner.png)

# CloudTheWolf.DSharpPlus.Scaffolding.Shared

Shared bot and plugin contracts for CloudTheWolf DSharpPlus workers.

## Plugin lifecycle

Plugins can initialize asynchronously and release resources during worker shutdown:

```csharp
public sealed class ExamplePlugin : IPlugin
{
    public string Name => "Example";
    public string Id => "cloudthewolf.example";
    public string Description => "Example plugin";
    public int Version => 1;
    public Version PluginVersion => new(1, 0, 0);

    public Task InitializeAsync(
        PluginContext context,
        CancellationToken cancellationToken = default)
    {
        context.Bot.RegisterCommand(CommandBuilder.From(typeof(ExampleCommands)));
        context.Bot.RegisterEventHandlers(Id, events => events
            .HandleSessionCreated(OnSessionCreated));

        context.Logger.Information("Plugin initialized");
        return Task.CompletedTask;
    }

    public Task ShutdownAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
```

`PluginContext` exposes the host-owned bot, logger, Discord configuration, and
application configuration. Plugins must not reconfigure or dispose the logger.

Existing plugins that implement `InitPlugin(...)` remain supported through the
default asynchronous lifecycle implementation.

## Event handlers

Named registrations make duplicate ownership errors visible and preserve
registration order. The registry is sealed when its contributions are applied
to the Discord client, preventing late registrations that DSharpPlus cannot use.

Use `IBot.RegisterEventHandlers(...)` from plugins. `IBot.EventHandlers` also
supports inspecting registered names and removing a registration before startup.

The Worker can hot load, replace, and unload plugins by rebuilding the Discord
client in-process. This preserves the Worker process while safely releasing all
plugin-owned commands, event delegates, and collectible assembly contexts.
