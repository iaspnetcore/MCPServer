using ModelContextProtocol.Client;




Console.WriteLine("Now connecting client to MCP server");



var clientTransport = new StdioClientTransport(new()
{
    Name = "Demo Server",
  
    Command = "npx",
    Arguments = ["-y", "@modelcontextprotocol/server-everything"],
});



await using var mcpClient = await McpClientFactory.CreateAsync(clientTransport);

Console.WriteLine("Successfully connected!");
