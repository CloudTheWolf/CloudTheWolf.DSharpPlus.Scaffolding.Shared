﻿using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using DSharpPlus.Commands;
using Lavalink4NET.Players;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Bot Interface
    /// </summary>
    public interface IBot
    {
        /// <summary>
        /// <see cref="InteractivityExtension"/>
        /// </summary>
        InteractivityExtension Interactivity { get; set; }

        /// <summary>
        /// <see cref="DiscordClient"/>
        /// </summary>
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
        CommandsExtension Commands { get; set; }
    }

}
