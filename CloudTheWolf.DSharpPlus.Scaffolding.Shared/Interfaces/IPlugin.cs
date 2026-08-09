using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Plugin Interface
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Module Name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Module Description
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Modude Version
        /// </summary>
        int Version { get; }

        /// <summary>A stable identifier used for logging and named registrations.</summary>
        string Id => GetType().FullName ?? Name;

        /// <summary>The plugin's semantic version.</summary>
        System.Version PluginVersion => new(Version, 0);

        /// <summary>
        /// Initialize the plugin module.
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="logger">The host-owned logger. Plugins must not reconfigure or dispose it.</param>
        /// <param name="discordConfiguration"></param>
        /// <param name="applicationConfig"></param>
        void InitPlugin(IBot bot, ILogger logger, DiscordConfiguration discordConfiguration,
            IConfigurationRoot applicationConfig)
        {
        }

        /// <summary>
        /// Initializes the plugin before the Discord client is built. Override this method for
        /// asynchronous startup; the default implementation calls <see cref="InitPlugin"/> for
        /// compatibility with existing plugins.
        /// </summary>
        Task InitializeAsync(PluginContext context, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);
            cancellationToken.ThrowIfCancellationRequested();
            InitPlugin(context.Bot, context.Logger, context.DiscordConfiguration, context.Configuration);
            return Task.CompletedTask;
        }

        /// <summary>Releases plugin resources during worker shutdown.</summary>
        Task ShutdownAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }

    }
}
