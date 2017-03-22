﻿using IridiumIon.Analytics.Configuration.Access;
using IridiumIon.Analytics.Services.Authentication;
using IridiumIon.Analytics.Services.Authentication.Security;
using IridiumIon.Analytics.Services.DataCollection;
using IridiumIon.Analytics.Utilities;

namespace IridiumIon.Analytics.Modules.Api.Query
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