using System.Text.Json;
using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    public class ChannelAccountValue
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 直播频道Id
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// 直播用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 直播流名称
        /// </summary>
        public string Stream { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [JsonPropertyName("passwd")]
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 头衔
        /// </summary>
        public string Actor { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 监播权限
        /// </summary>
        public string MonitorEnabled { get; set; }

        /// <summary>
        /// 翻页权限
        /// </summary>
        public string PageTurnEnabled { get; set; }

        /// <summary>
        /// 在线列表权限
        /// </summary>
        public string ChatListEnabled { get; set; }
    }
}