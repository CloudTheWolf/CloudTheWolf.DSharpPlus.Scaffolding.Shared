using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using DSharpPlus.SlashCommands;
using System.Collections.Generic;
using Lavalink4NET.Players;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Shared.Interfaces
{
    /// <summary>
    /// Bot Interface For Bots Using Sharding
    /// </summary>
    public interface IShardBot
    {

        /// <summary>
        /// <see cref="DiscordShardedClient"/>
        /// </summary>
        DiscordShardedClient Client { get; set; }

        /// <summary>
        /// <see cref="DiscordRestClient"/>
        /// </summary>
        DiscordRestClient Rest { get; set; }

        /// <summary>
        ///<see cref="CommandsNextExtension"/>
        /// </summary>
        IReadOnlyDictionary<int, CommandsNextExtension> Commands { get; set;}
        /// <summary>
        /// <see cref="InteractivityExtension"/>
        /// </summary>
        IReadOnlyDictionary<int, InteractivityExtension> Interactivity { get; set; }

        /// <summary>
        /// <see cref="VoiceNextExtension"/>
        /// </summary>
        IReadOnlyDictionary<int, VoiceNextExtension> Voice { get; set; }

        /// <summary>
        /// <see cref="LavalinkPlayerOptions"/>
        /// </summary>
        IReadOnlyDictionary<int, LavalinkPlayerOptions> LavalinkPlayerOptions { get; set; }

        /// <summary>
        /// <see cref="SlashCommandsExtension"/>
        /// </summary>
        IReadOnlyDictionary<int, SlashCommandsExtension> SlashCommandsExt { get; set; }
    }

}
