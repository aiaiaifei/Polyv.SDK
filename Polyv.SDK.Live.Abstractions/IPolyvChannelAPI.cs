using System.Collections.Generic;
using Idler.Common.Core;
using Polyv.SDK.Live.Abstractions.Values;
using Polyv.SDK.Live.Abstractions.Values.Decorate;
using ChannelSettingValue = Polyv.SDK.Live.Abstractions.Values.ChannelSettingValue;
using RequestCreateChannelValue = Polyv.SDK.Live.Abstractions.Values.RequestCreateChannelValue;
using RequestCreateInitChannelValue = Polyv.SDK.Live.Abstractions.Values.RequestCreateInitChannelValue;

namespace Polyv.SDK.Live.Abstractions
{
    public interface IPolyvChannelAPI
    {
        /// <summary>
        /// 创建频道
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        APIReturnInfo<ResponseCreateChannelValue> Create(RequestCreateChannelValue data);

        /// <summary>
        /// 创建并初始化频道
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        APIReturnInfo<ResponseCreateInitChannelValue> CreateInit(RequestCreateInitChannelValue data);

        /// <summary>
        /// 获取指定频道信息 
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<ChannelSettingValue> Single(string channelId);

        /// <summary>
        /// 获取指定频道的页面装修设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<ChannelDecorateSettingValue> SingleDecorate(string channelId);

        /// <summary>
        /// 修改频道的页面装修设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<ChannelDecorateSettingValue> UpdateDecorate(string channelId, ChannelDecorateSettingValue data);

        /// <summary>
        /// 分页查询频道的缩略信息
        /// </summary>
        /// <param name="categoryId">所属分类id</param>
        /// <param name="watchStatus">观看页状态筛选</param>
        /// <param name="keyword">频道名称关键字</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        APIReturnInfo<ReturnPaging<ChannelSimpleValue>> ChannelSimplePaging(string categoryId, string watchStatus,
            string keyword, int pageNum = 1, int pageSize = 10);

        /// <summary>
        /// 分页查询频道的基础信息
        /// </summary>
        /// <param name="categoryIds">所属分类id</param>
        /// <param name="channelIds">频道号</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        APIReturnInfo<ReturnPaging<ChannelBasicValue>> ChannelBasicPaging(string categoryIds, string channelIds,
            int pageNum = 1, int pageSize = 10);

        /// <summary>
        /// 分页查询频道的详情信息
        /// </summary>
        /// <param name="categoryId">所属分类id</param>
        /// <param name="watchStatus">观看页状态筛选</param>
        /// <param name="keyword">频道名称关键字</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        APIReturnInfo<ReturnPaging<ChannelDetailValue>> ChannelDetailPaging(string categoryId, string watchStatus,
            string keyword, int pageNum = 1, int pageSize = 10);

        /// <summary>
        /// 批量查询频道直播状态
        /// </summary>
        /// <param name="channelIds">频道Id集合逗号分隔</param>
        /// <returns></returns>
        APIReturnInfo<IList<ChannelLiveStatusValue>> ChannelLiveStatuss(string channelIds);

        /// <summary>
        /// 批量查询频道直播流信息
        /// </summary>
        /// <param name="channelIds">频道Id集合逗号分隔</param>
        /// <returns></returns>
        APIReturnInfo<IList<ChannelMonitorStreamsValue>> ChannelMonitorStreams(string channelIds);

        /// <summary>
        /// 查询频道直播流信息
        /// </summary>
        /// <param name="channelId">直播中的频道号</param>
        /// <returns></returns>
        APIReturnInfo<StreamInfoValue> ChannelMonitorStreamInfo(string channelId);

        /// <summary>
        /// 修改频道基本信息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<string> Update(RequestUpdateChannelValue data, string channelId);

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<string> Remove(string channelId);

        /// <summary>
        /// 频道回调设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        APIReturnInfo<string> CallbackSetting(string channelId, RequestCallbackSettingValue data);

        /// <summary>
        /// 获取频道回调设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<ResponseCallbackSettingValue> CallbackSetting(string channelId);

        /// <summary>
        /// 请求Web播放器参数
        /// </summary>
        /// <param name="data">请求参数</param>
        /// <returns></returns>
        APIReturnInfo<ResponseWebPlayerValue> WebPlayer(RequestWebPlayerValue data);

        /// <summary>
        /// 生成直接访问Url
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="nickName">昵称</param>
        /// <param name="avatar">头像</param>
        /// <param name="secretKey"></param>
        /// <param name="param4"></param>
        /// <param name="param5"></param>
        /// <returns></returns>
        APIReturnInfo<string> GenerateDirectUrl(string channelId, string userId, string nickName, string avatar,
            string secretKey, string param4, string param5);

        /// <summary>
        /// 获取聊天室Token
        /// </summary>
        /// <param name="data">参数</param>
        /// <returns></returns>
        APIReturnInfo<ResponseChatTokenValue> ChatToken(RequestChatTokenValue data);
    }
}