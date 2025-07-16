namespace Polyv.SDK.Live.Abstractions.Values
{
    public class RequestExternalAuthSettingValue : RequestMasterAuthSettingValue
    {
        public RequestExternalAuthSettingValue()
        {
            this.AuthType = AuthTypes.external.ToString();
        }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string ExternalKey { get; set; }
        /// <summary>
        /// 自定义Url
        /// </summary>
        public string ExternalUri { get; set; }
        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string ExternalRedirectUri { get; set; }
    }
}
