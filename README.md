
F:\developer_mcp

https://github.com/iaspnetcore/MCPServer.git/

blog:https://www.iaspnetcore.com/blogpost-683332645fb02c0677df0289-mcp-server-in-c-net




The WithToolsFromAssembly will scan the assembly for classes with the McpServerToolType attribute and register all methods with the McpServerTool attribute. Notice that the McpServerTool has a Description which will be fed into any client connecting to the server. This description helps the client determine which tool to call.

## Projects

### MCPServer WithStdioServerTransport

### MCPServer WithHttpTransport(SSE)

[MCPSSEServer.Server](https://github.com/iaspnetcore/MCPServer/tree/master/src/MCPSSEServer.Server) A Simple .NET C# MCP Server using SSE transport using modelcontextprotocol / csharp-sdk



The Server-Sent Events (SSE) transport enables HTTP-based communication between the MCP server and clients. It uses SSE for server-to-client messages and HTTP POST for client-to-server messages.



The Server = where tools live

The Client = who sends tool requests

The Agent = The customer (who decides what tool to use)

The Tools = The recipes (the code that gets executed)