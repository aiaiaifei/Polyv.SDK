using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Polyv.SDK.Live.Abstractions;
using RestSharp;

namespace Polyv.SDK.Live
{
    public abstract class BasePolyvAPI
    {
        /// <summary>
        /// 客户端
        /// </summary>
        protected RestClient Client { get; set; }

        /// <summary>
        /// 配置文件
        /// </summary>
        protected IOptions<PolyvSetting> Setting { get; set; }

        protected RestRequest SignPost(RestRequest request)
        {
            request.AddParameter("timestamp", this.NowTimeStamp(), ParameterType.GetOrPost);
            string plaintext = this.Setting.Value.LiveAppSecret +
                               string.Join("",
                                   request.Parameters.OrderBy(t => t.Name)
                                       .Select(t => string.Concat(t.Name, t.Value))) + this.Setting.Value.LiveAppSecret;
            request.AddParameter("sign", plaintext.MD5().ToUpper(), ParameterType.GetOrPost);
            return request;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        protected RestRequest SignNew(RestRequest request)
        {
            request.AddParameter("timestamp", this.NowTimeStamp(), ParameterType.QueryString);
            string plaintext =
                string.Join("&",
                    request.Parameters.OrderBy(t => t.Name).Select(t => string.Concat(t.Name, "=", t.Value))) +
                this.Setting.Value.LiveAppSecret;
            request.AddParameter("sign", plaintext.MD5().ToUpper(), ParameterType.QueryString);
            return request;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        protected RestRequest Sign(RestRequest request)
        {
            request.AddParameter("timestamp", this.NowTimeStamp(), ParameterType.QueryString);
            string plaintext = this.Setting.Value.LiveAppSecret +
                               string.Join("",
                                   request.Parameters.OrderBy(t => t.Name)
                                       .Select(t => string.Concat(t.Name, t.Value))) + this.Setting.Value.LiveAppSecret;
            request.AddParameter("sign", plaintext.MD5().ToUpper(), ParameterType.QueryString);
            return request;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="Params">参数列表</param>
        /// <returns></returns>
        protected string GenerateSign(IList<KeyValuePair<string, string>> Params)
        {
            Params.Add(new KeyValuePair<string, string>("timestamp", this.NowTimeStamp().ToString()));
            string plaintext = this.Setting.Value.LiveAppSecret +
                               string.Join("", Params.OrderBy(t => t.Key).Select(t => string.Concat(t.Key, t.Value))) +
                               this.Setting.Value.LiveAppSecret;
            return plaintext.MD5().ToUpper();
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="Params">参数列表</param>
        /// <param name="TimeStamp">时间戳</param>
        /// <returns></returns>
        protected string GenerateSignByAPPId(IList<KeyValuePair<string, string>> Params, string TimeStamp)
        {
            Params.Add(new KeyValuePair<string, string>("appId", this.Setting.Value.APPId));
            Params.Add(new KeyValuePair<string, string>("timestamp", TimeStamp));
            string plaintext = this.Setting.Value.LiveAppSecret +
                               string.Join("", Params.OrderBy(t => t.Key).Select(t => string.Concat(t.Key, t.Value))) +
                               this.Setting.Value.LiveAppSecret;
            return plaintext.MD5().ToUpper();
        }

        /// <summary>
        /// 获取16位MD5
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        protected string MD516(string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                string sBuilder = BitConverter.ToString(data, 4, 8);
                sBuilder = sBuilder.Replace("-", "");
                return sBuilder.ToString().ToUpper();
            }
        }

        /// <summary>
        /// 当前时间时间戳
        /// </summary>
        /// <returns></returns>
        protected long NowTimeStamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 从json转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        protected T FromJSON<T>(string json)
        {
            if (json.IsEmpty())
                return default(T);

            return json.FromJson<T>();
        }


        /// <summary>
        /// 基于Sha1的自定义加密字符串方法：输入一个字符串，返回一个由40个字符组成的十六进制的哈希散列（字符串）。
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>加密后的十六进制的哈希散列（字符串）</returns>
        public static string Sha1Signature(string str)
        {
            var buffer = Encoding.UTF8.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);

            StringBuilder sub = new StringBuilder();
            foreach (var t in data)
            {
                sub.Append(t.ToString("X2"));
            }

            return sub.ToString();
        }
    }
}