var builder = DistributedApplication.CreateBuilder(args);

var api = builder
    .AddProject<Projects.matthewshan_MinecraftUtils_Api>("api");


var web = builder.AddNpmApp("web", "../../ui", "dev")
    .WithReference(api)
    .WaitFor(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .WithOtlpExporter()
    .WithEnvironment("MINECRAFT_API_URL",  api.GetEndpoint("http"));

builder.Build().Run();

