using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 频道基础信息
    /// </summary>
    public class ChannelBasicValue
    {
        /// <summary>
        /// 直播频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 直播频道名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 主持人名称
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long StartTime { get; set; }
        /// <summary>
        /// 页面累计观看数
        /// </summary>
        public int PageView { get; set; }
        /// <summary>
        /// 观看页点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 播放器封面图片
        /// </summary>
        public string CoverImg { get; set; }
        /// <summary>
        /// 引导页封面图片
        /// </summary>
        public string SplashImg { get; set; }
        /// <summary>
        /// 引导页开关
        /// </summary>
        public string SplashEnabled { get; set; }
        /// <summary>
        /// 直播介绍
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 最大在线观看人数
        /// </summary>
        public int MaxViewer { get; set; }
        /// <summary>
        /// 观看页状态
        /// </summary>
        public string WatchStatus { get; set; }
        /// <summary>
        /// 观看页状态描述
        /// </summary>
        public string WatchStatusText { get; set; }
        /// <summary>
        /// 在线人数
        /// </summary>
        public int OnlineNum { get; set; }
        /// <summary>
        /// 暖场图片URL
        /// </summary>
        public string BgImg { get; set; }
        /// <summary>
        /// 回放视频列表
        /// </summary>
        public IList<ChannelVideoValue> VideoList { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public string CategoryId { get; set; }
    }
}
