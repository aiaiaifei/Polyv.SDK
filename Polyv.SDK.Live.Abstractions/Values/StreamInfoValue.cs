namespace Polyv.SDK.Live.Abstractions.Values
{
    public class StreamInfoValue
    {
        /// <summary>
        /// 推送的CDN节点IP地址
        /// </summary>
        public string DeployAddress { get; set; }
        /// <summary>
        /// 推流出口IP地址
        /// </summary>
        public string InAddress { get; set; }
        /// <summary>
        /// 流名
        /// </summary>
        public string StreamName { get; set; }
        /// <summary>
        /// 推流帧率
        /// </summary>
        public string Fps { get; set; }
        /// <summary>
        /// 推流丢帧率
        /// </summary>
        public string Lfr { get; set; }
        /// <summary>
        /// 推流码率，单位：bps
        /// </summary>
        public string InBandWidth { get; set; }
    }
}
