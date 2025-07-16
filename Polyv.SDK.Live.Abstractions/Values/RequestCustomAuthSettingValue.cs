namespace Polyv.SDK.Live.Abstractions.Values
{
    public class RequestCustomAuthSettingValue : RequestMasterAuthSettingValue
    {
        public RequestCustomAuthSettingValue()
        {
            this.AuthType = AuthTypes.custom.ToString();
        }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string CustomKey { get; set; }
        /// <summary>
        /// 自定义url
        /// </summary>
        public string CustomUri { get; set; }
    }
}
