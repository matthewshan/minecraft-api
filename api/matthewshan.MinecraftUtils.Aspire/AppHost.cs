var builder = DistributedApplication.CreateBuilder(args);

var api = builder
    .AddProject<Projects.matthewshan_MinecraftUtils_Api>("api");

var web = builder.AddNpmApp("web", "../../ui", "start");

builder.Build().Run();

