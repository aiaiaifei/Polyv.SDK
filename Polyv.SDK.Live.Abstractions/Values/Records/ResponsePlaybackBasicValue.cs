using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    /// <summary>
    /// 频道回放基础信息
    /// </summary>
    public class ResponsePlaybackBasicValue
    {
        /// <summary>
        /// 频道号
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 观看回放功能开关 Y：开启 N：关闭
        /// </summary>
        public string PlayBackEnabled { get; set; }
        /// <summary>
        /// 回放来源 record：暂存 playback：回放列表 vod：点播列表
        /// </summary>
        public string Origin { get; set; }
        /// <summary>
        /// 回放方式 single：单个视频回放 list：列表回放
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 视频列表
        /// </summary>
        public IList<ResponsePlaybackVideoValue> VideoList { get; set; }
        /// <summary>
        /// 是否开启全局设置 Y：开启 N：关闭
        /// </summary>
        public string GlobalSettingEnabled { get; set; }
        
    }
}
