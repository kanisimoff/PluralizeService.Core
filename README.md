# PluralizeService.Core

Is .Net Core wrapper for class PluralizationService from System.Data.Entity.Design.PluralizationServices

Build status:
[![Build Status](https://kanisimoff.visualstudio.com/Pluralize%20Service%20Library/_apis/build/status/kanisimoff.PluralizeService.Core?branchName=master)](https://kanisimoff.visualstudio.com/Pluralize%20Service%20Library/_build/latest?definitionId=10&branchName=master)

## Getting Started

1. Download and build code, include a reference in your code to the project
2. From anywhere within your code cal the PluralizationProvider as shown below
```csharp
    string word = "buses";

    string singleWorld = PluralizationProvider.Singularize(word);
    Console.WriteLine(singleWorld);
    // outputs: bus
```

```csharp
    string word = "Company";

    string pluralWord = PluralizationProvider.Pluralize(word);
    Console.WriteLine(pluralWord);
    // outputs: Companies
```

## Authors

* **Microsoft** - *Initial work* - [Microsoft](https://msdn.microsoft.com/en-us/library/system.data.entity.design.pluralizationservices.pluralizationservice.aspx)
* **Konstantin Anisimoff** - *adapted for .Net Core* - [kanisimoff](https://github.com/kanisimoff)
* **Will Blackburn** - Extended to provide a Singleton Provider Class and XUnit Tests - [Harkole](https://github.com/Harkole/)
