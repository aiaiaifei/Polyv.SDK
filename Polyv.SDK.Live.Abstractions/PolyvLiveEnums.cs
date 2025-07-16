using System.ComponentModel;

namespace Polyv.SDK.Live.Abstractions
{
    /// <summary>
    /// 直播场景
    /// </summary>
    public enum SceneTypes
    {
        [Description("大班课")] topclass,
        [Description("企业培训")] train,
        [Description("研讨会")] seminar,
        [Description("活动营销")] alone
    }

    /// <summary>
    /// 直播模板
    /// </summary>
    public enum TemplateTypes
    {
        [Description("三分屏(横屏)")] ppt,
        [Description("三分屏(竖屏)")] portrait_ppt,
        [Description("纯视频(横屏)")] alone,
        [Description("纯视频(竖屏)")] portrait_alone,
        [Description("纯视频-极速(横屏)")] topclass,
        [Description("纯视频-极速(竖屏)")] portrait_topclass,
        [Description("研讨会")] seminar
    }

    /// <summary>
    /// 转播类型
    /// </summary>
    public enum TransmitTypes
    {
        [Description("不开启")] normal,
        [Description("发起转播")] transmit,
        [Description("接收转播")] receive
    }

    /// <summary>
    /// 线上双师
    /// </summary>
    public enum DoubleTeacherTypes
    {
        [Description("大房间")] transmit,
        [Description("小房间")] receive
    }

    /// <summary>
    /// 皮肤
    /// </summary>
    public enum SkinTypes
    {
        [Description("时尚黑")] black,
        [Description("喜庆红")] red,
        [Description("科技蓝")] blue,
        [Description("经典白")] white,
        [Description("薄荷绿")] green,
        [Description("富贵金")] golden
    }

    /// <summary>
    /// 普通直播观看页布局配置
    /// </summary>
    public enum WatchLayoutTypes
    {
        [Description("普通")] normal,
        [Description("竖屏")] portrait
    }

    /// <summary>
    /// 频道装饰菜单类型
    /// </summary>
    public enum DecorateMenuTypes
    {
        [Description("直播介绍")] desc,
        [Description("互动聊天")] chat,
        [Description("提问")] quiz,
        [Description("问答")] qa,
        [Description("邀请海报")] invite,
        [Description("图文菜单")] text
    }

    /// <summary>
    /// 观看页状态
    /// </summary>
    public enum WatchStatusTypes
    {
        [Description("直播中")] live,
        [Description("回放中")] playback,
        [Description("已结束")] end,
        [Description("等待中")] waiting,
        [Description("未开始")] unStart
    }

    /// <summary>
    /// 角色权限
    /// </summary>
    public enum RolePurviewCodes
    {
        [Description("在线列表")] chatListEnabled,
        [Description("翻页")] pageTurnEnabled,
        [Description("监播")] monitorEnabled
    }

    /// <summary>
    /// 频道角色类型
    /// </summary>
    public enum AccountRoles
    {
        [Description("嘉宾")] Guest,
        [Description("助教")] Assistant
    }
    
    /// <summary>
    /// 录制格式
    /// </summary>
    public enum RecordFormats
    {
        [Description("m3u8")]
        m3u8,
        [Description("mp4")]
        mp4
    }

    /// <summary>
    /// 认证类型
    /// </summary>
    public enum AuthTypes
    {
        [Description("付费")]
        pay,
        [Description("无限制")]
        none,
        [Description("验证码")]
        code,
        [Description("白名单")]
        phone,
        [Description("登记")]
        info,
        [Description("自定义")]
        custom,
        [Description("扩展")]
        external,
        [Description("直连")]
        direct,
        [Description("分享观看")]
        wxshare,
        [Description("密码登录")]
        password
    }

    /// <summary>
    /// 研讨会角色
    /// </summary>
    public enum MeetRoles
    {
        [Description("主持人")]
        host,
        [Description("参会人")]
        attendee
    }

    /// <summary>
    /// 抽奖范围
    /// </summary>
    public enum LotteryRanges
    {
        [Description("所有观众")]
        all,
        [Description("当场直播未中奖用户")]
        notWinning,
        [Description("已签到用户")]
        signed,
        [Description("头衔")]
        actor,
        [Description("已填问卷用户")]
        questionnaire
    }

    /// <summary>
    /// 问卷题目类型
    /// </summary>
    public enum QuestionnaireQuestionTypes
    {
        [Description("单选题")]
        R,
        [Description("多项题")]
        C,
        [Description("问答题")]
        Q
    }

    /// <summary>
    /// 直播频道状态
    /// </summary>
    public enum LiveStatuses
    {
        [Description("正在直播")]
        live,
        [Description("直播结束")]
        end,
        [Description("研讨会频道，直播开启")]
        seminar_live,
        [Description("研讨会频道，直播结束")]
        seminar_end
    }
    
    /// <summary>
    /// 回放类型
    /// </summary>
    public enum PlaybackTypes
    {
        [Description("单个回放")]
        single,
        [Description("列表")]
        list
    }

    /// <summary>
    /// 回放来源
    /// </summary>
    public enum PlaybackOrigins
    {
        [Description("暂存")]
        record,
        [Description("回放列表")]
        playback,
        [Description("点播")]
        vod
    }
}