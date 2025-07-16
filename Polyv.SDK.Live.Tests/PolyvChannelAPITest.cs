using System;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Idler.Common.Core;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Polyv.SDK.Live;
using Polyv.SDK.Live.Abstractions;
using Polyv.SDK.Live.Abstractions.Values;

namespace Polyv.SDK.Live.Tests
{
    [TestClass]
    public class PolyvChannelAPITest
    {
        private IPolyvChannelAPI mockChannelAPI;

        private static Lazy<IOptions<PolyvSetting>> Setting = new Lazy<IOptions<PolyvSetting>>(() =>
        {
            var mockedSetting = new Mock<IOptions<PolyvSetting>>();
            mockedSetting.Setup(t => t.Value).Returns(new PolyvSetting()
            {
                LiveUserId = "d03f827d2e",
                APPId = "fqvh9ss612",
                LiveAppSecret = "fd210af2b51a42bbb52b429650800a65",
                LiveUrl = "https://live.polyv.cn/",
                WebStartUrl = "https://live.polyv.net/"
            });
            return mockedSetting.Object;
        });

        [TestInitialize]
        public void SetUp()
        {
            mockChannelAPI = new PolyvChannelAPI(Setting.Value);
        }

        [TestMethod]
        public void Test_Rmove()
        {
            System.Text.Json.JsonDefaultOptions.Instance.Converters.Add(new BooleanConverter());

            var result = mockChannelAPI.Remove("5347528");
            Console.WriteLine(result);
            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Create()
        {
            var data = new RequestCreateChannelValue()
            {
                Name = "测试直播",
                NewScene = SceneTypes.topclass.ToString(),
                Template = TemplateTypes.ppt.ToString(),
                ChannelPasswd = PasswordGenerator.GenerateRandomPassword(8),
                SeminarHostPassword = PasswordGenerator.GenerateRandomPassword(8),
                SeminarAttendeePassword = PasswordGenerator.GenerateRandomPassword(8)
            };

            var result = mockChannelAPI.Create(data);

            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_CreateInit()
        {
            var data = new RequestCreateInitChannelValue()
            {
                BasicSetting = new ChannelBasicSettingValue()
                {
                    Name = "测试直播",
                    NewScene = SceneTypes.topclass.ToString(),
                    Template = TemplateTypes.ppt.ToString(),
                    ChannelPasswd = PasswordGenerator.GenerateRandomPassword(8),
                    SeminarHostPassword = PasswordGenerator.GenerateRandomPassword(8),
                    SeminarAttendeePassword = PasswordGenerator.GenerateRandomPassword(8)
                },
                PlaybackSetting = new RequestPlaybackSettingValue()
                {
                    Origin = PlaybackOrigins.playback.ToString(),
                    PlaybackEnabled = PolyvLiveConst.YES,
                    SectionEnabled = PolyvLiveConst.YES,
                    Type = PlaybackTypes.list.ToString()
                },
                MasterAuthSetting = new RequestDirectAuthSettingValue()
                {
                    DirectKey = PasswordGenerator.GenerateRandomPassword(8), Enabled = PolyvLiveConst.YES
                }
            };

            var result = mockChannelAPI.CreateInit(data);

            Console.WriteLine(result);
            Assert.IsNotNull(result);
        }
    }

    public class BooleanConverter : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.True => "true",
                JsonTokenType.False => "false",
                JsonTokenType.String => reader.GetString(),
                _ => throw new JsonException("Invalid token type for string or boolean")
            };
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            if (bool.TryParse(value, out bool boolValue))
            {
                writer.WriteBooleanValue(boolValue);
            }
            else
            {
                writer.WriteStringValue(value);
            }
        }
    }
}