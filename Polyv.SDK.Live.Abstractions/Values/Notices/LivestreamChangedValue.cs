using System.ComponentModel.DataAnnotations;

namespace Polyv.SDK.Live.Abstractions.Values.Notices
{
    /// <summary>
    /// 直播状态改变
    /// </summary>
    public class LiveStreamChangedValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [Required]
        public int ChannelId { get; set; }
        /// <summary>
        /// 直播频道的状态
        /// live：正在直播
        /// end：直播结束
        /// seminar_live（研讨会频道，直播开启）
        /// seminar_end（研讨会频道，直播结束）
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
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
        /// <summary>
        /// 场次Id
        /// </summary>
        [Required]
        public string SessionId { get; set; }
        /// <summary>
        /// 直播的开始时间
        /// </summary>
        [Required]
        public long StartTime { get; set; }
        /// <summary>
        /// 直播的结束时间
        /// </summary>
        [Required]
        public long EndTime { get; set; }
    }
}
