using System;

namespace AppMaui
{
    public static class ServiceHelper
    {
        public static IServiceProvider Services { get; set; }

        public static T GetService<T>() => Services.GetService<T>();
    }
}
