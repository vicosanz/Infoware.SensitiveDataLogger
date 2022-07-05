# Infoware.SensitiveDataLogger
 Prevent expose sensitive data when log objects serialized to json

### Get it!
[![NuGet Badge](https://buildstats.info/nuget/Infoware.SensitiveDataLogger)](https://www.nuget.org/packages/Infoware.SensitiveDataLogger/)

### How to use it
- Inject via Dependency Injection or create a simple instance

```csharp
        services.AddAnotherService();

        services.AddSingleton<ILogJsonSerializer, LogJsonSerializer>();
```

- Use instance to serialize any object to json

```csharp
        
        public class CoolData
        {
            public string? Name { get; set; }
            [SensitiveData]
            public string? PasswordSuperSecret { get; set; }
        }

        public class CoolService : ICoolService
        {
            private readonly ILogger<CoolService> _logger;
            private readonly ILogJsonSerializer _customJsonSerializer;

            public CoolService (ILogger<CoolService> logger, ILogJsonSerializer customJsonSerializer)
            {
                _logger = logger;
                _customJsonSerializer = customJsonSerializer;
            }

            public DoAwesomeness(CoolData sensitiveLogin)
            {
                DoMoreStuff(sensitiveLogin);

                _logger.LogInformation("Login info was accepted: {sensitiveLogin}", _customJsonSerializer.SerializeObject(sensitiveLogin));
            };
        }
```

## Buy me a coofee
If you want, buy me a coofee :coffee: https://www.paypal.com/paypalme/vicosanzdev?locale.x=es_XC

