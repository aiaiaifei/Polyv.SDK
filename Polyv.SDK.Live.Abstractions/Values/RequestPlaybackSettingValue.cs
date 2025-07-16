namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 回放设置
    /// </summary>
    public class RequestPlaybackSettingValue
    {
        /// <summary>
        /// 回放开关 
        /// Y：开启  N：关闭
        /// </summary>
        public string PlaybackEnabled { get; set; } = PolyvLiveConst.YES;

        /// <summary>
        /// 回放设置，章节开关，Y:开启，N:关闭
        /// </summary>
        public string SectionEnabled { get; set; } = PolyvLiveConst.YES;

        /// <summary>
        /// 回放方式 single：单个回放 list：列表回放
        /// </summary>
        public string Type { get; set; } = PlaybackTypes.list.ToString();

        /// <summary>
        /// 回放来源
        /// record：暂存 playback：回放列表 vod：点播列表
        /// </summary>
        public string Origin { get; set; } = PlaybackOrigins.vod.ToString();
    }
}