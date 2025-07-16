namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    /// <summary>
    /// 重置课件
    /// </summary>
    public class ResponsePPTRecordFileValue
    {
        /// <summary>
        /// 任务Id
        /// </summary>
        public int TaskId { get; set; }
        /// <summary>
        /// 频道Id
        /// </summary>
        public int ChannelId    { get; set; }
        /// <summary>
        /// 对应回放的名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 重制mp4下载地址，有24小时的防盗链超时时间
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 重制课件模块中的场次id
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 对应回放的直播开始时间，格式为yyyyMMddhhmmss
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 状态值
        /// waiting：等待处理
        //process：处理中
        //success：重制成功
        //fail：重制失败
        //uploaded：上传点播成功
        //uploadFailed：上传点播失败
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 重制剩余的过期时间，过期后将无法访问和下载
        /// </summary>
        public int RemainDay { get; set; }
        /// <summary>
        /// 重制的视频时长，单位秒
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 直播系统视频ID，如：992d36fa40
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// 重制课件上传到点播的点播视频VID
        /// </summary>
        public string Vid { get; set; }
    }
}
