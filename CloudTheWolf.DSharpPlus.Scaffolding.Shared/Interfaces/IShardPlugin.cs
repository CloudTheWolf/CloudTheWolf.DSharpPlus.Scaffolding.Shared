using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using CloudTheWolf.DSharpPlus.Scaffolding.Logging;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    internal interface IShardPlugin : IPlugin
    {
        /// <summary>
        /// Initilize Plugin Module
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="logger"></param>
        /// <param name="discordConfiguration"></param>
        /// <param name="applicationConfig"></param>
        void InitPlugin(IBot bot, ILogger<Logger> logger, DiscordConfiguration discordConfiguration, IConfigurationRoot applicationConfig);
    }
}
