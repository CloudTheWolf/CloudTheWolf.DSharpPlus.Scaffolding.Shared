using System;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Provides host-owned services and configuration to a plugin during initialization.
    /// </summary>
    public sealed class PluginContext
    {
        /// <summary>Creates a plugin initialization context.</summary>
        public PluginContext(
            IBot bot,
            ILogger logger,
            DiscordConfiguration discordConfiguration,
            IConfigurationRoot configuration)
        {
            Bot = bot ?? throw new ArgumentNullException(nameof(bot));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            DiscordConfiguration = discordConfiguration ??
                throw new ArgumentNullException(nameof(discordConfiguration));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>The bot instance hosting the plugin.</summary>
        public IBot Bot { get; }

        /// <summary>
        /// A logger enriched for this plugin. The host owns its lifetime and configuration.
        /// </summary>
        public ILogger Logger { get; }

        /// <summary>The Discord client configuration supplied by the host.</summary>
        public DiscordConfiguration DiscordConfiguration { get; }

        /// <summary>The worker application configuration.</summary>
        public IConfigurationRoot Configuration { get; }
    }
}
