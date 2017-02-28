﻿using KQAnalytics3.Configuration.Access;
using KQAnalytics3.Services.Authentication;
using KQAnalytics3.Services.Authentication.Security;
using KQAnalytics3.Services.DataCollection;
using KQAnalytics3.Utilities;

namespace KQAnalytics3.Modules.Api.Query
{
    public class LogRequestQueryModule : KQBaseModule
    {
        public LogRequestQueryModule() : base("/api")
        {
            var accessValidator = new ClientApiAccessValidator();
            this.RequiresAllClaims(accessValidator.GetAccessClaimListFromScopes(new[] {
                ApiAccessScope.Read,
                ApiAccessScope.QueryLogRequests
            }), accessValidator.GetAccessClaim(ApiAccessScope.Admin));

            // Query Log Requests
            // Limit is the max number of log requests to return. Default 100
            Get("/query/logrequests/{limit:int}", async args =>
            {
                var itemLimit = args.limit as int? ?? 100;
                var dataLoggerService = new DataLoggerService();
                var data = await dataLoggerService.QueryRequestsAsync(itemLimit);
                return Response.AsJsonNet(data);
            });
        }
    }
}