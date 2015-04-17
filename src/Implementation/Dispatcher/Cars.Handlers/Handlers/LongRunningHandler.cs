// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Microsoft.Practices.DataPipeline.Cars.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Practices.DataPipeline.Dispatcher;
    using Microsoft.Practices.DataPipeline.Logging;

    [MessageHandler(MessageType = "LongRunningMessage", Version = 1)]
    public class LongRunningHandler : IMessageHandler
    {
        private readonly TimeSpan _duration;

        protected static readonly ILogger Logger = LoggerFactory.GetLogger("LongRunningHandler");

        public string Name
        {
            get
            {
                return "LongRunningHandler";
            }
        }

        public TimeSpan Timeout
        {
            get { return TimeSpan.FromSeconds(1); }
        }

        public LongRunningHandler(TimeSpan duration)
        {
            _duration = duration;
        }

        public async Task ExecuteAsync(
            ProcessingContext context, 
            byte[] payload,
            IDictionary<string, string> properties)
        {
            Logger.Info("Long running handler for {0}", _duration);
            await Task.Delay(_duration);
        }
    }
}