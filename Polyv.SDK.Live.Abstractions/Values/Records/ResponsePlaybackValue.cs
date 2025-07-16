using System.Text.Json.Serialization;

namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    public class ResponsePlaybackValue
    {
        /// <summary>
        /// 视频Id
        /// </summary>
        public string VideoId { get; set; }
        /// <summary>
        /// 点播视频vid
        /// </summary>
        public string VideoPoolId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 直播频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频首图
        /// </summary>
        public string FirstImage { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 默认清晰度
        /// </summary>
        public string MyBr { get; set; }
        /// <summary>
        /// 访客信息收集Id
        /// </summary>
        [JsonPropertyName("qid")]
        public string GuestId { get; set; }
        /// <summary>
        /// 是否加密
        /// </summary>
        public int Seed { get; set; }
        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreatedTime { get; set; }
        /// <summary>
        /// 最后更新时间戳
        /// </summary>
        public long LastModified { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 是否为默认视频
        /// </summary>
        public string AsDefault { get; set; }
        /// <summary>
        /// 场次Id
        /// </summary>
        public string ChannelSessionId { get; set; }
        /// <summary>
        /// 文件Id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 可并信息
        /// </summary>
        public string MergeInfo { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 直播类型
        /// </summary>
        public string LiveType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 观看地址
        /// </summary>
        public string WatchUrl { get; set; }
    }
}