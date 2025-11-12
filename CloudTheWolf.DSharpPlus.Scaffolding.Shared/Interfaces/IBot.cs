using System;
using System.Collections.Generic;
using CloudTheWolf.DSharpPlus.Scaffolding.Worker.Registry;
using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Trees;
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
        /// <see cref="LavalinkPlayerOptions"/>
        /// </summary>
        LavalinkPlayerOptions LavalinkPlayerOptions { get; set; }

        /// <summary>
        /// <see cref="CommandsExtension"/>
        /// </summary>
        [Obsolete("Use CommandsList instead")]
        CommandsExtension Commands { get; set; }

        /// <summary>
        /// <see cref="List{T}"/> of <see cref="CommandBuilder"/> objects
        /// </summary>
        List<CommandBuilder> CommandsList { get; set; }

        /// <summary>
        /// Expose the EventHandlerRegistry so plugins can register handlers
        /// </summary>
        EventHandlerRegistry EventHandlerRegistry { get; }

    }

}
