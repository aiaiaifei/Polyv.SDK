using System.ComponentModel.DataAnnotations;

namespace Polyv.SDK.Live.Abstractions.Values.Notices
{

    public class RecordNoticeValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [Required]
        public int ChannelId { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        [Required]
        [StringLength(256)]
        public string FileUrl { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        [Required]
        [StringLength(10)]
        public string Format { get; set; } = RecordFormats.mp4.ToString();
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
        /// 文件Id
        /// </summary>
        [Required]
        [StringLength(128)]
        public string FileId { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Origin { get; set; }
        /// <summary>
        /// 是否开启云录制
        /// </summary>
        [Required]
        [StringLength(10)]
        public string HasRtcRecord { get; set; } = PolyvLiveConst.NO;
    }
}
