namespace Polyv.SDK.Live.Abstractions.Values
{
    public class PolyvResponse<TData>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 是否响应成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 请求ID
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public PolyvResponseError Error { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public TData Data { get; set; }        
    }
}
