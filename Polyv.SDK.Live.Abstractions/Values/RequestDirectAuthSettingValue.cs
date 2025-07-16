using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values
{
    public class RequestDirectAuthSettingValue : RequestMasterAuthSettingValue
    {
        public RequestDirectAuthSettingValue()
        {
            this.AuthType = AuthTypes.direct.ToString();
        }
    
        /// <summary>
        /// SecretKey
        /// </summary>
        [StringLength(10)]
        [JsonPropertyName("directKey")]
        public string DirectKey { get; set; }
    }
}
