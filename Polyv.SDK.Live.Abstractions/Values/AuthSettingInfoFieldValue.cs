namespace Polyv.SDK.Live.Abstractions.Values
{
    public class AuthSettingInfoFieldValue
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 选项
        /// </summary>
        public string Options { get; set; }
        /// <summary>
        /// 提示
        /// </summary>
        public string Placeholder { get; set; }
        /// <summary>
        /// 短信验证
        /// </summary>
        public string SMS { get; set; } = PolyvLiveConst.NO;
    }
}