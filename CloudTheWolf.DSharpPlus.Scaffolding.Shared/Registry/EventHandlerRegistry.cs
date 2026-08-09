using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using CloudTheWolf.DSharpPlus.Scaffolding.Logging;
using Microsoft.Extensions.Logging;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Worker.Registry
{
    /// <summary>
    /// Registry of Event Handlers (<see cref="EventHandlingBuilder"/>)
    /// </summary>
    public class EventHandlerRegistry : IEventHandlerRegistry
    {
        private readonly object _syncRoot = new();
        private readonly List<(string Name, Action<EventHandlingBuilder> Contribution)> _contributions = [];
        private bool _isSealed;

        /// <inheritdoc />
        public int Count
        {
            get
            {
                lock (_syncRoot)
                {
                    return _contributions.Count;
                }
            }
        }

        /// <inheritdoc />
        public bool IsSealed
        {
            get
            {
                lock (_syncRoot)
                {
                    return _isSealed;
                }
            }
        }

        /// <inheritdoc />
        public IReadOnlyList<string> RegistrationNames
        {
            get
            {
                lock (_syncRoot)
                {
                    return _contributions.Select(item => item.Name).ToArray();
                }
            }
        }

        /// <summary>
        /// Register an Event Handler
        /// </summary>
        /// <param name="contribution"></param>
        public void Register(Action<EventHandlingBuilder> contribution)
        {
            ArgumentNullException.ThrowIfNull(contribution);
            Register($"anonymous:{Guid.NewGuid():N}", contribution);
        }

        /// <inheritdoc />
        public void Register(string name, Action<EventHandlingBuilder> contribution)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentNullException.ThrowIfNull(contribution);

            lock (_syncRoot)
            {
                ThrowIfSealed();
                if (_contributions.Any(item =>
                        string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new InvalidOperationException(
                        $"An event-handler contribution named '{name}' is already registered.");
                }

                _contributions.Add((name, contribution));
                Logger.Log.LogDebug(
                    "Registered DSharpPlus event-handler contribution {EventHandlerName}; total contributions: {ContributionCount}",
                    name, _contributions.Count);
            }
        }

        /// <inheritdoc />
        public bool Unregister(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);

            lock (_syncRoot)
            {
                ThrowIfSealed();
                var index = _contributions.FindIndex(item =>
                    string.Equals(item.Name, name, StringComparison.OrdinalIgnoreCase));
                if (index < 0)
                {
                    return false;
                }

                _contributions.RemoveAt(index);
                Logger.Log.LogDebug(
                    "Unregistered DSharpPlus event-handler contribution {EventHandlerName}; total contributions: {ContributionCount}",
                    name, _contributions.Count);
                return true;
            }
        }

        /// <summary>
        /// Configure All Event Handlers
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureAll(EventHandlingBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            (string Name, Action<EventHandlingBuilder> Contribution)[] contributions;
            lock (_syncRoot)
            {
                if (_isSealed)
                {
                    throw new InvalidOperationException("Event handlers have already been configured.");
                }

                _isSealed = true;
                contributions = _contributions.ToArray();
            }

            Logger.Log.LogDebug("Configuring {ContributionCount} DSharpPlus event-handler contributions",
                contributions.Length);

            foreach (var (name, contribution) in contributions)
            {
                try
                {
                    contribution(builder);
                }
                catch (Exception exception)
                {
                    Logger.Log.LogError(exception,
                        "Failed to configure DSharpPlus event-handler contribution {EventHandlerName}", name);
                    throw;
                }
            }
        }

        private void ThrowIfSealed()
        {
            if (_isSealed)
            {
                throw new InvalidOperationException(
                    "Event-handler registrations cannot change after the Discord client is configured.");
            }
        }
    }
}
