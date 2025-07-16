using System.Collections.Generic;
using Idler.Common.Core;
using Polyv.SDK.Live.Abstractions.Values;

namespace Polyv.SDK.Live.Abstractions
{
    public interface IPolyvAccountAPI
    {
        /// <summary>
        /// 创建单个角色
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        APIReturnInfo<ChannelAccountValue> CreateChannelAccount(string channelId, RequestCreateChannelAccountValue data);
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<ChannelAccountValue> UpdateChannelAccount(RequestUpdateChannelAccountValue data, string channelId);
        
        
         /// <summary>
        /// 获取剩余直播分钟数
        /// </summary>
        /// <returns></returns>
        APIReturnInfo<string> GetUserDurations();
        /// <summary>
        /// 设置平台Token
        /// </summary>
        /// <returns></returns>
        APIReturnInfo<string> SetToken();
        /// <summary>
        /// 设置频道Token
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<string> SetChannelToken(string channelId);
        /// <summary>
        /// 设置子频道Token
        /// </summary>
        /// <param name="accountId">账号Id</param>
        /// <returns></returns>
        APIReturnInfo<string> SetChannelAccountToken(string accountId);
        /// <summary>
        /// 讲师进入教室
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<string> EnterChannelClassroom(string channelId);
        /// <summary>
        /// 助教进入教室
        /// </summary>
        /// <param name="accountId">账号Id</param>
        /// <returns></returns>
        APIReturnInfo<string> EnterChannelAccountClassroom(string accountId);

        /// <summary>
        /// 查询频道所有角色列表
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        APIReturnInfo<IList<ChannelAccountValue>> ChannelAccounts(string channelId);
      
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="account">助教/嘉宾账号（不能以数字类型提交，否则可能去掉角色号前的00）</param>
        /// <returns></returns>
        APIReturnInfo<string> RemoveChannelAccount(string channelId, string account);
    }
}
