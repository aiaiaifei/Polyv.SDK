namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 创建频道请求
    /// </summary>
    public class RequestCreateChannelValue
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
        /// 直播延迟
        /// </summary>
        public string PureRtcEnabled { get; set; } = PolyvLiveConst.NO;

        /// <summary>
        /// 转播类型
        /// </summary>
        public string Type { get; set; } = TransmitTypes.normal.ToString();

        /// <summary>
        /// 线上双师
        /// </summary>
        public string DoubleTeacherType { get; set; } = DoubleTeacherTypes.receive.ToString();

        /// <summary>
        /// 中英双语直播开关
        /// </summary>
        public string CnAndEnLiveEnabled { get; set; } = PolyvLiveConst.NO;

        /// <summary>
        /// 封面图片地址
        /// </summary>
        public string SplashImg { get; set; }

        /// <summary>
        /// 连麦人数限制，最多16人
        /// </summary>
        public int LinkMicLimit { get; set; } = -1;

        /// <summary>
        /// 分类ID
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public long? StartTime { get; set; }

        /// <summary>
        /// 子账号邮箱
        /// </summary>
        public string SubAccount { get; set; }
    }
}