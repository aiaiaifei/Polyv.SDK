namespace Polyv.SDK.Live.Abstractions
{
    public class PolyvSetting
    {
        /// <summary>
        /// APPId
        /// </summary>
        public string APPId { get; set; }

        /// <summary>
        /// 直播用户Id
        /// </summary>
        public string LiveUserId { get; set; }

        /// <summary>
        /// 直播密钥
        /// </summary>
        public string LiveAppSecret { get; set; }

        /// <summary>
        /// 默认管理地址
        /// </summary>
        public string DefaultManageUrl { get; set; }

        /// <summary>
        /// 管理地址
        /// </summary>
        public string ManageUrl { get; set; }

        /// <summary>
        /// 默认直播界面地址
        /// </summary>
        public string DefaultLiveUrl { get; set; } = "https://live.polyv.cn/";

        /// <summary>
        /// 默认Web开播地址
        /// </summary>
        public string DefaultWebStartUrl { get; set; } = "https://live.polyv.net/";

        /// <summary>
        /// Web开播地址
        /// </summary>
        public string WebStartUrl { get; set; } = "https://live.polyv.net/";

        /// <summary>
        /// 直播界面地址
        /// </summary>
        public string LiveUrl { get; set; }

        /// <summary>
        /// API跟路径
        /// </summary>
        public string BaseUrl { get; set; } = "http://api.polyv.net/";
    }
}