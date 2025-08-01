﻿// For Client Developers

using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;




namespace MCPSSEServer.Ecovacs.Deebot.Client
{
    class Program
    {

        // get ak from https://open.ecovacs.cn/#/preparationForUse
        private const string API_TOKEN = "GwQhGTDFpetB7bXhHyDT0kRcywDNlG22"; // "YOUR_LONG_LIVED_ACCESS_TOKEN";  API 访问密钥，用于验证接口调用权限

        // 配置 SSE 连接
        // https://github.com/ecovacs-ai/ecovacs-mcp
        private const string BASE_URL = "https://mcp-open.ecovacs.cn/sse?ak=your ak"; //  https://mcp-open.ecovacs.cn/sse?ak=your ak

        static async Task Main(string[] args)
        {

            // step 1.Connect to an MCP server
            Console.WriteLine("Connecting client to  Ecovacs MCP Server");

            //guide: https://github.com/ecovacs-ai/ecovacs-mcp


            // Configure it connect to your MCP server.
            // 配置SSE传输
            // 添加一个新的 MCP Server 配置
            var transportOptions = new SseClientTransportOptions
            {
                Endpoint = new Uri(BASE_URL),
                AdditionalHeaders = new Dictionary<string, string>
               {
                  { "ak", $"{API_TOKEN}" }
               },
             
            };


            var transport = new SseClientTransport(transportOptions);


            // Create the MCP client
            //2. 使用配置创建 MCP 客户端实例 connect to the MCP server by providing the URL of the server. 
            await using var mcpClient = await McpClientFactory.CreateAsync(transport);


            Console.WriteLine($"Successfully connected!{mcpClient.ServerInfo.Name} {mcpClient.ServerInfo.Version}");
            Console.WriteLine();


            // step 2. list tools
            // Get all available tools
            // Get all tools as a list
            Console.WriteLine("Tools available:");
            var listToolsResult = await mcpClient.ListToolsAsync();
            Console.WriteLine("功能列表:");

            // Get all available tools
            //遍历工具列表，并逐个输出到控制台
            foreach (var tool in listToolsResult)
            {
                Console.WriteLine($"  名称：{tool.Name}，说明：{tool.Description} JSON Schema: {tool.JsonSchema}");
            }

            Console.WriteLine();


            //step 3.CallTool
            // https://modelcontextprotocol.github.io/csharp-sdk/api/ModelContextProtocol.Client.McpClientExtensions.html
            var tool1 = listToolsResult.FirstOrDefault(t => t.Name == "get_device_list");

            //var echoTool = listToolsResult.FirstOrDefault(t => t.Name == "HassTurnOff");
            //// Access schema properties
            //string type = echoTool.JsonSchema.GetProperty("type").GetString();
            //JsonElement properties = echoTool.JsonSchema.GetProperty("properties");
            //string paramDescription = properties.GetProperty("message").GetProperty("description").GetString();
            //int requiredCount = echoTool.JsonSchema.GetProperty("required").GetArrayLength();

            // Call a simple echo tool with a string argument

            if (tool1 != null)
            {


                // 构建参数
                var arguments = new Dictionary<string, object?>
                {
                    ["ak"] = $"{API_TOKEN}"


                };


                // Call a simple echo tool with a string argument

                var response = await mcpClient.CallToolAsync(tool1.Name, arguments);


                Console.WriteLine($"执行结果: {response.Content.FirstOrDefault()?.Text} \n response.Content.FirstOrDefault()?.Type}}");

            }

           // var response = await mcpClient.CallToolAsync(tool1.Name);


            Console.WriteLine("Hello, World!");
        }
    }
}
