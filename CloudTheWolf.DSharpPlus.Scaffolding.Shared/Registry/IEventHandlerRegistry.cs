using System;
using System.Collections.Generic;
using DSharpPlus;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Worker.Registry
{
    /// <summary>Collects named DSharpPlus event-handler contributions before client startup.</summary>
    public interface IEventHandlerRegistry
    {
        /// <summary>The number of registered contributions.</summary>
        int Count { get; }

        /// <summary>
        /// Indicates whether the registry has been applied and can no longer be changed.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>Names of contributions in registration order.</summary>
        IReadOnlyList<string> RegistrationNames { get; }

        /// <summary>Registers a uniquely named event-handler contribution.</summary>
        /// <exception cref="InvalidOperationException">
        /// The registry is sealed or the name has already been registered.
        /// </exception>
        void Register(string name, Action<EventHandlingBuilder> contribution);

        /// <summary>Removes a named contribution before the registry is sealed.</summary>
        bool Unregister(string name);

        /// <summary>Applies all contributions in registration order and seals the registry.</summary>
        void ConfigureAll(EventHandlingBuilder builder);
    }
}
