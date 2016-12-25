﻿using AutoMapper;
using KQAnalytics3.Configuration;
using KQAnalytics3.Configuration.Access;

namespace KQAnalytics3
{
    public static class KQRegistry
    {
        public static KQServerConfiguration ServerConfiguration { get; set; }
        public static IMapper RequestDataMapper { get; set; }
        public static string CommonConfigurationFileName => "kqconfig.json";
        public static ApiKeyCache KeyCache { get; private set; } = new ApiKeyCache();
        public static string CurrentDirectory { get; set; }
        public static string KQBasePath { get; set; } = "/kq";

        public static void UpdateKeyCache()
        {
            KeyCache = new ApiKeyCache(ServerConfiguration.ApiKeys);
        }
    }
}