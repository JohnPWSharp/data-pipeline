// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
namespace Microsoft.Practices.DataPipeline.Dispatcher.Tests
{
    using Microsoft.Practices.DataPipeline.Dispatcher;

    using Xunit;

    public class GivenAMessageRegistration
    {
        [Fact]
        [Trait("Running time", "Short")]
        public void WhenTypeAndVersionMatch_ThenRegistrationsShouldBeEqual()
        {
            const string SharedType = "some type";
            const int SharedVersion = 99;

            var a = new MessageRegistration
                        {
                            Type = SharedType,
                            Version = SharedVersion
                        };
            var b = new MessageRegistration
                        {
                            Type = SharedType,
                            Version = SharedVersion
                        };

            Assert.True(a.Equals(b));
        }

        [Fact]
        [Trait("Running time", "Short")]
        public void WhenTypeDiffers_ThenRegistrationsShouldNotBeEqual()
        {
            const int SharedVersion = 99;

            var a = new MessageRegistration
            {
                Type = "first type",
                Version = SharedVersion
            };
            var b = new MessageRegistration
            {
                Type = "second type",
                Version = SharedVersion
            };

            Assert.False(a.Equals(b));
        }

        [Fact]
        [Trait("Running time", "Short")]
        public void WhenVersionsDiffer_ThenRegistrationsShouldBeEqual()
        {
            const string SharedType = "some type";

            var a = new MessageRegistration
            {
                Type = SharedType,
                Version = 1
            };
            var b = new MessageRegistration
            {
                Type = SharedType,
                Version = 2
            };

            Assert.False(a.Equals(b));
        }
    }
}