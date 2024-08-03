using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Serilog;

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

        /// <summary>
        /// Initilize Plugin Module
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="logger"></param>
        /// <param name="discordConfiguration"></param>
        /// <param name="applicationConfig"></param>
        void InitPlugin(IBot bot, ILogger logger, DiscordConfiguration discordConfiguration, IConfigurationRoot applicationConfig);

    }
}
