using Idler.Common.Core;
using Polyv.SDK.Live.Abstractions.Values.Notices;

namespace Polyv.SDK.Live.Abstractions
{
    public interface IPolyvNoticeAPI
    {
        /// <summary>
        /// 录制视频回调
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        APIReturnInfo<RecordNoticeValue> RecordVerify(RecordNoticeValue modelInfo);
        /// <summary>
        /// 重制课件回调
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        APIReturnInfo<RemakeNoticeValue> RemakeVerify(RemakeNoticeValue modelInfo);
        /// <summary>
        /// 直播状态改变回调
        /// </summary>
        /// <param name="modelInfo"></param>
        /// <returns></returns>
        APIReturnInfo<LiveStreamChangedValue> LiveStreamChangedVerify(LiveStreamChangedValue modelInfo);
    }
}
