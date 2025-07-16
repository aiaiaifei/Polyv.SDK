using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Idler.Common.Core;
using Microsoft.Extensions.Options;
using Polyv.SDK.Live.Abstractions;
using Polyv.SDK.Live.Abstractions.Values;
using Polyv.SDK.Live.Abstractions.Values.Decorate;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Polyv.SDK.Live
{
    public class PolyvChannelAPI : BasePolyvAPI, IPolyvChannelAPI
    {
        public PolyvChannelAPI(IOptions<PolyvSetting> setting)
        {
            this.Setting = setting;
            this.Client = new RestClient(
                new Uri(this.Setting.Value.BaseUrl),
                configureSerialization: s =>
                {
                    s.UseSystemTextJson(new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });
                }
            );
        }

        /// <summary>
        /// 创建频道
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseCreateChannelValue> Create(RequestCreateChannelValue data)
        {
            RestRequest request = new RestRequest("live/v4/channel/create", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            this.Sign(request);
            request.AddJsonBody(data);

            RestResponse response =
                this.Client.Execute(request);
            PolyvResponse<ResponseCreateChannelValue> responseResult =
                this.FromJSON<PolyvResponse<ResponseCreateChannelValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ResponseCreateChannelValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ResponseCreateChannelValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 创建并初始化频道
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseCreateInitChannelValue> CreateInit(RequestCreateInitChannelValue data)
        {
            RestRequest request = new RestRequest("live/v4/channel/create-init", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            this.Sign(request);
            request.AddJsonBody(data);

            var json = data.ToJSON(new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ResponseCreateInitChannelValue> responseResult =
                this.FromJSON<PolyvResponse<ResponseCreateInitChannelValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ResponseCreateInitChannelValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ResponseCreateInitChannelValue>.Success(responseResult.Data);
        }


        /// <summary>
        /// 修改频道基本信息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> Update(RequestUpdateChannelValue data, string channelId)
        {
            RestRequest request = new RestRequest("live/v3/channel/basic/update", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);
            request.AddJsonBody(data);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }

        /// <summary>
        /// 删除频道
        /// </summary>
        /// <param name="channelId">删除频道</param>
        /// <returns></returns>
        public APIReturnInfo<string> Remove(string channelId)
        {
            RestRequest request = new RestRequest("live/v2/channels/{channelId}/delete", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("userId", this.Setting.Value.LiveUserId, ParameterType.QueryString);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }


        /// <summary>
        /// 获取指定频道信息 
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<ChannelSettingValue> Single(string channelId)
        {
            RestRequest request = new RestRequest("live/v4/channel/basic/get");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ChannelSettingValue> responseResult =
                response.Content.FromJson<PolyvResponse<ChannelSettingValue>>();
            if (!responseResult.Success)
                return APIReturnInfo<ChannelSettingValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ChannelSettingValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 获取指定频道的页面装修设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<ChannelDecorateSettingValue> SingleDecorate(string channelId)
        {
            RestRequest request = new RestRequest("live/v4/channel/decorate/get");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ChannelDecorateSettingValue> responseResult =
                this.FromJSON<PolyvResponse<ChannelDecorateSettingValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ChannelDecorateSettingValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ChannelDecorateSettingValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 修改频道的页面装修设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public APIReturnInfo<ChannelDecorateSettingValue> UpdateDecorate(string channelId,
            ChannelDecorateSettingValue data)
        {
            RestRequest request = new RestRequest("live/v4/channel/decorate/update", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);
            request.AddJsonBody(data);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ChannelDecorateSettingValue> responseResult =
                this.FromJSON<PolyvResponse<ChannelDecorateSettingValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ChannelDecorateSettingValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ChannelDecorateSettingValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 分页查询频道的缩略信息
        /// </summary>
        /// <param name="categoryId">所属分类id</param>
        /// <param name="watchStatus">观看页状态筛选</param>
        /// <param name="keyword">频道名称关键字</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        public APIReturnInfo<ReturnPaging<ChannelSimpleValue>> ChannelSimplePaging(string categoryId,
            string watchStatus, string keyword, int pageNum = 1, int pageSize = 10)
        {
            RestRequest request = new RestRequest("live/v4/channel/simple/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("pageNumber", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);
            if (!categoryId.IsEmpty())
                request.AddParameter("categoryId", categoryId, ParameterType.QueryString);
            if (!watchStatus.IsEmpty())
                request.AddParameter("watchStatus", watchStatus, ParameterType.QueryString);
            if (!keyword.IsEmpty())
                request.AddParameter("keyword", keyword, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<PolyvResponsePaging<ChannelSimpleValue>> responseResult =
                response.Content.FromJson<PolyvResponse<PolyvResponsePaging<ChannelSimpleValue>>>();
            if (!responseResult.Success)
                return APIReturnInfo<ReturnPaging<ChannelSimpleValue>>.Error(responseResult.Error.Desc);

            ReturnPaging<ChannelSimpleValue> paging =
                new ReturnPaging<ChannelSimpleValue>(responseResult.Data.PageNumber, responseResult.Data.PageSize,
                    responseResult.Data.TotalItems)
                {
                    PageListInfos = responseResult.Data.Contents
                };
            paging.Compute();
            return APIReturnInfo<ReturnPaging<ChannelSimpleValue>>.Success(paging);
        }

        /// <summary>
        /// 分页查询频道的基础信息
        /// </summary>
        /// <param name="categoryIds">所属分类id</param>
        /// <param name="channelIds">频道号</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        public APIReturnInfo<ReturnPaging<ChannelBasicValue>> ChannelBasicPaging(string categoryIds, string channelIds,
            int pageNum = 1, int pageSize = 10)
        {
            RestRequest request = new RestRequest("live/v4/channel/basic/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("pageNumber", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);
            if (!categoryIds.IsEmpty())
                request.AddParameter("categoryIds", categoryIds, ParameterType.QueryString);
            if (!channelIds.IsEmpty())
                request.AddParameter("channelIds", channelIds, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<PolyvResponsePaging<ChannelBasicValue>> responseResult =
                this.FromJSON<PolyvResponse<PolyvResponsePaging<ChannelBasicValue>>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ReturnPaging<ChannelBasicValue>>.Error(responseResult.Error.Desc);

            ReturnPaging<ChannelBasicValue> paging = new ReturnPaging<ChannelBasicValue>(responseResult.Data.PageNumber,
                responseResult.Data.PageSize, responseResult.Data.TotalItems)
            {
                PageListInfos = responseResult.Data.Contents
            };
            paging.Compute();
            return APIReturnInfo<ReturnPaging<ChannelBasicValue>>.Success(paging);
        }

        /// <summary>
        /// 分页查询频道的详情信息
        /// </summary>
        /// <param name="categoryId">所属分类id</param>
        /// <param name="watchStatus">观看页状态筛选</param>
        /// <param name="keyword">频道名称关键字</param>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页数据大小</param>
        /// <returns></returns>
        public APIReturnInfo<ReturnPaging<ChannelDetailValue>> ChannelDetailPaging(string categoryId,
            string watchStatus, string keyword, int pageNum = 1, int pageSize = 10)
        {
            RestRequest request = new RestRequest("live/v4/channel/detail/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("pageNumber", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);
            if (!categoryId.IsEmpty())
                request.AddParameter("categoryId", categoryId, ParameterType.QueryString);
            if (!watchStatus.IsEmpty())
                request.AddParameter("watchStatus", watchStatus, ParameterType.QueryString);
            if (!keyword.IsEmpty())
                request.AddParameter("keyword", keyword, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<PolyvResponsePaging<ChannelDetailValue>> responseResult =
                this.FromJSON<PolyvResponse<PolyvResponsePaging<ChannelDetailValue>>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ReturnPaging<ChannelDetailValue>>.Error(responseResult.Error.Desc);

            ReturnPaging<ChannelDetailValue> paging =
                new ReturnPaging<ChannelDetailValue>(responseResult.Data.PageNumber, responseResult.Data.PageSize,
                    responseResult.Data.TotalItems)
                {
                    PageListInfos = responseResult.Data.Contents
                };
            paging.Compute();
            return APIReturnInfo<ReturnPaging<ChannelDetailValue>>.Success(paging);
        }

        /// <summary>
        /// 批量查询频道直播状态
        /// </summary>
        /// <param name="channelIds">频道Id集合逗号分隔</param>
        /// <returns></returns>
        public APIReturnInfo<IList<ChannelLiveStatusValue>> ChannelLiveStatuss(string channelIds)
        {
            RestRequest request = new RestRequest("live/v4/channel/live-status/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            if (!channelIds.IsEmpty())
                request.AddParameter("channelIds", channelIds, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<IList<ChannelLiveStatusValue>> responseResult =
                this.FromJSON<PolyvResponse<IList<ChannelLiveStatusValue>>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<IList<ChannelLiveStatusValue>>.Error(responseResult.Error.Desc);

            return APIReturnInfo<IList<ChannelLiveStatusValue>>.Success(responseResult.Data);
        }

        /// <summary>
        /// 批量查询频道直播流信息
        /// </summary>
        /// <param name="channelIds">频道Id集合逗号分隔</param>
        /// <returns></returns>
        public APIReturnInfo<IList<ChannelMonitorStreamsValue>> ChannelMonitorStreams(string channelIds)
        {
            RestRequest request = new RestRequest("live/v3/channel/monitor/get-streams");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            if (!channelIds.IsEmpty())
                request.AddParameter("channelIds", channelIds, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<IList<ChannelMonitorStreamsValue>> responseResult =
                this.FromJSON<PolyvResponse<IList<ChannelMonitorStreamsValue>>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<IList<ChannelMonitorStreamsValue>>.Error(responseResult.Error.Desc);

            return APIReturnInfo<IList<ChannelMonitorStreamsValue>>.Success(responseResult.Data);
        }

        /// <summary>
        /// 查询频道直播流信息
        /// </summary>
        /// <param name="channelId">直播中的频道号</param>
        /// <returns></returns>
        public APIReturnInfo<StreamInfoValue> ChannelMonitorStreamInfo(string channelId)
        {
            RestRequest request = new RestRequest("live/v3/channel/monitor/get-stream-info");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            if (!channelId.IsEmpty())
                request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<StreamInfoValue> responseResult =
                this.FromJSON<PolyvResponse<StreamInfoValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<StreamInfoValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<StreamInfoValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 频道回调设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public APIReturnInfo<string> CallbackSetting(string channelId, RequestCallbackSettingValue data)
        {
            RestRequest request = new RestRequest("live/v3/channel/callback/update-setting", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.GetOrPost);
            request.AddParameter("channelId", channelId, ParameterType.GetOrPost);
            if (!data.LiveScanCallbackUrl.IsEmpty())
                request.AddParameter("liveScanCallbackUrl", data.LiveScanCallbackUrl, ParameterType.GetOrPost);

            if (!data.PlaybackCacheCallbackUrl.IsEmpty())
                request.AddParameter("playbackCacheCallbackUrl", data.PlaybackCacheCallbackUrl,
                    ParameterType.GetOrPost);

            if (!data.PlaybackCallbackUrl.IsEmpty())
                request.AddParameter("playbackCallbackUrl", data.PlaybackCallbackUrl, ParameterType.GetOrPost);

            if (!data.PPTRecordCallbackUrl.IsEmpty())
                request.AddParameter("pptRecordCallbackUrl", data.PPTRecordCallbackUrl, ParameterType.GetOrPost);

            if (!data.RecordCallbackUrl.IsEmpty())
                request.AddParameter("recordCallbackUrl", data.RecordCallbackUrl, ParameterType.GetOrPost);

            if (!data.RecordCallbackVideoType.IsEmpty())
                request.AddParameter("recordCallbackVideoType", data.RecordCallbackVideoType, ParameterType.GetOrPost);

            if (!data.StreamCallbackUrl.IsEmpty())
                request.AddParameter("streamCallbackUrl", data.StreamCallbackUrl, ParameterType.GetOrPost);
            this.SignPost(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }

        /// <summary>
        /// 获取频道回调设置
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseCallbackSettingValue> CallbackSetting(string channelId)
        {
            RestRequest request = new RestRequest("live/v3/channel/callback/get-setting");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);
            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<ResponseCallbackSettingValue>.Error(response.ErrorMessage);

            PolyvResponse<ResponseCallbackSettingValue> responseResult =
                this.FromJSON<PolyvResponse<ResponseCallbackSettingValue>>(response.Content);
            return APIReturnInfo<ResponseCallbackSettingValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 请求Web播放器参数
        /// </summary>
        /// <param name="data">请求参数</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseWebPlayerValue> WebPlayer(RequestWebPlayerValue data)
        {
            IList<KeyValuePair<string, string>> @params = new List<KeyValuePair<string, string>>();
            @params.Add(new KeyValuePair<string, string>("appId", this.Setting.Value.APPId));
            @params.Add(new KeyValuePair<string, string>("channelId", data.ChannelId.ToString()));

            string sign = this.GenerateSign(@params);

            return APIReturnInfo<ResponseWebPlayerValue>.Success(new ResponseWebPlayerValue()
            {
                APPId = this.Setting.Value.APPId,
                ChannelId = data.ChannelId,
                Sign = sign,
                Timestamp = @params.SingleOrDefault(t => t.Key == "timestamp").Value.LongByString(),
                UserId = data.UserId,
                Pic = data.Pic,
                UserName = data.UserName
            });
        }

        /// <summary>
        /// 生成直接访问Url
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="userId">用户Id</param>
        /// <param name="nickName">昵称</param>
        /// <param name="avatar">头像</param>
        /// <param name="secretKey">密钥</param>
        /// <param name="param4"></param>
        /// <param name="param5"></param>
        /// <returns></returns>
        public APIReturnInfo<string> GenerateDirectUrl(string channelId, string userId, string nickName, string avatar,
            string secretKey, string param4 = "", string param5 = "")
        {
            byte[] bytes = Encoding.UTF8.GetBytes(nickName);
            string name = WebUtility.UrlEncode(Convert.ToBase64String(bytes));
            string _param4 = param4.IsEmpty()
                ? ""
                : WebUtility.UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(param4)));
            string _param5 = param5.IsEmpty()
                ? ""
                : WebUtility.UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(param5)));
            long timestamp = this.NowTimeStamp();
            string sign = string.Concat(secretKey, userId, secretKey, timestamp).MD5();
            string url =
                $"{(this.Setting.Value.LiveUrl.IsEmpty() ? this.Setting.Value.DefaultLiveUrl : this.Setting.Value.LiveUrl)}watch/{channelId}?userid={userId}&nickname={name}&avatar={avatar}&param4={_param4}&param5={_param5}&ts={timestamp}&sign={sign}";
            return new APIReturnInfo<string>()
            {
                State = true,
                Data = url
            };
        }

        /// <summary>
        /// 获取聊天室Token
        /// </summary>
        /// <param name="data">参数</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseChatTokenValue> ChatToken(RequestChatTokenValue data)
        {
            RestRequest request = new RestRequest("live/v3/channel/common/get-chat-token");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("userId", data.UserId, ParameterType.QueryString);
            request.AddParameter("channelId", data.ChannelId, ParameterType.QueryString);
            request.AddParameter("role", data.Role, ParameterType.QueryString);

            if (!data.Origin.IsEmpty())
                request.AddParameter("origin", data.Origin, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<ResponseChatTokenValue>.Error(response.ErrorMessage);

            PolyvResponse<ResponseChatTokenValue> responseResult =
                this.FromJSON<PolyvResponse<ResponseChatTokenValue>>(response.Content);
            return APIReturnInfo<ResponseChatTokenValue>.Success(responseResult.Data);
        }
    }
}