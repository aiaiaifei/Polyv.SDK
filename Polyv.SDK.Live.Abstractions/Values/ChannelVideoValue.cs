namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 回放视频
    /// </summary>
    public class ChannelVideoValue
    {
        /// <summary>
        /// 直播系统生成的id
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// 点播视频vid
        /// </summary>
        public string VideoPoolId { get; set; }
    }
}
