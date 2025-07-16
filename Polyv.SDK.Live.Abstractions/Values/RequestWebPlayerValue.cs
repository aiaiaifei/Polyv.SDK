using System.ComponentModel.DataAnnotations;

namespace Polyv.SDK.Live.Abstractions.Values
{

    public class RequestWebPlayerValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        [Required]
        public int ChannelId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        [Required]
        public string Pic { get; set; }
    }
}
