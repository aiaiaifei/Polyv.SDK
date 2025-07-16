using Autofac;
using Polyv.SDK.Live.Abstractions;

namespace Polyv.SDK.Live
{
    public class PolyvModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PolyvAccountAPI>().As<IPolyvAccountAPI>().SingleInstance();
            builder.RegisterType<PolyvChannelAPI>().As<IPolyvChannelAPI>().SingleInstance();
            // builder.RegisterType<PolyvMeetAPI>().As<IPolyvMeetAPI>().SingleInstance();
            builder.RegisterType<PolyvNoticeAPI>().As<IPolyvNoticeAPI>().SingleInstance();
            builder.RegisterType<PolyvPlaybackAPI>().As<IPolyvPlaybackAPI>().SingleInstance();
            // builder.RegisterType<PolyvStatisticsAPI>().As<IPolyvStatisticsAPI>().SingleInstance();
            builder.RegisterType<PolyvChannelAPI>().As<IPolyvChannelAPI>().SingleInstance();
            builder.RegisterType<PolyvAccountAPI>().As<IPolyvAccountAPI>().SingleInstance();
        }
    }
}
