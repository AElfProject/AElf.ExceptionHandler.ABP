# AElf.ExceptionHandler.ABP

- [About The Project](#about-the-project)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## About The Project

An ABP module for Exception handling through the [AElf.ExceptionHandler](https://www.nuget.org/packages/AElf.ExceptionHandler).

ABP version: 8.2.0

## Getting Started

Add the following dependency to your project's Module class:

```cs
using AElf.ExceptionHandler;

[DependsOn(
    typeof(AOPExceptionModule) // Add this line
)]
public class MyTemplateModule : AbpModule
```

When setting up your `HostBuilder` in your `Program.cs` file, add the following line:

```cs
var builder = WebApplication.CreateBuilder(args);
builder.Host
    .ConfigureDefaults(args)
    .UseAutofac()
    .UseAElfExceptionHandler() // Add this line
    .UseSerilog();
```

This will automatically register the AOPException module and setup your project for AOP Exception Handling.

## Contributing

If you encounter a bug or have a feature request, please use the [Issue Tracker](https://github.com/AElfProject/aelf-dapp-factory/issues/new). The project is also open to contributions, so feel free to fork the project and open pull requests.

## License

Distributed under the Apache License. See [License](LICENSE) for more information.
Distributed under the MIT License. See [License](LICENSE) for more information.
