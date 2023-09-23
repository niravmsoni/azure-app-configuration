# Reading Configuration and Feature Flags from Azure App Configuration

Pre-Requisites
 - Create App Configuration
 - Create configuration value and feature toggle
   
![Configuration](https://github.com/niravmsoni/azure-app-service-using-feature-flags/assets/6556021/b8239894-dfbd-46bf-ad0c-b7f8555f564a)

![FeatureManager](https://github.com/niravmsoni/azure-app-service-using-feature-flags/assets/6556021/d7d082ed-bbed-4a5a-a414-cff037b4697e)

# Code Changes

Packages required
- Microsoft.FeatureManagement.AspNetCore
- Microsoft.Extensions.Configuration.AzureAppConfiguration

# Connect to your Azure App Config Store using the connection string

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

# Consuming Configuration and Feature Flag
  ![image](https://github.com/niravmsoni/azure-app-service-using-feature-flags/assets/6556021/9977e638-c68c-491b-94d6-a219e37c69ca)
