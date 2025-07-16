
namespace Polyv.SDK.Live.Abstractions.Values
{
    public class RequestSeminarPasswordAuthSettingValue : RequestMasterAuthSettingValue
    {
        public RequestSeminarPasswordAuthSettingValue()
        {
            this.AuthType = AuthTypes.password.ToString();
        }
        /// <summary>
        /// 角色代码
        /// </summary>
        public string RoleCode { get; set; } = MeetRoles.attendee.ToString();
        /// <summary>
        /// SecretKey
        /// </summary>
        public string Password { get; set; }
    }
}
