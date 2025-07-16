namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 频道基础信息
    /// </summary>
    public class ChannelBasicSettingValue
    {
        /// <summary>
        /// 直播名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 直播场景
        /// </summary>
        public string NewScene { get; set; } = SceneTypes.topclass.ToString();
        /// <summary>
        /// 直播模板
        /// </summary>
        public string Template { get; set; } = TemplateTypes.ppt.ToString();
        /// <summary>
        /// 讲师登录密码，直播场景不是研讨会时有效
        /// </summary>
        public string ChannelPasswd { get; set; }
        /// <summary>
        /// 研讨会主持人密码
        /// </summary>
        public string SeminarHostPassword { get; set; }
        /// <summary>
        /// 研讨会参会人密码，仅直播场景是研讨会时有效
        /// </summary>
        public string SeminarAttendeePassword { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long? StartTime { get; set; }
        /// <summary>
        /// 是否为无延迟直播
        /// </summary>
        public string PureRtcEnabled { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 转播类型
        /// </summary>
        public string Type { get; set; } = TransmitTypes.normal.ToString();
        /// <summary>
        /// 线上双师
        /// </summary>
        public string DoubleTeacherType { get; set; }
        /// <summary>
        /// 中英双语直播开关
        /// </summary>
        public string CnAndEnLiveEnabled { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 连麦人数限制，最多16人
        /// </summary>
        public int LinkMicLimit { get; set; } = -1;
        /// <summary>
        /// 直播介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 直播logo图片
        /// </summary>
        public string LogoImg { get; set; }
        /// <summary>
        /// 引导页封面图片
        /// </summary>
        public string SplashImg { get; set; }
        /// <summary>
        /// 播放器封面图片
        /// </summary>
        public string CoverImg { get; set; }
        /// <summary>
        /// 子账号邮箱
        /// </summary>
        public string SubAccount { get; set; }
        /// <summary>
        /// 自定义讲师ID
        /// </summary>
        public string CustomTeacherId { get; set; }
    }
}
