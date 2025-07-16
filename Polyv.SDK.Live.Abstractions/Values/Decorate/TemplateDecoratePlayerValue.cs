namespace Polyv.SDK.Live.Abstractions.Values.Decorate
{
    /// <summary>
    /// 装修播放器对象
    /// </summary>
    public class TemplateDecoratePlayerValue
    {
        /// <summary>
        /// 实际累计观看次数
        /// </summary>
        public int ActualPV { get; set; }
        /// <summary>
        /// PC背景图片
        /// </summary>
        public string BackgroundUrl { get; set; }
        /// <summary>
        /// 基础观看次数
        /// </summary>
        public int BasePV { get; set; }
        /// <summary>
        /// 封面(暖场)跳转链接
        /// </summary>
        public string CoverJumpUrl { get; set; }
        /// <summary>
        /// 水印链接
        /// </summary>
        public string IconLink { get; set; }
        /// <summary>
        /// 图标位置 (水印位置)
        /// </summary>
        public string IconPosition { get; set; }
        /// <summary>
        /// 水印图片URL
        /// </summary>
        public string IconUrl { get; set; }
        /// <summary>
        /// 水印不透明度
        /// </summary>
        public float LogoOpacity { get; set; }
        /// <summary>
        /// 暖场开关
        /// </summary>
        public string WarmUpEnabled { get; set; }
        /// <summary>
        /// 暖场图片地址 (直播封面图)
        /// </summary>
        public string WarmUpImageUrl { get; set; }
        /// <summary>
        /// 水印开关
        /// </summary>
        public string WatermarkEnabled { get; set; }
    }
}
