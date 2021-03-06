using IridiumIon.Analytics.Configuration;
using IridiumIon.Analytics.Configuration.Access;
using IridiumIon.Analytics.Services.DataCollection;
using OsmiumSubstrate.Services.Authentication;
using OsmiumSubstrate.Services.Authentication.Security;
using OsmiumSubstrate.Utilities;

namespace IridiumIon.Analytics.Modules.Api.Query
{
    public class DataQueryModule : NABaseModule
    {
        public INAServerContext ServerContext { get; }

        public DataQueryModule(INAServerContext serverContext) : base("/qr")
        {
            ServerContext = serverContext;
            var accessValidator = new StatelessClientValidator<NAAccessKey, NAApiAccessScope>();
            this.RequiresAllClaims(new[] { accessValidator.GetAccessClaim(NAApiAccessScope.Query) },
                accessValidator.GetAccessClaim(NAApiAccessScope.Admin));

            // Query Log Requests
            // Limit is the max number of log requests to return. Default 100
            Get("/log/{limit:int}", async args =>
            {
                var itemLimit = args.limit as int? ?? 100;
                var dataLoggerService = new DataLoggerService(ServerContext);
                var data = await dataLoggerService.QueryRequestsAsync(itemLimit);
                return Response.AsJsonNet(data);
            });

            // Query SessionData
            // Id is the ID of the session to find
            Get("/sessdata/{id}", async args =>
            {
                var sessionStorageService = new SessionStorageService(ServerContext);
                var data = await sessionStorageService.GetSessionFromIdentifierAsync((string)args.id);
                return Response.AsJsonNet(data);
            });

            // Query Tagged Requests
            // Tag is the tag to filter by
            // Limit is the max number of log requests to return
            Get("/tagged/{tags}/{limit:int}", async args =>
            {
                var itemLimit = args.limit as int? ?? 100;
                var filterTags = (args.tags != null) ? ((string)args.tags).Split(',') : null;
                var dataLoggerService = new DataLoggerService(ServerContext);
                var data = await dataLoggerService.QueryTaggedRequestsAsync(itemLimit, filterTags);
                return Response.AsJsonNet(data);
            });
        }
    }
}