// For Client Developers

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

namespace MCPSSEServer.HA.Client
{


    class Program
    {


        private const string API_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI2OWI5NjdjNGM4MDI0MGY3YmM0MTA2OWI5NTdiYjY4MCIsImlhdCI6MTc0OTQ1MDc5NiwiZXhwIjoyMDY0ODEwNzk2fQ.Zk6fPKeNsCsdYlZtQFc7IR6Hfv1OtL8uys09lIUbP4o"; // "YOUR_LONG_LIVED_ACCESS_TOKEN";  //YOUR_LONG_LIVED_ACCESS_TOKEN
        private const string BASE_URL = "http://192.168.2.125:8123/mcp_server/sse"; //http://YOUR_HA_IP:8123/api

        static async Task Main(string[] args)
        {


            // Connect to an MCP server
            Console.WriteLine("Connecting client to  home assistant mcp server");

            // https://www.home-assistant.io/integrations/mcp_server#example-claude-for-desktop


            // Configure it connect to your MCP server.
            // 配置SSE传输
            // Get current subscriptions
            var transportOptions = new SseClientTransportOptions
            {
                Endpoint = new Uri(BASE_URL),
                AdditionalHeaders = new Dictionary<string, string>
               {
                  { "Authorization", $"Bearer {API_TOKEN}" }
               }
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

            foreach (var tool in listToolsResult)
            {
                Console.WriteLine($"  {tool}");
            }


            //step 3.CallTool
            // https://modelcontextprotocol.github.io/csharp-sdk/api/ModelContextProtocol.Client.McpClientExtensions.html
            var tool1 = listToolsResult.FirstOrDefault(t => t.Name == "HassTurnOff");

            //var echoTool = listToolsResult.FirstOrDefault(t => t.Name == "HassTurnOff");
            //// Access schema properties
            //string type = echoTool.JsonSchema.GetProperty("type").GetString();
            //JsonElement properties = echoTool.JsonSchema.GetProperty("properties");
            //string paramDescription = properties.GetProperty("message").GetProperty("description").GetString();
            //int requiredCount = echoTool.JsonSchema.GetProperty("required").GetArrayLength();


            if (tool1 != null)
            {
               

                // 构建参数
                var arguments = new Dictionary<string, object?>
                {
                    ["domain"] = "light",  // 设备类型（如light/switch）
                    ["entity_id"] = "light.lemesh_wy0c15_5cbc_light"
                   
                };

                var parameters2 = new Dictionary<string, object>
                {
                    ["domain"] = "light",  // 设备类型（如light/switch）
                    ["entity_id"] = "light.bedroom",  // 具体设备ID
                    ["area"] = "卧室"  // 可选区域标识
                };

                // Call a simple echo tool with a string argument
                
                var response = await mcpClient.CallToolAsync(tool1.Name, arguments);


                Console.WriteLine($"执行结果: {response.Content.FirstOrDefault()?.Text} \n response.Content.FirstOrDefault()?.Type}}");

            }
        }
    }


    public class Env
    {
        public string SSE_URL { get; set; }
        public string API_ACCESS_TOKEN { get; set; }
    }

    public class HomeAssistant
    {
        public string command { get; set; }
        public Env env { get; set; }
    }

    public class McpServers
    {

        public HomeAssistant HomeAssistant { get; set; }
    }

    public class Root
    {
        public McpServers mcpServers { get; set; }
    }

}