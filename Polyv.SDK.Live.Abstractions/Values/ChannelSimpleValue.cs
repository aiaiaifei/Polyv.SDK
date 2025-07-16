namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 频道缩略信息
    /// </summary>
    public class ChannelSimpleValue
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
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }
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
    }
}
