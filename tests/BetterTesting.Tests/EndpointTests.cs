// Copyright (c) Daniel Crenna. All rights reserved.
// 
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, you can obtain one at http://mozilla.org/MPL/2.0/.

using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Xunit.Abstractions;

namespace BetterTesting.Tests
{
    /// <summary>
    ///     <see href="https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0" />
    /// </summary>
    public class EndpointTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public EndpointTests(ITestOutputHelper output, WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithTestLogging(output);
        }

        [Theory]
        [InlineData("/WeatherForecast")]
        public async Task Get_Route_Returns_Response(string url)
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions {AllowAutoRedirect = false});
            var response = await client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}