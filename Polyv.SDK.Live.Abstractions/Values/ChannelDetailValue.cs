using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 频道详情信息
    /// </summary>
    public class ChannelDetailValue
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
        /// 频道密码
        /// </summary>
        public string ChannelPasswd { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string CategoryId { get; set; }
        /// <summary>
        /// 直播场景
        /// </summary>
        public string Scene { get; set; }
        /// <summary>
        /// 观看页状态
        /// </summary>
        public string WatchStatus { get; set; }
        /// <summary>
        /// 观看页状态描述
        /// </summary>
        public string WatchStatusText { get; set; }
        /// <summary>
        /// 场景描述
        /// </summary>
        public string SceneText { get; set; }
        /// <summary>
        /// 观看页链接
        /// </summary>
        public string WatchUrl { get; set; }
        /// <summary>
        /// 直播介绍
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long StartTime { get; set; }
        /// <summary>
        /// 频道图标
        /// </summary>
        public string ChannelLogo { get; set; }
        /// <summary>
        /// 引导页封面图片
        /// </summary>
        public string SplashImg { get; set; }
        /// <summary>
        /// 引导页开关
        /// </summary>
        public string SplashEnabled { get; set; }
        /// <summary>
        /// 主持人名称
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 观看条件设置
        /// </summary>
        public IList<ResponseAuthSettingValue> AuthSetting { get; set; }
    }
}
