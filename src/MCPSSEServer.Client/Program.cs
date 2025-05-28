
using ModelContextProtocol.Client; // 包含 McpClientFactory 和 McpClient 相关定义





Console.WriteLine("Now connecting client to MCPSSEServer.Server ");

try
{

    //1.Connect to an MCP server
    //创建一个 SSE（Server-Sent Events）客户端传输配置实例
    // 修改TransportType为SSE，指定SSE Server的BaseUrl
    var clientTransport = new SseClientTransport(

    // Method2:  TransportType = SSE 配置传输选项，指定服务端点（Endpoint）
    new SseClientTransportOptions()
    {
        // 设置远程服务器的 URI 地址  (记得替换真实的地址，从魔搭MCP广场获取)
        Endpoint = new Uri("http://localhost:5159/sse")
    }
    );




    //2. 使用配置创建 MCP 客户端实例 connect to the MCP server by providing the URL of the server. 
    await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);


    Console.WriteLine("Successfully connected!");


    //3.Get all available tools
    //调用客户端的 ListToolsAsync 方法，获取可用工具列表
    var listToolsResult = await mcpClient.ListToolsAsync();
    Console.WriteLine("功能列表:");

    // Get all available tools
    //遍历工具列表，并逐个输出到控制台
    foreach (var tool in listToolsResult)
    {
        Console.WriteLine($"  名称：{tool.Name}，说明：{tool.Description}");
    }


    //4.Execute a tool directly.
    //execute the tools we have defined and see the results
    var result = await mcpClient.CallToolAsync(
    "GetCurrentTime",
    new Dictionary<string, object?>() { ["city"] = "Chengdu" });

    Console.WriteLine(result.Content.First(c => c.Type == "text").Text);
}

catch (Exception ex)
{
    Console.WriteLine($"Host terminated unexpectedly : {ex.Message}");
}

