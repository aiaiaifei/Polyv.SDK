# Polyv.SDK

Polyv.SDK 是一个用于保利威（Polyv）直播平台的 .NET SDK，提供了完整的直播功能 API 封装。

## 项目简介

本项目是一个 .NET Standard 2.0 库，为保利威直播平台提供完整的 API 集成解决方案。SDK 采用接口分离设计，支持依赖注入，便于集成到各种 .NET 应用程序中。

## 功能特性

### 🎥 直播频道管理
- 创建和初始化直播频道
- 频道信息查询和更新
- 频道删除和状态管理
- 频道页面装修设置

### 📺 直播播放
- Web 播放器参数生成
- 直接访问 URL 生成
- 聊天室 Token 获取
- 直播流监控

### 👥 用户管理
- 账户信息管理
- 用户权限控制
- 角色管理（嘉宾、助教等）

### 📝 通知系统
- 直播通知管理
- 回调设置

### 🎬 回放功能
- 回放列表管理
- 回放播放控制

### 🎨 界面定制
- 多种直播模板支持
- 皮肤主题选择
- 观看页布局配置

## 项目结构

```
Polyv.SDK/
├── Polyv.SDK.Live/                    # 主要实现库
│   ├── PolyvChannelAPI.cs            # 频道 API 实现
│   ├── PolyvPlaybackAPI.cs           # 回放 API 实现
│   ├── PolyvAccountAPI.cs            # 账户 API 实现
│   ├── PolyvNoticeAPI.cs             # 通知 API 实现
│   ├── BasePolyvAPI.cs               # 基础 API 类
│   ├── PasswordGenerator.cs          # 密码生成器
│   └── PolyvModule.cs                # 依赖注入模块
├── Polyv.SDK.Live.Abstractions/      # 接口定义库
│   ├── IPolyvChannelAPI.cs           # 频道 API 接口
│   ├── IPolyvPlaybackAPI.cs          # 回放 API 接口
│   ├── IPolyvAccountAPI.cs           # 账户 API 接口
│   ├── IPolyvNoticeAPI.cs            # 通知 API 接口
│   ├── PolyvSetting.cs               # 配置类
│   ├── PolyvLiveEnums.cs             # 枚举定义
│   ├── PolyvLiveConst.cs             # 常量定义
│   └── Values/                       # 数据模型
└── Polyv.SDK.Live.Tests/             # 单元测试
```

## 安装

### NuGet 包安装

```bash
# 安装主要实现库
dotnet add package Idler.Polyv.SDK.Live

# 安装接口定义库
dotnet add package Polyv.SDK.Live.Abstractions
```

### 项目引用

```xml
<ItemGroup>
  <PackageReference Include="Idler.Polyv.SDK.Live" Version="0.1.1" />
  <PackageReference Include="Polyv.SDK.Live.Abstractions" Version="0.1.1" />
</ItemGroup>
```

## 快速开始

### 1. 配置依赖注入

```csharp
using Autofac;
using Polyv.SDK.Live;

// 注册 Polyv SDK 模块
var builder = new ContainerBuilder();
builder.RegisterModule<PolyvModule>();
var container = builder.Build();
```

### 2. 配置 Polyv 设置

```csharp
var polyvSetting = new PolyvSetting
{
    AppId = "your_app_id",
    AppSecret = "your_app_secret",
    UserId = "your_user_id"
};
```

### 3. 使用频道 API

```csharp
// 获取频道 API 实例
var channelAPI = container.Resolve<IPolyvChannelAPI>();

// 创建频道
var createRequest = new RequestCreateChannelValue
{
    Name = "测试直播频道",
    SceneType = SceneTypes.topclass,
    TemplateType = TemplateTypes.ppt
};

var result = channelAPI.Create(createRequest);
if (result.Success)
{
    var channelId = result.Data.ChannelId;
    Console.WriteLine($"频道创建成功，ID: {channelId}");
}
```

### 4. 生成播放链接

```csharp
// 生成直接访问 URL
var directUrlResult = channelAPI.GenerateDirectUrl(
    channelId: "your_channel_id",
    userId: "user_123",
    nickName: "测试用户",
    avatar: "https://example.com/avatar.jpg",
    secretKey: "your_secret_key",
    param4: "",
    param5: ""
);

if (directUrlResult.Success)
{
    var playUrl = directUrlResult.Data;
    Console.WriteLine($"播放链接: {playUrl}");
}
```

## 支持的直播场景

- **大班课** (topclass) - 适合大规模在线教育
- **企业培训** (train) - 企业内部培训场景
- **研讨会** (seminar) - 互动研讨会
- **活动营销** (alone) - 营销活动直播

## 支持的直播模板

- 三分屏（横屏/竖屏）
- 纯视频（横屏/竖屏）
- 纯视频-极速（横屏/竖屏）
- 研讨会模板

## 依赖项

- **.NET Standard 2.0**
- **Autofac** (8.0.0) - 依赖注入容器
- **Idler.Common.Core** (0.1.8) - 通用核心库
- **RestSharp** (112.0.0) - HTTP 客户端

## 开发环境要求

- .NET Standard 2.0 或更高版本
- Visual Studio 2019/2022 或 VS Code
- .NET 5.0+ 运行时

## 测试

项目包含完整的单元测试套件：

```bash
# 运行所有测试
dotnet test

# 运行特定测试项目
dotnet test Polyv.SDK.Live.Tests/
```

## 版本信息

- **当前版本**: 0.1.1
- **包 ID**: Idler.Polyv.SDK.Live
- **目标框架**: .NET Standard 2.0

## 贡献

欢迎提交 Issue 和 Pull Request 来改进这个项目。

## 许可证

本项目采用 MIT 许可证。详见 [LICENSE](LICENSE) 文件。

### MIT 许可证特点

- ✅ **允许商业使用** - 可以用于商业项目
- ✅ **允许修改** - 可以修改源代码
- ✅ **允许分发** - 可以重新分发
- ✅ **允许私人使用** - 可以私人使用
- ✅ **无责任** - 作者不承担任何责任
- ✅ **无担保** - 软件按原样提供，无任何担保

**唯一要求**: 在软件的所有副本或重要部分中都必须包含上述版权声明和许可声明。

## 相关链接

- [保利威官网](https://www.polyv.net/)
- [保利威开发者文档](https://dev.polyv.net/)
- [项目仓库](https://github.com/aiaiaifei/Polyv.SDK) 