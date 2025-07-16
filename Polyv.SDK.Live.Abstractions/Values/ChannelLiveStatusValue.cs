namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 直播状态
    /// </summary>
    public class ChannelLiveStatusValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        public long ChannelId { get; set; }
        /// <summary>
        /// 直播状态
        /// </summary>
        public string LiveStatus { get; set; }
    }
}
