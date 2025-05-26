
using ModelContextProtocol.AspNetCore;
using System.ComponentModel;
using MCPSSEServer.Server.Tools;

namespace MCPSSEServer.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting MCPSSEServer Server...");

            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                    // Add MCP Server to IoC
                   .AddMcpServer()
                   //SSE
                   .WithHttpTransport()
                   //  Register MCP Tool
                   .WithTools<TimeTool>();

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            //  Map Mcp endpoints
            app.MapMcp();


            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}
