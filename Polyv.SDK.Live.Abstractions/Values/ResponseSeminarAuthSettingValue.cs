
namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 研讨会认证信息
    /// </summary>
    public class ResponseSeminarAuthSettingValue
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 观看条件等级
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        public string Enabled { get; set; }
        /// <summary>
        /// 认证类型
        /// </summary>
        public string AuthType { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色代码
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 独立授权Key
        /// </summary>
        public string DirectKey { get; set; }
    }
}
