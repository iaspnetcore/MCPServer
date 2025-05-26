
using ModelContextProtocol.Client; // 包含 McpClientFactory 和 McpClient 相关定义





Console.WriteLine("Now connecting client to MCPSSEServer.Server ");

try
{

    // 创建一个 SSE（Server-Sent Events）客户端传输配置实例
    var clientTransport = new SseClientTransport(

    // 配置传输选项，指定服务端点（Endpoint）
    new SseClientTransportOptions()
    {
        // 设置远程服务器的 URI 地址  (记得替换真实的地址，从魔搭MCP广场获取)
        Endpoint = new Uri("https://mcp.api-inference.modelscope.cn/sse/215e9461d2xxxxx")
    }
    );




    // 使用配置创建 MCP 客户端实例
    await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);


    Console.WriteLine("Successfully connected!");
}

catch (Exception ex)
{
    Console.WriteLine($"Host terminated unexpectedly : {ex.Message}");
}

