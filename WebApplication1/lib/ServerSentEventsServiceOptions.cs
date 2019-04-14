﻿using System;

namespace Lib.AspNetCore.ServerSentEvents
{
    /// <summary>
    /// Options for <see cref="ServerSentEventsService"/>.
    /// <typeparam name="TServerSentEventsService">The type of <see cref="ServerSentEventsService"/> for which the options will be used.</typeparam>
    /// </summary>
    public class ServerSentEventsServiceOptions<TServerSentEventsService> where TServerSentEventsService : ServerSentEventsService
    {
        internal const int DEFAULT_KEEPALIVE_INTERVAL = 30;

        private int _keepaliveInterval = DEFAULT_KEEPALIVE_INTERVAL;

        /// <summary>
        /// Gets or sets the keepalive sending mode.
        /// </summary>
        public ServerSentEventsKeepaliveMode KeepaliveMode { get; set; } = ServerSentEventsKeepaliveMode.BehindAncm;

        /// <summary>
        /// Gets or sets the keepalive interval (in seconds).
        /// </summary>
        public int KeepaliveInterval
        {
            get { return _keepaliveInterval; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _keepaliveInterval = value;
            }
        }
    }
}
