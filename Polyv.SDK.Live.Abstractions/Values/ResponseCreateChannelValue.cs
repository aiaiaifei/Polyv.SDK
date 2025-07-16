namespace Polyv.SDK.Live.Abstractions.Values
{
    public class ResponseCreateChannelValue
    {
        /// <summary>
        /// 频道ID
        /// </summary>
        public int ChannelId { get; set; }
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
    }
}
