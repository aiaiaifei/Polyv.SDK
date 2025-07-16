
namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 直播回放相关签名
    /// </summary>
    public class ChannelPlaybackSignValue
    {
        /// <summary>
        /// 频道信息签名
        /// </summary>
        public string ChannelInfoSign { get; set; }
        /// <summary>
        /// ApiToken签名
        /// </summary>
        public string ApiTokenSign { get; set; }
        /// <summary>
        /// ChatApi签名
        /// </summary>
        public string ChatApiSign { get; set; }
        /// <summary>
        /// LiveSdk签名
        /// </summary>
        public string LiveSdkSign { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp { get; set; }
    }
}
