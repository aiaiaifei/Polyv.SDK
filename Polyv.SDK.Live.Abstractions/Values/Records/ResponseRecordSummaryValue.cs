namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    public class ResponseRecordSummaryValue
    {
        /// <summary>
        /// 文件Id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 直播频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 文件尺寸
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public long Duration { get; set; }
        /// <summary>
        /// 码率
        /// </summary>
        public long Bitrate { get; set; }
        /// <summary>
        /// 分辨率
        /// </summary>
        public string Resolution { get; set; }
        /// <summary>
        /// 场次Id
        /// </summary>
        public string ChannelSessionId { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }

}


