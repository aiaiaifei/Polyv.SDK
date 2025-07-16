namespace Polyv.SDK.Live.Abstractions.Values.Decorate
{
    /// <summary>
    /// 装修里聊天对象
    /// </summary>
    public class TemplateDecorateChatValue
    {
        /// <summary>
        /// 累计点赞人数 (点赞基数)
        /// </summary>
        public int BaseLikes { get; set; }
        /// <summary>
        /// 在线人数开关
        /// </summary>
        public string ChatOnlineNumberEnable { get; set; }
        /// <summary>
        /// 情绪直播间开关,情绪开关和点赞开关同时只能开启一个
        /// </summary>
        public string EmotionEnabled { get; set; }
        /// <summary>
        /// 红包开关
        /// </summary>
        public string RedPackEnabled { get; set; }
        /// <summary>
        /// 点赞开关
        /// </summary>
        public string SendFlowersEnabled { get; set; }
        /// <summary>
        /// 发送图片开关
        /// </summary>
        public string ViewerSendImgEnabled { get; set; }
        /// <summary>
        /// 欢迎语开关
        /// </summary>
        public string WelcomeEnabled { get; set; }
        /// <summary>
        /// 提现开关
        /// </summary>
        public string WithdrawEnabled { get; set; }
    }
}
