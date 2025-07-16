namespace Polyv.SDK.Live.Abstractions.Values
{
    /// <summary>
    /// 回调设置
    /// </summary>
    public class ResponseCallbackSettingValue
    {
        /// <summary>
        /// 是否应用全局设置
        /// </summary>
        public string GlobalSettingEnabled { get; set; }
        /// <summary>
        /// 录播回调类型
        /// </summary>
        public string RecordCallbackVideoType { get; set; }
        /// <summary>
        /// 录播回调地址
        /// </summary>
        public string RecordCallbackUrl { get; set; }
        /// <summary>
        /// 转存成功回调地址
        /// </summary>
        public string PlaybackCallbackUrl { get; set; }
        /// <summary>
        /// 流状态回调地址
        /// </summary>
        public string StreamCallbackUrl { get; set; }
        /// <summary>
        /// 课件重制成功回调地址
        /// </summary>
        public string PPTRecordCallbackUrl { get; set; }
        /// <summary>
        /// 回放转存回调地址
        /// </summary>
        public string PlaybackCacheCallbackUrl { get; set; }
        /// <summary>
        /// 直播内容鉴别回调地址
        /// </summary>
        public string LiveScanCallbackUrl { get; set; }
    }
}
