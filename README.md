# RequestLoggerMiddleware
ASP.NET Core Request Logging Middleware

## Usage

1. Add NuGet package.
2. Add the middlware to your `Configure` method in `Startup.cs`
```csharp
	app.UseRequestLogger(options => options.EnableColor());

	// or

	app.UseRequestLogger();
```

![screenshot](https://raw.githubusercontent.com/evan-buss/RequestLoggerMiddleware/master/docs/colorful.png)
