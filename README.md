# PluralizeService.Core

Is .Net Core wrapper for class PluralizationService from System.Data.Entity.Design.PluralizationServices

## Getting Started

1. Install package Install-Package PluralizeService.Core
2. Create class PluralizationServiceInstance
```csharp
    public class PluralizationServiceInstance : IPluralizer
    {
        private static readonly IPluralizationApi Api;
        private static readonly CultureInfo CultureInfo;

        static PluralizationServiceInstance()
        {
            var builder = new PluralizationApiBuilder();
            builder.AddEnglishProvider();

            Api = builder.Build();
            CultureInfo = new CultureInfo("en-US");
        }


        public string Pluralize(string name)
        {
            return Api.Pluralize(name, CultureInfo) ?? name;
        }

        public string Singularize(string name)
        {
            return Api.Singularize(name, CultureInfo) ?? name;
        }
    }
```
3. Inject class to service collection
```csharp
   services.AddSingleton<IPluralizer, PluralizationServiceInstance>();
```
Happy nice code!

## Authors

* **Microsoft** - *Initial work* - [Microsoft](https://msdn.microsoft.com/en-us/library/system.data.entity.design.pluralizationservices.pluralizationservice.aspx)
* **Konstantin Anisimoff** - *adapted for .Net Core* - [ItMasters.Pro](https://github.com/itmasterspro)
