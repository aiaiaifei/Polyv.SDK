namespace Polyv.SDK.Live.Abstractions.Values
{
    public class RequestSeminarDirectAuthSettingValue : RequestMasterAuthSettingValue
    {
        public RequestSeminarDirectAuthSettingValue()
        {
            this.AuthType = AuthTypes.direct.ToString();
        }
        /// <summary>
        /// 角色代码
        /// </summary>
        public string RoleCode { get; set; } = MeetRoles.attendee.ToString();
        /// <summary>
        /// SecretKey
        /// </summary>
        public string DirectKey { get; set; }
    }
}
