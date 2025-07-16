namespace Polyv.SDK.Live.Abstractions.Values
{
    public class UpdateChannelBasicSettingValue
    {
        /// <summary>
        /// 频道名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 频道密码
        /// </summary>
        public string ChannelPasswd { get; set; }
        /// <summary>
        /// 最大在线人数
        /// </summary>
        public int? MaxViewer { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long? StartTime { get; set; }
        /// <summary>
        /// 直播内容介绍
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 主持人
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 累计观看数
        /// </summary>
        public int? PageView { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int? Likes { get; set; }
        /// <summary>
        /// 是否限制最大连接人数
        /// </summary>
        public string MaxViewerRestrict { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 是否允许咨询提问
        /// </summary>
        public string ConsultingMenuEnabled { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 引导页开关
        /// </summary>
        public string SplashEnabled { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 是否增加转播关联
        /// </summary>
        public string Operation { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 引导图地址
        /// </summary>
        public string SplashImg { get; set; }
        /// <summary>
        /// 封面图地址
        /// </summary>
        public string CoverImg { get; set; }
        /// <summary>
        /// 连麦人数
        /// </summary>
        public int LinkMicLimit { get; set; } = -1;
        /// <summary>
        /// 接受转播频道号
        /// </summary>
        public string ReceiveChannelIds { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string CategoryId { get; set; }
    }
}
