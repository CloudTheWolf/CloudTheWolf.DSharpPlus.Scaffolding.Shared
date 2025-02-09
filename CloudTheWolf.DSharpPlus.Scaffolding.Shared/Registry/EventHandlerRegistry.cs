using DSharpPlus;
using System;
using System.Collections.Generic;

namespace CloudTheWolf.DSharpPlus.Scaffolding.Worker.Registry
{
    public class EventHandlerRegistry
    {
        private static readonly List<Action<EventHandlingBuilder>> _contributions = [];

        /// <summary>
        /// Register an Event Handler
        /// </summary>
        /// <param name="contribution"></param>
        public void Register(Action<EventHandlingBuilder> contribution)
        {
            _contributions.Add(contribution);
        }

        /// <summary>
        /// Configure All Event Handlers
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureAll(EventHandlingBuilder builder)
        {
            foreach (var contribution in _contributions)
            {
                contribution(builder);
            }
        }
    }
}