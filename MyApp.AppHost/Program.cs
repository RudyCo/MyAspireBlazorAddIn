var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MyApp_ApiService>("apiservice");

builder.AddProject<Projects.MyApp_WebApp>("webapp")
    .WithReference(apiService);

builder.AddProject<Projects.MyApp_WebAddIn>("webaddin")
    .WithReference(apiService);

builder.Build().Run();
