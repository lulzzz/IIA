﻿using Nancy;
using System;

namespace KQAnalytics3.Modules
{
    public class DataCollectEndpointModule : NancyModule
    {
        public DataCollectEndpointModule()
        {
            var processData = new Func<dynamic, object>(args =>
            {
                return "hi";
            });
            Post("/k", processData);
            Get("/k.png", args =>
            {
                var processResult = processData(args);
                
                return processResult;
            });
        }
    }
}