namespace Polyv.SDK.Live.Abstractions.Values
{
    public class ChannelSettingValue
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
        /// 直播场景 
        /// </summary>
        public string Scene { get; set; }
        /// <summary>
        /// 新版直播后台场景
        /// </summary>
        public string NewScene { get; set; }
        /// <summary>
        /// 新版直播后台模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 主持人名称
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long? StartTime { get; set; }
        /// <summary>
        /// 页面累计观看数
        /// </summary>
        public string PageView { get; set; }
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
        /// 暖场图片URL
        /// </summary>
        public string BgImg { get; set; }
        /// <summary>
        /// 直播内容介绍
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 咨询提问开关
        /// </summary>
        public string ConsultingMenuEnabled { get; set; }
        /// <summary>
        /// 限制最大在线观看人数开关
        /// </summary>
        public string MaxViewerRestrict { get; set; }
        /// <summary>
        /// 最大在线观看人数
        /// </summary>
        public string MaxViewer { get; set; }
        /// <summary>
        /// 观看页状态
        /// </summary>
        public string WatchStatus { get; set; }
        /// <summary>
        /// 观看页状态描述
        /// </summary>
        public string WatchStatusText { get; set; }
        ///// <summary>
        ///// 频道所属分类的信息
        ///// </summary>
        //public UserCategoryValue UserCategory { get; set; }
        ///// <summary>
        ///// 直播观看条件列表
        ///// </summary>
        //public IList<RequestAuthSettingValue> AuthSettings { get; set; }
    }
}
