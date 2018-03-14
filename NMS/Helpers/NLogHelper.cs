// <copyright file="NLogHelper.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Helpers
{
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// An NLog helper
    /// </summary>
    public class NLogHelper
    {
        private readonly ILogger<NLogHelper> logger;

        /// <summary>
        /// Initialises a new instance of the <see cref="NLogHelper"/> class
        /// </summary>
        /// <param name="logger">An injected version of an <see cref="ILogger"/></param>
        public NLogHelper(ILogger<NLogHelper> logger = null)
        {
            if (logger != null)
            {
                this.logger = logger;
            }
        }

        /// <summary>
        /// Gets an instance of a logger
        /// </summary>
        protected ILogger<NLogHelper> Logger => this.logger;
    }
}
