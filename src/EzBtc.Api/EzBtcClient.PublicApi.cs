using EzBtc.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzBtc.Api
{
    public partial class EzBtcClient
    {
        /// <summary>
        /// Get current trading information.
        /// </summary>
        /// <param name="pair">The currency pair to return the ticker for (optional).</param>
        /// <returns>
        /// Trading information from the specified <paramref name="pair"/>.
        /// </returns>
        public async Task<Ticker> GetTickerAsync(string pair = "xbtcad")
        {
            return await QueryPublicAsync<Ticker>(
                "ticker",
                new Dictionary<string, string>(1)
                {
                    ["pair"] = pair
                }
            );
        }

        /// <summary>
        /// Get open orders.
        /// </summary>
        /// <param name="pair">The currency pair to return the order book for (optional).</param>
        /// <returns>
        /// A list of <c>Bids</c> and <c>Asks</c> each containing the top 50 <see cref="OrderBookEntry"/>s 
        /// sorted by <c>Rate</c> (descending for bid, ascending for ask).
        /// </returns>
        public async Task<OrderBook> GetOrderBookAsync(string pair = "xbtcad")
        {
            return await QueryPublicAsync<OrderBook>(
                "order-book",
                new Dictionary<string, string>(1)
                {
                    ["pair"] = pair
                }
            );
        }

        /// <summary>
        /// Get completed trades.
        /// </summary>
        /// <param name="pair">The currency pair to return the ticker for (optional).</param>
        /// <returns>
        /// A list of the last 50 completed trades, sorted by the most recent trade first.
        /// </returns>
        public async Task<Transaction[]> GetTransactionsAsync(string pair = "xbtcad")
        {
            return await QueryPublicAsync<Transaction[]>(
                "transactions",
                new Dictionary<string, string>(1)
                {
                    ["pair"] = pair
                }
            );
        }
    }
}
