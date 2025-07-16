namespace Polyv.SDK.Live.Abstractions.Values
{
    public class ResponseCreateInitChannelValue
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 直播名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// POLYV用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 讲师登录密码
        /// </summary>
        public string ChannelPasswd { get; set; }
        /// <summary>
        /// 研讨会主持人密码
        /// </summary>
        public string SeminarHostPassword { get; set; }
        /// <summary>
        /// 研讨会参会人密码
        /// </summary>
        public string SeminarAttendeePassword { get; set; }
        /// <summary>
        /// 主持人名称
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 直播介绍
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 直播场景
        /// </summary>
        public string NewScene { get; set; }
        /// <summary>
        /// 直播模板
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// 连麦人数
        /// </summary>
        public int LinkMicLimit { get; set; }
        /// <summary>
        /// 直播延迟
        /// </summary>
        public string PureRtcEnabled { get; set; }
        /// <summary>
        /// 转播类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 当前13位毫秒级时间戳
        /// </summary>
        public long CurrentTimeMillis { get; set; }
    }
}
