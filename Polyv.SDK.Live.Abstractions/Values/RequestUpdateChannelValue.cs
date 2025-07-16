using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 创建频道请求
    /// </summary>
    /// <typeparam name="TAuth"></typeparam>
    public class RequestUpdateChannelValue
    {
        /// <summary>
        /// 频道基本设置
        /// </summary>
        public UpdateChannelBasicSettingValue BasicSetting { get; set; }
        /// <summary>
        /// 观看条件设置
        /// </summary>
        public IList<RequestAuthSettingValue> AuthSettings { get; set; } = new List<RequestAuthSettingValue>();
    }
}
