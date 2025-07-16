namespace Polyv.SDK.Live.Abstractions.Values
{
    public abstract class RequestAuthSettingValue
    {
        /// <summary>
        /// 观看条件等级
        /// </summary>
        public int Rank { get; set; } = 1;
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