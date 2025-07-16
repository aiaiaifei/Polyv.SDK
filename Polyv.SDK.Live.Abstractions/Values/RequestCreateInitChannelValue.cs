using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 创建并初始化频道请求
    /// </summary>
    public class RequestCreateInitChannelValue
    {
        /// <summary>
        /// 频道基础信息
        /// </summary>
        [JsonPropertyName("basicSetting")]
        public ChannelBasicSettingValue BasicSetting { get; set; }

        /// <summary>
        /// 主要观看条件
        /// </summary>
        [JsonPropertyName("masterAuthSetting")]
        public RequestMasterAuthSettingValue MasterAuthSetting { get; set; }

        /// <summary>
        /// 回放设置
        /// </summary>
        [JsonPropertyName("playbackSetting")]
        public RequestPlaybackSettingValue PlaybackSetting { get; set; }
    }
}