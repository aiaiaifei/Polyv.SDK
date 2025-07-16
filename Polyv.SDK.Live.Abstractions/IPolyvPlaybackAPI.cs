using System.Collections.Generic;
using Idler.Common.Core;
using Polyv.SDK.Live.Abstractions.Values;
using Polyv.SDK.Live.Abstractions.Values.Records;

namespace Polyv.SDK.Live.Abstractions
{
    public interface IPolyvPlaybackAPI
    {
        /// <summary>
        /// 获取频道回放相关签名
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        APIReturnInfo<ChannelPlaybackSignValue> GetChannelPlaybackSign(string channelId, string userId);
        /// <summary>
        /// 重置回放设置为默认值
        /// </summary>
        /// <param name="channelId"></param>
        /// <returns></returns>
        APIReturnInfo<string> ResetSetting(string channelId);
        /// <summary>
        /// 获取录播文件
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="sessionId">场次Id</param>
        /// <returns></returns>
        APIReturnInfo<IList<ResponseRecordSummaryValue>> ChannelRecordFiles(string channelId, string sessionId = "");
        /// <summary>
        /// 分页显示视频库文件
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="listType">列表类型</param>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageSize">每页显示几条信息</param>
        /// <returns></returns>
        APIReturnInfo<ReturnPaging<ResponsePlaybackValue>> ChannelPlaybackPaging(string channelId, string listType , int pageNum = 1, int pageSize = 50);
        /// <summary>
        /// 查询多个频道回放列表
        /// </summary>
        /// <param name="channelIds">用英文逗号隔开的频道号,最多100个</param>
        /// <returns></returns>
        APIReturnInfo<IList<ResponsePlaybackBasicValue>> ChannelPlaybacks(string channelIds);
        /// <summary>
        /// 删除视频库文件
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="videoId">视频Id</param>
        /// <param name="listType">列表类型</param>
        /// <returns></returns>
        APIReturnInfo<string> RemoveChannelPlayback(string channelId, string videoId, string listType);
        /// <summary>
        /// 设置默认频道回看
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="videoId">视频Id</param>
        /// <param name="listType">列表类型</param>
        /// <returns></returns>
        APIReturnInfo<string> SetDefaultChannelPlayback(string channelId, string videoId, string listType);
        /// <summary>
        /// 通过文件Id查询录播信息
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="fileId">文件Id</param>
        /// <returns></returns>
        APIReturnInfo<ResponseRecordFileValue> ChannelRecordFile(string channelId, string fileId);
        /// <summary>
        /// 异步裁剪视频
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        APIReturnInfo<string> AsyncRecordClip(RequestAsyncRecordClipValue data);
        /// <summary>
        /// 查询重制课件任务列表
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="sessionId">重制课件模块中的场次id</param>
        /// <param name="status">状态值</param>
        /// <param name="startTime">直播开始时间开始区间，格式为yyyyMMddHHmmss</param>
        /// <param name="endTime">直播开始时间结束区间，格式为yyyyMMddHHmmss</param>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageSize">每页显示几条信息</param>
        /// <returns></returns>
        APIReturnInfo<ReturnPaging<ResponsePPTRecordFileValue>> ChannelPPTRecordPaging(string channelId, string sessionId, string status, string startTime, string endTime, int pageNum = 1, int pageSize = 50);
    }
}
