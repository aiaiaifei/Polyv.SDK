namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    /// <summary>
    /// 回放视频信息
    /// </summary>
    public class ResponsePlaybackVideoValue
    {
        /// <summary>
        /// 直播系统生成的id （回放来源为回放列表或点播列表有值）
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// 点播视频videoPoolId （回放来源为回放列表或点播列表有值）
        /// </summary>
        public string VideoPoolId { get; set; }
        /// <summary>
        /// 回放视频转存前的暂存文件ID（回放来源为暂存时有值）
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 视频时长，格式为HH:mm:ss
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 视频名称
        /// </summary>
        public string Name { get; set; }
    }
}
