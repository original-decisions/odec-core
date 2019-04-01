# Original decision Core Module

**Build Status:**   ![gated master build](https://pirmosk.visualstudio.com/odec.Core/_apis/build/status/gated-master?branchName=master)

## Overview

The following module is developed to resolve common developer tasks which he may face in the day to day life such as tricking out the enum to not only return the **`int`** value but also behave like the short form of the database glossary type table or providing with additional functionality for configuring autofac IoC container from the Json/Xml file.

## Supported runtimes

- net452
- netcoreapp1.0 (partially)
- netcoreapp2.1+

## The following module consist of 3 core assemblies

- **Core Assembly:** it has the common functionality which is used among all aplications such as the extension methods and common test methods.
- **Validation Utilities:** it is the framework to easy out the life of people who deal the services/server side validation which offers a way of specifying the rules for the entity and getting the errors with severyty and other information. It is simply a model, an interface abstraction for the validatable entity, anf controller as engine. *Unfortunatly the error messages are only in Russian. Help to localize or develop a settings bases approach is most wanted.*
- **Web Utils:** - It has a simple helper classes and enums for the HttoClient and a wrapper around it to use JsonConvert to parse a value. It is raw assembly and realization.

## Installation

Below you can install from the nuget 

### netcore 1.0+ and upper

```ps
dotnet add package odec.Framework
```

### Older Versions.

**Via Package Manager Console**

```cmd
Install-Package odec.Framework
```

**Via Nuget Tools**

```cmd
nuget install odec.Framework
```

### From Source Code

- Clone the [repository](https://github.com/original-decisions/odec-core/tree/master)
- Build Solution.

> [!NOTE]
> Master has stable version but you can use any branch.

## Improvement, Contribution and Dontation

All the contributions are the most welcome as well as the improvement suggestions. feel free to open an issue on [GitHub](https://github.com/original-decisions/odec-core/tree/master)
<!--If you like the library you can also buy me a bear.-->

### Contribution

You can contribute by:

- Suggesting the feature or
- Fixing a bug in which is stated on the [GitHub repo](https://github.com/original-decisions/odec-core/tree/master) or
- Improving the documentation by commenting the code inside of the assemblies.
- Improving the documentation by modifying the **.md** files inside of the [documentation engine directory](https://github.com/original-decisions/odec-core/tree/master/doc_gen)

## Further Improvement for the library

> [!WARNING]
> **If you want submit the improvement you can clone sandbox repository, play with it and extend it then you can submit a pull request.**

### High Level TODO List

> [!NOTE]
> It can be made more decoupled so users can get the necessary features from the scratch and some advanced features as needed. Ex: Autofac, spring.net helpers, etc)

> [!NOTE] 
>Commenting the code so it would generate more complete documentation from scratch

> [!NOTE] 
> Writing more extensions for the Autofac. ( I like the Autofac library and want to make advanced configuration available from the xml or json).

## Support details and Contributers list

For all questions you can contact me via email: [pirjob@yandex.ru](mailto:pirjob@yandex.ru)

### Authors

- [Alexandr Pirogov](mailto:pirjob@yandex.ru)

### Contributors

- [Mary Pirogova](mailto:maryvpie@outlook.com)
- Sergey Belkov
