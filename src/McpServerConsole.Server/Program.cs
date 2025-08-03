/* Using our MCP server with StdioServerTransport
 * 
 */


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;


var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()   //Protocol Specification. option Server-Sent Events (SSE) transport, HttpTransport
    .WithToolsFromAssembly(); //WithToolsFromAssembly扩展方法，会自动扫描程序集中添加了McpServerTool标签的类进行注册

await builder.Build().RunAsync();
