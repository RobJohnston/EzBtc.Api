﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EzBtc.Api
{
    public partial class EzBtcClient : IDisposable
    {
        private string _url;
        private readonly HttpClient _httpClient = new HttpClient();

        internal static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EzBtcClient"/> class.
        /// </summary>
        public EzBtcClient()
        {
            _url = "https://www.ezbtc.ca/api";
            _httpClient.BaseAddress = new Uri(_url);
        }

        #endregion

        /// <summary>
        /// Sends a public GET request to the ezBtc API as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T">Type of data contained in the response.</typeparam>
        /// <param name="requestUrl">The relative URL the request is sent to.</param>
        /// <param name="args">Optional arguments passed as querystring parameters.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <remarks>The <paramref name="requestUrl"/> is relative to https://www.ezbtc.ca/api/</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="requestUrl"/> is <c>null</c>.</exception>
        /// <exception cref="HttpRequestException">There was a problem with the HTTP request.</exception>
        public async Task<T> QueryPublicAsync<T>(string requestUrl, Dictionary<string, string> args = null)
        {
            if (requestUrl == null)
                throw new ArgumentNullException(nameof(requestUrl));

            args = args ?? new Dictionary<string, string>(0);

            // Setup request.
            var urlEncodedArgs = UrlEncode(args);

            var address = string.Format("{0}/{1}?{2}", _url, requestUrl, urlEncodedArgs);

            var req = new HttpRequestMessage(HttpMethod.Get, address);

            // Send request and deserialize response.
            return await SendRequestAsync<T>(req).ConfigureAwait(false);
        }

        /// <summary>
        /// Releases the unmanaged resources and disposes of the managed resources used by the
        /// underlying <see cref="HttpClient"/>.
        /// </summary>
        public void Dispose() => _httpClient.Dispose();

        #region Private methods

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage req)
        {
            var reqCtx = new RequestContext
            {
                HttpRequest = req
            };

            // Perform the HTTP request.
            var res = await _httpClient.SendAsync(reqCtx.HttpRequest).ConfigureAwait(false);

            var resCtx = new ResponseContext
            {
                HttpResponse = res
            };

            // Throw for HTTP-level error.
            resCtx.HttpResponse.EnsureSuccessStatusCode();

            // Get the response.
            var jsonContent = await resCtx.HttpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            Debug.WriteLine(req);
            Debug.WriteLine(res);
            Debug.WriteLine(jsonContent);

            // Deserialize the response.
            var response = JsonConvert.DeserializeObject<T>(jsonContent, JsonSettings);

            return response;
        }

        private static string UrlEncode(Dictionary<string, string> args) => string.Join(
            "&",
            args.Where(x => x.Value != null).Select(x => x.Key + "=" + WebUtility.UrlEncode(x.Value))
        );

        #endregion
    }
}