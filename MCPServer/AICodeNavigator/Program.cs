﻿using AICodeNavigator;
using McpDotNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

// Configure logging
builder.Logging.AddConsole(consoleLogOptions =>
{
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Register CodeSearchService with a configurable root directory
string rootCodeDirectory = @"C:\03132025\TESTA";  // 🔁 Replace with your actual code folder path
builder.Services.AddSingleton(new CodeSearchService(rootCodeDirectory));

// Register MCP server tools from assembly
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

// Start the server
await builder.Build().RunAsync();
