# Reading Configuration and Feature Flags from Azure App Configuration

Pre-Requisites
 - Create App Configuration
 - Create configuration value and feature toggle

Configuration
![Configuration](https://github.com/niravmsoni/azure-app-configuration/assets/6556021/71092880-99e1-4dbc-ac9c-b1df20741875)

Feature Manager

![FeatureManager](https://github.com/niravmsoni/azure-app-configuration/assets/6556021/0ad71d4f-e7e7-4dba-95d2-69aa733f6445)


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
![image](https://github.com/niravmsoni/azure-app-configuration/assets/6556021/f67a1a2f-6043-4000-8d55-4d7efcab2176)

