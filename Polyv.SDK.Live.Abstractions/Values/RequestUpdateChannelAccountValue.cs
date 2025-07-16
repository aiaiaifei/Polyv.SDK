using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 修改角色
    /// </summary>
    public class RequestUpdateChannelAccountValue
    {
        /// <summary>
        /// 助教/嘉宾账号
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 角色头衔
        /// </summary>
        public string Actor { get; set; }

        /// <summary>
        /// 角色昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 角色头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [JsonPropertyName("passwd")]
        public string Password { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public IList<RequestCreateChannelAccountPurviewValue> PurviewList { get; set; }
    }
}