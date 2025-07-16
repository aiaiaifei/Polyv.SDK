using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 设置研讨会认证
    /// </summary>
    public class RequestSeminarAuthSettingValue
    {
        /// <summary>
        /// 认证设置
        /// </summary>
        public IList<RequestMasterAuthSettingValue> AuthSettings { get; set; } = new List<RequestMasterAuthSettingValue>();
    }
}