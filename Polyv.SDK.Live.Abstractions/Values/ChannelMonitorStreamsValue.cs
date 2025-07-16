namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 批量查询频道直播流信息
    /// </summary>
    public class ChannelMonitorStreamsValue
    {
        /// <summary>
        /// 频道号
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 频道是否直播中
        /// true：直播中
        /// false：未直播
        /// </summary>
        public bool Live { get; set; }
        /// <summary>
        /// 频道推流信息，直播中才有值，未直播时为null
        /// </summary>
        public StreamInfoValue StreamInfo { get; set; }
    }
}
