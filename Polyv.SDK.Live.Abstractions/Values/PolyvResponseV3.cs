
namespace Polyv.SDK.Live.Abstractions.Values
{
    public class PolyvResponseV3<TData>
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
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public TData Data { get; set; }
    }
}
