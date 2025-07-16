using System.Collections.Generic;

namespace Polyv.SDK.Live.Abstractions.Values.Decorate
{
    /// <summary>
    /// 频道装修设置
    /// </summary>
    public class ChannelDecorateSettingValue
    {
        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin { get; set; }

        /// <summary>
        /// 普通直播观看页布局配置(普通:normal,竖屏:portrait)
        /// </summary>
        public string AloneWatchLayout { get; set; } = WatchLayoutTypes.normal.ToString();

        /// <summary>
        /// 装修里聊天对象
        /// </summary>
        public TemplateDecorateChatValue Chat { get; set; }

        /// <summary>
        /// 装修中文直播介绍页对象
        /// </summary>
        public TemplateDecorateDescValue Desc { get; set; }

        /// <summary>
        /// 中文菜单列表对象
        /// </summary>
        public IList<TemplateDecorateMenuValue> Menus { get; set; }

        /// <summary>
        /// 装修播放器对象
        /// </summary>
        public TemplateDecoratePlayerValue Player { get; set; }

        /// <summary>
        /// 三分屏移动端观看布局
        /// </summary>
        public string PptMobileWatchLayout { get; set; }

        /// <summary>
        /// 装修引导页对象
        /// </summary>
        public TemplateDecorateSplashValue Splash { get; set; }

        /// <summary>
        /// 引导页开关
        /// </summary>
        public string SplashEnabled { get; set; }

        /// <summary>
        /// 双语直播间开关
        /// </summary>
        public string EnglishSettingEnabled { get; set; }

        /// <summary>
        /// 英文菜单列表对象
        /// </summary>
        public IList<TemplateDecorateMenuValue> EnMenus { get; set; }

        /// <summary>
        /// 模板-装修英文直播介绍页对象
        /// </summary>
        public TemplateDecorateMenuValue descEn { get; set; }
    }
}