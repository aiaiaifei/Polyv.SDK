using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Idler.Common.Core;
using Microsoft.Extensions.Options;
using Polyv.SDK.Live.Abstractions;
using Polyv.SDK.Live.Abstractions.Values;
using Polyv.SDK.Live.Abstractions.Values.Records;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Polyv.SDK.Live
{
    public class PolyvPlaybackAPI : BasePolyvAPI, IPolyvPlaybackAPI
    {
        public PolyvPlaybackAPI(IOptions<PolyvSetting> setting)
        {
            this.Setting = setting;
            this.Client = new RestClient(new Uri(this.Setting.Value.BaseUrl),
                configureSerialization: s =>
                {
                    s.UseSystemTextJson(new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    });
                });
        }

        /// <summary>
        /// 获取频道回放相关签名
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public APIReturnInfo<ChannelPlaybackSignValue> GetChannelPlaybackSign(string channelId, string userId)
        {
            string timeStamp = this.NowTimeStamp().ToString();
            IList<KeyValuePair<string, string>> channelInfoSign = new List<KeyValuePair<string, string>>()
                { new KeyValuePair<string, string>("channelId", channelId) };
            string channelInfoSignStr = this.GenerateSignByAPPId(channelInfoSign, timeStamp);

            IList<KeyValuePair<string, string>> apiTokenSign = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("channelId", channelId),
                new KeyValuePair<string, string>("viewerId", userId),
            };

            IList<KeyValuePair<string, string>> chatApiSign = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("channelId", channelId),
                new KeyValuePair<string, string>("role", "viewer"),
                new KeyValuePair<string, string>("userId", userId),
            };

            ChannelPlaybackSignValue value = new ChannelPlaybackSignValue()
            {
                ChannelInfoSign = channelInfoSignStr,
                ApiTokenSign = this.GenerateSignByAPPId(apiTokenSign, timeStamp),
                ChatApiSign = this.GenerateSignByAPPId(chatApiSign, timeStamp),
                LiveSdkSign = channelInfoSignStr,
                TimeStamp = timeStamp
            };

            return new APIReturnInfo<ChannelPlaybackSignValue>
            {
                State = true,
                Data = value,
                Message = timeStamp
            };
        }

        /// <summary>
        /// 将频道的回放设置设为默认值
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> ResetSetting(string channelId)
        {
            RestRequest request = new RestRequest("live/v3/channel/playback/set-setting", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.GetOrPost);
            request.AddParameter("channelId", channelId, ParameterType.GetOrPost);
            request.AddParameter("globalSettingEnabled", "N", ParameterType.GetOrPost);
            request.AddParameter("playbackEnabled", "Y", ParameterType.GetOrPost);
            request.AddParameter("type", PlaybackTypes.list, ParameterType.GetOrPost);
            request.AddParameter("origin", PlaybackOrigins.vod, ParameterType.GetOrPost);
            this.SignPost(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }

        /// <summary>
        /// 获取直播暂存中的视频列表
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="sessionId">场次Id</param>
        /// <returns></returns>
        public APIReturnInfo<IList<ResponseRecordSummaryValue>> ChannelRecordFiles(string channelId,
            string sessionId = "")
        {
            RestRequest request = new RestRequest("live/v2/channels/{channelId}/recordFiles");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("userId", this.Setting.Value.LiveUserId, ParameterType.QueryString);
            if (!sessionId.IsEmpty())
                request.AddParameter("sessionId", sessionId, ParameterType.QueryString);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<IList<ResponseRecordSummaryValue>>.Error(response.ErrorMessage);

            PolyvResponse<IList<ResponseRecordSummaryValue>> responseResult =
                this.FromJSON<PolyvResponse<IList<ResponseRecordSummaryValue>>>(response.Content);
            return APIReturnInfo<IList<ResponseRecordSummaryValue>>.Success(responseResult.Data);
        }


        /// <summary>
        /// 删除视频库文件
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="videoId">视频Id</param>
        /// <param name="listType">列表类型</param>
        /// <returns></returns>
        public APIReturnInfo<string> RemoveChannelPlayback(string channelId, string videoId,
            string listType)
        {
            RestRequest request = new RestRequest("live/v2/channel/recordFile/{channelId}/playback/delete");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("videoId", videoId, ParameterType.QueryString);
            request.AddParameter("listType", listType, ParameterType.QueryString);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success("成功");
        }

        /// <summary>
        /// 设置默认频道回看
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="videoId">视频Id</param>
        /// <param name="listType">列表类型</param>
        /// <returns></returns>
        public APIReturnInfo<string> SetDefaultChannelPlayback(string channelId, string videoId,
            string listType)
        {
            RestRequest request =
                new RestRequest("live/v2/channel/recordFile/{channelId}/playback/set-Default", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("videoId", videoId, ParameterType.QueryString);
            request.AddParameter("listType", listType, ParameterType.QueryString);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success("成功");
        }

        /// <summary>
        /// 分页显示视频库文件
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="listType">列表类型</param>
        /// <param name="pageNum">第几页</param>
        /// <param name="pageSize">每页显示几条信息</param>
        /// <returns></returns>
        public APIReturnInfo<ReturnPaging<ResponsePlaybackValue>> ChannelPlaybackPaging(string channelId,
            string listType, int pageNum = 1, int pageSize = 50)
        {
            RestRequest request = new RestRequest("live/v2/channel/recordFile/{channelId}/playback/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("page", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);
            if (!listType.IsEmpty())
                request.AddParameter("listType", listType, ParameterType.QueryString);

            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<ReturnPaging<ResponsePlaybackValue>>.Error(response.ErrorMessage);

            PolyvResponse<PolyvResponsePaging<ResponsePlaybackValue>> responseResult =
                this.FromJSON<PolyvResponse<PolyvResponsePaging<ResponsePlaybackValue>>>(response.Content);
            return APIReturnInfo<ReturnPaging<ResponsePlaybackValue>>.Success(new ReturnPaging<ResponsePlaybackValue>()
            {
                PageNum = responseResult.Data.PageNumber,
                PageSize = responseResult.Data.PageSize,
                Total = responseResult.Data.TotalItems,
                PageCount = responseResult.Data.TotalPages,
                PageListInfos = responseResult.Data.Contents
            });
        }

        /// <summary>
        /// 查询多个频道回放列表
        /// </summary>
        /// <param name="channelIds">用英文逗号隔开的频道号,最多100个</param>
        /// <returns></returns>
        public APIReturnInfo<IList<ResponsePlaybackBasicValue>> ChannelPlaybacks(string channelIds)
        {
            RestRequest request = new RestRequest("live/v4/channel/playback/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelIds", channelIds, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<IList<ResponsePlaybackBasicValue>>.Error(response.ErrorMessage);

            PolyvResponse<IList<ResponsePlaybackBasicValue>> responseResult =
                this.FromJSON<PolyvResponse<IList<ResponsePlaybackBasicValue>>>(response.Content);
            return APIReturnInfo<IList<ResponsePlaybackBasicValue>>.Success(responseResult.Data);
        }

        /// <summary>
        /// 通过文件Id查询暂存录播信息
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="fileId">文件Id</param>
        /// <returns></returns>
        public APIReturnInfo<ResponseRecordFileValue> ChannelRecordFile(string channelId, string fileId)
        {
            RestRequest request = new RestRequest("live/v3/channel/record/get");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);
            request.AddParameter("fileId", fileId, ParameterType.QueryString);
            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<ResponseRecordFileValue>.Error(response.ErrorMessage);

            PolyvResponse<ResponseRecordFileValue> responseResult =
                this.FromJSON<PolyvResponse<ResponseRecordFileValue>>(response.Content);
            return APIReturnInfo<ResponseRecordFileValue>.Success(responseResult.Data);
        }


        /// <summary>
        /// 异步裁剪视频
        /// </summary>
        /// <param name="data">参数</param>
        /// <returns></returns>
        public APIReturnInfo<string> AsyncRecordClip(RequestAsyncRecordClipValue data)
        {
            RestRequest request = new RestRequest("live/v3/channel/record/clip", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.GetOrPost);
            request.AddParameter("channelId", data.ChannelId, ParameterType.GetOrPost);
            request.AddParameter("fileId", data.FileId, ParameterType.GetOrPost);
            request.AddParameter("deleteTimeFrame", data.DeleteTimeFrame, ParameterType.GetOrPost);
            if (!data.CallbackUrl.IsEmpty())
                request.AddParameter("callbackUrl", data.CallbackUrl, ParameterType.GetOrPost);

            if (!data.AutoConvert.IsEmpty())
                request.AddParameter("autoConvert", data.AutoConvert, ParameterType.GetOrPost);

            if (!data.FileName.IsEmpty())
                request.AddParameter("fileName", data.FileName, ParameterType.GetOrPost);

            this.SignPost(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            PolyvResponse<string> responseResult = this.FromJSON<PolyvResponse<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }

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
        public APIReturnInfo<ReturnPaging<ResponsePPTRecordFileValue>> ChannelPPTRecordPaging(string channelId,
            string sessionId, string status, string startTime, string endTime, int pageNum = 1, int pageSize = 50)
        {
            RestRequest request = new RestRequest("live/v3/channel/pptRecord/list");

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("page", pageNum, ParameterType.QueryString);
            request.AddParameter("pageSize", pageSize, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);
            if (!sessionId.IsEmpty())
                request.AddParameter("sessionId", sessionId, ParameterType.QueryString);
            if (!status.IsEmpty())
                request.AddParameter("status", status, ParameterType.QueryString);
            if (!startTime.IsEmpty())
                request.AddParameter("startTime", startTime, ParameterType.QueryString);
            if (!endTime.IsEmpty())
                request.AddParameter("endTime", endTime, ParameterType.QueryString);

            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<ReturnPaging<ResponsePPTRecordFileValue>>.Error(response.ErrorMessage);

            PolyvResponse<PolyvResponsePaging<ResponsePPTRecordFileValue>> responseResult =
                this.FromJSON<PolyvResponse<PolyvResponsePaging<ResponsePPTRecordFileValue>>>(response.Content);
            return APIReturnInfo<ReturnPaging<ResponsePPTRecordFileValue>>.Success(
                new ReturnPaging<ResponsePPTRecordFileValue>()
                {
                    PageNum = responseResult.Data.PageNumber,
                    PageSize = responseResult.Data.PageSize,
                    Total = responseResult.Data.TotalItems,
                    PageCount = responseResult.Data.TotalPages,
                    PageListInfos = responseResult.Data.Contents
                });
        }
    }
}