var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyApp_ApiService>("apiservice");

builder.AddProject<Projects.MyApp_Web>("webfrontend")
    .WithReference(apiService);

builder.AddProject<Projects.MyApp_AddIn>("exceladdin")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();