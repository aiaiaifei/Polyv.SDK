using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    [JsonDerivedType(typeof(RequestDirectAuthSettingValue), typeDiscriminator: "direct")]
    [JsonDerivedType(typeof(RequestCustomAuthSettingValue), typeDiscriminator: "custom")]
    [JsonDerivedType(typeof(RequestExternalAuthSettingValue), typeDiscriminator: "external")]
    [JsonDerivedType(typeof(RequestSeminarDirectAuthSettingValue), typeDiscriminator: "seminarDirect")]
    [JsonDerivedType(typeof(RequestSeminarPasswordAuthSettingValue), typeDiscriminator: "seminarPassword")]
    public abstract class RequestMasterAuthSettingValue
    {
        /// <summary>
        /// 是否开启
        /// </summary>
        public string Enabled { get; set; } = PolyvLiveConst.YES;
        /// <summary>
        /// 认证类型
        /// </summary>
        public string AuthType { get; set; }
    }
}
