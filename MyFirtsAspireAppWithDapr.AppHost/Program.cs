
var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var statestore = builder.AddDaprStateStore("statestore");

var apiService = builder.AddProject<Projects.MyFirtsAspireAppWithDapr_ApiService>("apiservice")
    .WithDaprSidecar("api")
    .WithReference(statestore);

builder.AddProject<Projects.MyFirtsAspireAppWithDapr_Web>("webfrontend")
    .WithDaprSidecar("web")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
