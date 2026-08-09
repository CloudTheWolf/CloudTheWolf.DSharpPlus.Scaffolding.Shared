using System;
using System.Collections.Generic;
using CloudTheWolf.DSharpPlus.Scaffolding.Worker.Registry;
using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Trees;
using Lavalink4NET.Players;
using System.Linq;

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

        /// <summary>
        /// Event-handler registrations exposed through an abstraction suitable for plugins.
        /// </summary>
        IEventHandlerRegistry EventHandlers => EventHandlerRegistry;

        /// <summary>Commands currently registered with the bot.</summary>
        IReadOnlyList<CommandBuilder> RegisteredCommands => CommandsList;

        /// <summary>Adds a command and rejects duplicate command names.</summary>
        void RegisterCommand(CommandBuilder command)
        {
            ArgumentNullException.ThrowIfNull(command);

            if (CommandsList.Any(existing =>
                    string.Equals(existing.Name, command.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"A command named '{command.Name}' is already registered.");
            }

            CommandsList.Add(command);
        }

        /// <summary>Adds a uniquely named event-handler contribution.</summary>
        void RegisterEventHandlers(string name, Action<EventHandlingBuilder> contribution)
        {
            EventHandlers.Register(name, contribution);
        }

    }

}
