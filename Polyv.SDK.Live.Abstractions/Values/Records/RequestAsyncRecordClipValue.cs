namespace Polyv.SDK.Live.Abstractions.Values.Records
{
    /// <summary>
    /// 创建异步视频裁剪请求
    /// </summary>
    public class RequestAsyncRecordClipValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// 文件Id
        /// </summary>
        public string FileId { get; set; }
        /// <summary>
        /// 删除时间区间
        /// </summary>
        public string DeleteTimeFrame { get; set; }
        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallbackUrl { get; set; }
        /// <summary>
        /// 是否自动转存
        /// </summary>
        public string AutoConvert { get; set; }
        /// <summary>
        /// 裁剪后的文件名
        /// </summary>
        public string FileName { get; set; }
    }

}
