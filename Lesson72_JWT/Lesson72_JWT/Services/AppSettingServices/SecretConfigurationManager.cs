namespace Lesson72_JWT.Services.AppSettingServices;

public static class SecretConfigurationManager
{
    public static string GetSecretValue<T>( T settings)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("secret.json", optional: true, reloadOnChange: true)
            .Build();

        var properties = typeof(T).GetProperties();

        var secretValue = configuration.GetValue<string>(properties[0].Name);

        return secretValue ?? "ConnectionMemoryString:ConnectionMemory";
    }

    
   /* public static string GetSecretValue()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("secret.json", optional: true, reloadOnChange: true)
            .Build();

        var secretValue = configuration.GetValue<string>(InMemoryAppSettings.SectionName);

        return secretValue ?? "ConnectionMemoryString:ConnectionMemory";
    }*/
}