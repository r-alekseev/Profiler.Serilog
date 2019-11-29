# Profiler.Serilog
[Profiler](https://github.com/r-alekseev/Profiler) is minimalistic and fast profiling library for .NET

[Serilog](https://github.com/serilog/serilog) is simple .NET logging project with fully-structured events 

This project contains components and configurations that provide the ability to write profiling traces and reports to the structured events in Serilog.

## Configuration

### Serilog

Configuration basics: https://github.com/serilog/serilog/wiki/Configuration-Basics

Provided sinks: https://github.com/serilog/serilog/wiki/Provided-Sinks

Just an example of configuring a logger to a JSON text file and to the console. 
```csharp
var logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.File(new CompactJsonFormatter(), "log.txt")
    .WriteTo.Console()
    .CreateLogger();
```

Just another example of configuring a logger to the Elasticsearch index.
```csharp
var logger = new LoggerConfiguration()
    .Enrich.WithExceptionDetails()
    .WriteTo.Elasticsearch(
        nodeUris: "http://some-address:9200",
        indexFormat: "some-service-{0:yyyy.MM.dd}",
        autoRegisterTemplate: true)
    .CreateLogger();
```

### Profiler

#### Trace Writer

Call `UseSerilogTraceWriter` method for set up writing trace to Serilog.

Pass an instance of the logger configured above to `UseLogger` method.
```csharp
var profiler = new ProfilerConfiguration()
    .UseSerilogTraceWriter(settings => settings
        .UseLogEventLevel(LogEventLevel.Verbose)
        .UseLogger(logger))
    .CreateProfiler();
```

#### Report Writer

Call `UseSerilogReportWriter` method for set up writing metrics report to Serilog.

Pass an instance of the logger configured above to `UseLogger` method.
```csharp
var profiler = new ProfilerConfiguration()
    .UseSerilogReportWriter(settings => settings
        .UseLogEventLevel(LogEventLevel.Information)
        .UseLogger(logger))
    .CreateProfiler();
```