namespace Polyv.SDK.Live.Abstractions.Values
{
    public class ResponseWebPlayerValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// APPId
        /// </summary>
        public string APPId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Pic { get; set; }
    }
}
