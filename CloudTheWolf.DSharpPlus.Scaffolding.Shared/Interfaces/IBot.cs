using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using DSharpPlus.Commands;
using Lavalink4NET.Players;
using System;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Bot Interface
    /// </summary>
    public interface IBot
    {
        /// <summary>
        ///<see cref="CommandsNextExtension"/>
        /// </summary>
        CommandsNextExtension Commands { get; set;}
        /// <summary>
        /// <see cref="InteractivityExtension"/>
        /// </summary>
        InteractivityExtension Interactivity { get; set; }

        /// <summary>
        /// <see cref="DiscordClient"/>
        /// </summary>
        [Obsolete("Use ClientBuilder instead")]
        DiscordClient Client { get; set; }

        /// <summary>
        /// <see cref="ClientBuilder"/>
        /// </summary>
        DiscordClientBuilder ClientBuilder { get; set; }

        /// <summary>
        /// <see cref="VoiceNextExtension"/>
        /// </summary>
        VoiceNextExtension Voice { get; set; }
        /// <summary>
        /// <see cref="DiscordRestClient"/>
        /// </summary>
        DiscordRestClient Rest { get; set; }

        /// <summary>
        /// <see cref="LavalinkPlayerOptions"/>
        /// </summary>
        LavalinkPlayerOptions LavalinkPlayerOptions { get; set; }

        /// <summary>
        /// <see cref="CommandsExtension"/>
        /// </summary>
        CommandsExtension CommandsExt { get; set; }
    }

}
