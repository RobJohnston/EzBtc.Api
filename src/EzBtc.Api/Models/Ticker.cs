using Newtonsoft.Json;

namespace EzBtc.Api.Models
{
    /// <summary>
    /// Represents current trading information.
    /// </summary>
    public class Ticker
    {
        /// <summary>
        /// The volume in the past 24 hours.
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume;

        /// <summary>
        /// The last rate.
        /// </summary>
        [JsonProperty("last")]
        public decimal Last;

        /// <summary>
        /// The lowest rate in the past 24 hours.
        /// </summary>
        [JsonProperty("low")]
        public decimal Low;

        /// <summary>
        /// The highest rate in the past 24 hours.
        /// </summary>
        [JsonProperty("high")]
        public decimal High;
    }
}
