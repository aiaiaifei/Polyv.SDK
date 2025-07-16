using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{

    public class ResponseAuthSettingValue
    {
        /// <summary>
        /// 频道Id
        /// </summary>
        public int ChannelId { get; set; }
        /// <summary>
        /// POLYV用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 条件级别
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 是否开启全局设置
        /// </summary>
        public string GlobalSettingEnabled { get; set; }
        /// <summary>
        /// 是否开启观看条件
        /// </summary>
        public string Enabled { get; set; }
        /// <summary>
        /// 观看条件类型
        /// </summary>
        public string AuthType { get; set; }

        /// <summary>
        /// 白名单观看提示信息
        /// </summary>
        public string AuthTips { get; set; }

        #region 外部授权
        /// <summary>
        /// SecretKey
        /// </summary>
        public string ExternalKey { get; set; }
        /// <summary>
        /// 自定义Url
        /// </summary>
        public string ExternalUri { get; set; }
        /// <summary>
        /// 跳转地址 
        /// </summary>
        public string ExternalRedirectUri { get; set; }
        #endregion

        #region 自定义授权

        /// <summary>
        /// SecretKey
        /// </summary>
        public string CustomKey { get; set; }
        /// <summary>
        /// 自定义url
        /// </summary>
        public string CustomUri { get; set; }
        #endregion

        /// <summary>
        /// SecretKey
        /// </summary>
        public string DirectKey { get; set; }

        /// <summary>
        /// 字段列表
        /// </summary>
        public IList<AuthSettingInfoFieldValue> InfoFields { get; set; } = new List<AuthSettingInfoFieldValue>();

        #region 验证码观看
        /// <summary>
        /// 验证码观看提示信息
        /// </summary>
        public string CodeAuthTips { get; set; }
        /// <summary>
        /// 验证码观看的验证码
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        /// 验证码观看的二维码提示
        /// </summary>
        public string QCodeTips { get; set; }
        /// <summary>
        /// 公众号二维码地址
        /// </summary>
        public string QCodeImg { get; set; }
        #endregion

        #region 付费观看
        /// <summary>
        /// 付费观看提示信息
        /// </summary>
        public string PayAuthTips { get; set; }
        /// <summary>
        /// 付费观看价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 付费有效截止日期
        /// </summary>
        public long WatchEndTime { get; set; }
        /// <summary>
        /// 付费有效天数
        /// </summary>
        public int ValidTimePeriod { get; set; }
        /// <summary>
        /// 付费观看是否支持试看
        /// </summary>
        public string TrialWatchEnabled { get; set; } = PolyvLiveConst.NO;
        /// <summary>
        /// 试看时间：分钟
        /// </summary>
        public int TrialWatchTime { get; set; }
        /// <summary>
        /// 试看截止时间：13位毫秒时间戳
        /// </summary>
        public long TrialWatchEndTime { get; set; }
        /// <summary>
        /// 白名单输入提示
        /// </summary>
        public string WhiteListInputTips { get; set; }
        /// <summary>
        /// 白名单入口文案
        /// </summary>
        public string WhiteListEntryText { get; set; }
        /// <summary>
        /// 登记观看提示信息
        /// </summary>
        public string InfoAuthTips { get; set; }
        /// <summary>
        /// 登记观看描述字段
        /// </summary>
        public string InfoDesc { get; set; }
        #endregion
    }
}