namespace Polyv.SDK.Live.Abstractions.Values.Records
{

    public class ResponseRecordFileValue
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
        /// M3U8地址
        /// </summary>
        public string M3U8 { get; set; }
        /// <summary>
        /// MP4地址
        /// </summary>
        public string MP4 { get; set; }
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
        /// 视频高
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 视频宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 场次Id
        /// </summary>
        public string ChannelSessionId { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 直播类型
        /// </summary>
        public string LiveType { get; set; }
        /// <summary>
        /// 录播创建时间
        /// </summary>
        public long CreatedTime { get; set; }
    }
}