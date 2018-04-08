using Newtonsoft.Json;
using QuadrigaCX.Api.Utils;
using System.Collections.Generic;

namespace EzBtc.Api.Models
{
    /// <summary>
    /// Represents an order book consisting of <c>Bids</c> and <c>Asks</c>.
    /// </summary>
    public class OrderBook
    {
        /// <summary>
        /// A list of the top 50 open buy orders, sorted by rate descending.
        /// </summary>
        [JsonProperty("bids")]
        public List<OrderBookEntry> Bids { get; set; }

        /// <summary>
        /// A list of the top 50 open sell orders, sorted by rate ascending.
        /// </summary>
        [JsonProperty("asks")]
        public List<OrderBookEntry> Asks { get; set; }
    }

    /// <summary>
    /// Represents an entry in an <see cref="OrderBook"/>.
    /// </summary>
    [JsonConverter(typeof(JArrayToObjectConverter))]
    public class OrderBookEntry
    {
        /// <summary>
        /// The rate of an open order.
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// The amount of an open order.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
