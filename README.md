# RequestLoggerMiddleware
ASP.NET Core Request Logging Middleware

![Automated Tests](https://github.com/evan-buss/RequestLoggerMiddleware/workflows/Automated%20Tests/badge.svg)

## Usage

1. Add the [NuGet package](https://www.nuget.org/packages/RequestLoggerMiddleware/).
2. Add the middlware to your `Configure` method in `Startup.cs`
```csharp
	app.UseRequestLogger(options => options.EnableColor());

	// or

	app.UseRequestLogger();
```

![screenshot](https://raw.githubusercontent.com/evan-buss/RequestLoggerMiddleware/master/docs/colorful.png)
