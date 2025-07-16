using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Idler.Common.Core;
using Microsoft.Extensions.Options;
using Polyv.SDK.Live.Abstractions;
using Polyv.SDK.Live.Abstractions.Values;
using RestSharp;
using RestSharp.Serializers.Json;

namespace Polyv.SDK.Live
{
    public class PolyvAccountAPI : BasePolyvAPI, IPolyvAccountAPI
    {
        public PolyvAccountAPI(IOptions<PolyvSetting> setting)
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
        /// 创建单个角色
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public APIReturnInfo<ChannelAccountValue> CreateChannelAccount(string channelId,
            RequestCreateChannelAccountValue data)
        {
            RestRequest request = new RestRequest("live/v4/channel/account/create", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);
            request.AddJsonBody(data);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ChannelAccountValue> responseResult =
                this.FromJSON<PolyvResponse<ChannelAccountValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ChannelAccountValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ChannelAccountValue>.Success(responseResult.Data);
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<ChannelAccountValue> UpdateChannelAccount(RequestUpdateChannelAccountValue data,
            string channelId)
        {
            RestRequest request = new RestRequest("live/v4/channel/account/update", Method.Post);

            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("account", data.Account, ParameterType.QueryString);
            request.AddParameter("channelId", channelId, ParameterType.QueryString);

            this.Sign(request);
            request.AddJsonBody(data);

            RestResponse response = this.Client.Execute(request);
            PolyvResponse<ChannelAccountValue> responseResult =
                this.FromJSON<PolyvResponse<ChannelAccountValue>>(response.Content);
            if (!responseResult.Success)
                return APIReturnInfo<ChannelAccountValue>.Error(responseResult.Error.Desc);

            return APIReturnInfo<ChannelAccountValue>.Success(responseResult.Data);
        }
        
         /// <summary>
        /// 获取账户剩余直播时间
        /// </summary>
        /// <returns></returns>
        public APIReturnInfo<string> GetUserDurations()
        {
            RestRequest request = new RestRequest("live/v2/user/get-user-durations");
            request.AddParameter("appId", this.Setting.Value.APPId);
            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            return APIReturnInfo<string>.Success(response.Content);
        }

        /// <summary>
        /// 设置平台Token
        /// </summary>
        /// <returns></returns>
        public APIReturnInfo<string> SetToken()
        {
            string token = Guid.NewGuid().ToString();
            RestRequest request = new RestRequest("live/v3/user/set-sso-token");
            request.AddParameter("appId", this.Setting.Value.APPId);
            request.AddParameter("token", token);
            this.Sign(request);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            return APIReturnInfo<string>.Success(token);
        }
        /// <summary>
        /// 设置频道Token
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> SetChannelToken(string channelId)
        {
            string token = Guid.NewGuid().ToString();
            RestRequest request = new RestRequest("live/v2/channels/{channelId}/set-token");
            request.AddParameter("appId", this.Setting.Value.APPId);
            request.AddParameter("token", token);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            return new APIReturnInfo<string>()
            {
                State = true,
                Data = token
            };
        }
        /// <summary>
        /// 设置子频道Token
        /// </summary>
        /// <param name="accountId">子账号Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> SetChannelAccountToken(string accountId)
        {
            string token = Guid.NewGuid().ToString();
            RestRequest request = new RestRequest("live/v2/channels/{accountId}/set-account-token");
            request.AddParameter("appId", this.Setting.Value.APPId);
            request.AddParameter("token", token);
            this.Sign(request);
            request.AddParameter("accountId", accountId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(response.ErrorMessage);

            return new APIReturnInfo<string>()
            {
                State = true,
                Data = token
            };
        }
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="AccountId">子账号Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> GenerateSign(IList<KeyValuePair<string, string>> @params)
        {
            return this.GenerateSign(@params);
        }

        /// <summary>
        /// 讲师进入教室
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> EnterChannelClassroom(string channelId)
        {
            APIReturnInfo<string> token = this.SetChannelToken(channelId);
            if (!token.State)
                return token;

            return new APIReturnInfo<string>()
            {
                State = true,
                Data = $"{(this.Setting.Value.WebStartUrl.IsEmpty() ? this.Setting.Value.DefaultWebStartUrl : this.Setting.Value.WebStartUrl)}teacher/auth-login?channelId={channelId}&token={token.Data}&redirect={(this.Setting.Value.WebStartUrl.IsEmpty() ? this.Setting.Value.DefaultWebStartUrl : this.Setting.Value.WebStartUrl)}web-start/classroom?channelId={channelId}"
            };
        }
        /// <summary>
        /// 助教进入教室
        /// </summary>
        /// <param name="accountId">账号Id</param>
        /// <returns></returns>
        public APIReturnInfo<string> EnterChannelAccountClassroom(string accountId)
        {
            APIReturnInfo<string> token = this.SetChannelAccountToken(accountId);
            if (!token.State)
                return token;

            return new APIReturnInfo<string>()
            {
                State = true,
                Data = $"{(this.Setting.Value.WebStartUrl.IsEmpty() ? this.Setting.Value.DefaultWebStartUrl : this.Setting.Value.WebStartUrl)}teacher/auth-login?channelId={accountId}&token={token.Data}&redirect={(this.Setting.Value.WebStartUrl.IsEmpty() ? this.Setting.Value.DefaultWebStartUrl : this.Setting.Value.WebStartUrl)}assistant.html"
            };
        }
        
        /// <summary>
        /// 查询频道所有角色列表
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <returns></returns>
        public APIReturnInfo<IList<ChannelAccountValue>> ChannelAccounts(string channelId)
        {
            RestRequest request = new RestRequest("live/v2/channelAccount/{channelId}/accounts");
            
            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<IList<ChannelAccountValue>>.Error(response.ErrorMessage);

            PolyvResponse<IList<ChannelAccountValue>> responseResult = this.FromJSON<PolyvResponse<IList<ChannelAccountValue>>>(response.Content);
            return APIReturnInfo<IList<ChannelAccountValue>>.Success(responseResult.Data);
        }

      
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="channelId">频道Id</param>
        /// <param name="account">助教/嘉宾账号（不能以数字类型提交，否则可能去掉角色号前的00）</param>
        /// <returns></returns>
        public APIReturnInfo<string> RemoveChannelAccount(string channelId, string account)
        {
            RestRequest request = new RestRequest("live/v2/channelAccount/{channelId}/delete", Method.Post);
            
            request.AddParameter("appId", this.Setting.Value.APPId, ParameterType.QueryString);
            request.AddParameter("account", account, ParameterType.QueryString);            

            this.Sign(request);
            request.AddParameter("channelId", channelId, ParameterType.UrlSegment);

            RestResponse response = this.Client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                return APIReturnInfo<string>.Error(this.FromJSON<PolyvResponseV3<string>>(response.Content).Message);

            PolyvResponseV3<string> responseResult = this.FromJSON<PolyvResponseV3<string>>(response.Content);
            return APIReturnInfo<string>.Success(responseResult.Data);
        }
    }
}