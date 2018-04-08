using Newtonsoft.Json;

namespace EzBtc.Api.Models
{
    /// <summary>
    /// Represents a completed trade.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// A unique identifier for the trade.
        /// </summary>
        [JsonProperty("trade_id")]
        public int TradeId { get; set; }

        /// <summary>
        /// Unix timestamp.
        /// </summary>
        [JsonProperty("timestamp")]
        public double Timestamp { get; set; }

        /// <summary>
        /// Either "buy" or "sell", indicating the type of the taker order.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The amount of XBT executed.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The rate per XBT.
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// The pair that was traded.
        /// </summary>
        [JsonProperty("pair")]
        public string Pair { get; set; }
    }
}
