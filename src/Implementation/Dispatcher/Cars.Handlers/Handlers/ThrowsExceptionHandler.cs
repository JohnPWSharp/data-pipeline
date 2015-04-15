// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Microsoft.Practices.DataPipeline.Cars.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.Practices.DataPipeline.Dispatcher;
    using Microsoft.Practices.DataPipeline.Logging;

    [MessageHandler(MessageType = "ThowsExceptionMessage", Version = 1)]
    public class ThrowsExceptionHandler : IMessageHandler
    {
        protected static readonly ILogger Logger = LoggerFactory.GetLogger("ThrowsExceptionHandler");

        public string Name
        {
            get
            {
                return "ThrowsExceptionHandler";
            }
        }

        public TimeSpan Timeout
        {
            get { return TimeSpan.FromSeconds(1); }
        }

        public Task ExecuteAsync(
            ProcessingContext context,
            byte[] payload, 
            IDictionary<string, string> properties)
        {
            Logger.Info("Intentionally throwing exception.");
            throw new JustForTestingException();
        }
    }

    public class JustForTestingException : Exception
    {
    }
}