using System.Security.Cryptography;
using Idler.Common.Core;
using Microsoft.Extensions.Options;
using Polyv.SDK.Live.Abstractions;
using Polyv.SDK.Live.Abstractions.Values.Notices;

namespace Polyv.SDK.Live
{
    public class PolyvNoticeAPI : IPolyvNoticeAPI
    {
        public PolyvNoticeAPI(IOptions<PolyvSetting> Setting)
        {
            this.Setting = Setting;
        }

        /// <summary>
        /// 配置文件
        /// </summary>
        protected IOptions<PolyvSetting> Setting { get; set; }

        /// <summary>
        /// 录制视频回调
        /// </summary>
        /// <returns></returns>
        public APIReturnInfo<RecordNoticeValue> RecordVerify(RecordNoticeValue ModelInfo)
        {
            if (ModelInfo == null)
                return APIReturnInfo<RecordNoticeValue>.Error("参数有误");

            if (ModelInfo.Sign != (this.Setting.Value.LiveAppSecret + ModelInfo.Timestamp).MD5())
                return APIReturnInfo<RecordNoticeValue>.Error("密钥校验失败");

            return APIReturnInfo<RecordNoticeValue>.Success(ModelInfo);
        }

        /// <summary>
        /// 重制课件回调
        /// </summary>
        /// <param name="ModelInfo"></param>
        /// <returns></returns>
        public APIReturnInfo<RemakeNoticeValue> RemakeVerify(RemakeNoticeValue ModelInfo)
        {
            if (ModelInfo == null)
                return APIReturnInfo<RemakeNoticeValue>.Error("参数有误");

            if (ModelInfo.Sign != (this.Setting.Value.LiveAppSecret + ModelInfo.Timestamp).MD5())
                return APIReturnInfo<RemakeNoticeValue>.Error("密钥校验失败");

            return APIReturnInfo<RemakeNoticeValue>.Success(ModelInfo);
        }

        /// <summary>
        /// 直播状态改变回调
        /// </summary>
        /// <param name="ModelInfo"></param>
        /// <returns></returns>
        public APIReturnInfo<LiveStreamChangedValue> LiveStreamChangedVerify(LiveStreamChangedValue ModelInfo)
        {
            if (ModelInfo == null)
                return APIReturnInfo<LiveStreamChangedValue>.Error("参数有误");

            if (ModelInfo.Sign != (this.Setting.Value.LiveAppSecret + ModelInfo.Timestamp).MD5())
                return APIReturnInfo<LiveStreamChangedValue>.Error("密钥校验失败");

            return APIReturnInfo<LiveStreamChangedValue>.Success(ModelInfo);
        }
    }
}