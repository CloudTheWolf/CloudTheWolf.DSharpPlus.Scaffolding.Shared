using CloudTheWolf.DSharpPlus.Scaffolding.Logging;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Plugin Interface
    /// </summary>
    public interface IPlugin : IDisposable
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

        /// <summary>
        /// Initilize Plugin Module
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="logger"></param>
        /// <param name="discordConfiguration"></param>
        /// <param name="applicationConfig"></param>
        void InitPlugin(IBot bot, ILogger<Logger> logger, DiscordConfiguration discordConfiguration, IConfigurationRoot applicationConfig);

        /// <summary>
        /// Clean up and unload the plugin. This should be used to release any resources and perform clean-up before the plugin is unloaded.
        /// </summary>
        void UnloadPlugin(IBot bot, ILogger<Logger> logger, DiscordConfiguration discordConfiguration);

    }
}
