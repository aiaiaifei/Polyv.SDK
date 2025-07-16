using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 创建角色
    /// </summary>
    public class RequestCreateChannelAccountValue
    {
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 头衔
        /// </summary>
        public string Actor { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像
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
