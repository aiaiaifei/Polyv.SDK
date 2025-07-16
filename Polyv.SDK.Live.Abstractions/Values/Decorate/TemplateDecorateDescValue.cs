namespace Polyv.SDK.Live.Abstractions.Values.Decorate
{
    /// <summary>
    /// 装修中文直播介绍页对象
    /// </summary>
    public class TemplateDecorateDescValue
    {
        /// <summary>
        /// 暖场图片 -> 封面图片
        /// </summary>
        public string CoverImageUrl { get; set; }
        /// <summary>
        /// 图标URL
        /// </summary>
        public string  IconUrl { get; set;}
        /// <summary>
        /// 主持人名称
        /// </summary>
        public string Publisher { get; set; }
        /// <summary>
        /// 标题 -> 直播名称
        /// </summary>
        public string Title { get; set;}
    }
}
