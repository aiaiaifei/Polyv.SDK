using System.ComponentModel.DataAnnotations;

namespace Polyv.SDK.Live.Abstractions.Values
{

    public class RequestChatTokenValue
    {
        /// <summary>
        /// 频道号
        /// </summary>
        [Required]
        [StringLength(50)]
        public int ChannelId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [Required]
        [StringLength(200)]
        public string UserId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        [StringLength(10)]
        [Required]
        public string Role { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Origin { get; set; }
    }

}
