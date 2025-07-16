using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values
{
    public class PolyvResponsePaging<TContent>
    {
        /// <summary>
        ///  第几页
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 信息总数
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// 每页显示几条数据
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 分页内容
        /// </summary>
        public IList<TContent> Contents { get; set; } = new List<TContent>();
    }
}
