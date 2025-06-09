// For Client Developers

using Microsoft.Extensions.Hosting;
using ModelContextProtocol;
using ModelContextProtocol.Client;
using ModelContextProtocol.Server;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MCPSSEServer.HA.Client
{


    class Program
    {
        
        
        private const string API_TOKEN = "YOUR_LONG_LIVED_ACCESS_TOKEN";  //YOUR_LONG_LIVED_ACCESS_TOKEN
        private const string BASE_URL = "http://192.168.2.125:8123/mcp_server/sse"; //http://YOUR_HA_IP:8123/api

        static async Task Main(string[] args)
        {
            Console.WriteLine("Now connecting client to MCPSSEServer.Server,Starting MCP client... ");

            // https://www.home-assistant.io/integrations/mcp_server#example-claude-for-desktop

            Root root = new Root();

            root.mcpServers.HomeAssistant.command = "mcp-proxy";

            root.mcpServers.HomeAssistant.env.SSE_URL = "http://192.168.2.125:8123/mcp_server/sse";

            root.mcpServers.HomeAssistant.env.API_ACCESS_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI2OWI5NjdjNGM4MDI0MGY3YmM0MTA2OWI5NTdiYjY4MCIsImlhdCI6MTc0OTQ1MDc5NiwiZXhwIjoyMDY0ODEwNzk2fQ.Zk6fPKeNsCsdYlZtQFc7IR6Hfv1OtL8uys09lIUbP4o";

            
            var clientTransport = new SseClientTransport(

   // Method2:  TransportType = SSE 配置传输选项，指定服务端点（Endpoint）
   new SseClientTransportOptions()
   {
       // 设置远程服务器的 URI 地址  (记得替换真实的地址，从魔搭MCP广场获取)
       Endpoint = new Uri("http://192.168.2.125:8123/mcp_server/sse")
   }
   );

 
            var  mcpClientOptions = new McpClientOptions();

          

            //2. 使用配置创建 MCP 客户端实例 connect to the MCP server by providing the URL of the server. 
            await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

            

            Console.WriteLine("Successfully connected!");
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