var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyApp_ApiService>("apiservice");

builder.AddProject<Projects.MyApp_Web>("webfrontend")
    .WithReference(apiService);

builder.AddProject<Projects.MyApp_AddIn>("myapp-addin");

builder.Build().Run();
