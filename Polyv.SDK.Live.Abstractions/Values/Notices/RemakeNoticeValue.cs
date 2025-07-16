using System.ComponentModel.DataAnnotations;

namespace Polyv.SDK.Live.Abstractions.Values.Notices
{

    public class RemakeNoticeValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [Required]
        public int ChannelId { get; set; }
        /// <summary>
        /// 重制标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// 回放开始时间
        /// </summary>
        [Required]
        public string StartTime { get; set; }
        /// <summary>
        /// 时长（秒）
        /// </summary>
        [Required]
        public int Duration { get; set; }
        /// <summary>
        /// 剩余有效期
        /// </summary>
        [Required]
        public string RemainDay { get; set; }
        /// <summary>
        /// 场次Id
        /// </summary>
        [Required]
        public string SessionId { get; set; }
        /// <summary>
        /// 重制视频下载地址
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// 生成时间戳
        /// </summary>
        [Required]
        public long Timestamp { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Sign { get; set; }
    }
}
