# AElf.ExceptionHandler.ABP

- [About The Project](#about-the-project)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## About The Project

An ABP module for Exception handling through the [AElf.ExceptionHandler](https://www.nuget.org/packages/AElf.ExceptionHandler).

ABP version: 8.0.5

## Getting Started

Add the following dependency to your project's Module class:

```cs
using AElf.ExceptionHandler;

[DependsOn(
    typeof(AOPExceptionModule)
)]
public class MyTemplateModule : AbpModule
```

This will automatically register the AOPException module and setup your project for AOP Exception Handling.

## Contributing

If you encounter a bug or have a feature request, please use the [Issue Tracker](https://github.com/AElfProject/aelf-dapp-factory/issues/new). The project is also open to contributions, so feel free to fork the project and open pull requests.

## License

Distributed under the Apache License. See [License](LICENSE) for more information.
Distributed under the MIT License. See [License](LICENSE) for more information.
