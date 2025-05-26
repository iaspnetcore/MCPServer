using ModelContextProtocol.Client;




Console.WriteLine("Now connecting client to MCPSSEServer.Server ");



var clientTransport = new StdioClientTransport(new()
{
    Id = "time",
    Name = "Time MCP Server",
    TransportType = TransportTypes.Sse,
    Location = "https://localhost:8443/sse"
});



await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

Console.WriteLine("Successfully connected!");
