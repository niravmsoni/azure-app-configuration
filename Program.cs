using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var azureAppConfigurationConnectionString = "Connection_String_here";

//For simply reading configurations from Azure App configuration
//builder.Configuration.AddAzureAppConfiguration(azureAppConfigurationConnectionString);

//For reading configuration + Accessing Feature flags, register using this.
builder.Configuration.AddAzureAppConfiguration(options =>
                options.Connect(azureAppConfigurationConnectionString)
                .UseFeatureFlags()
                );

//Adding required services here.
builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
