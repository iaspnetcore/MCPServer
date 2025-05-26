
F:\developer_mcp

https://github.com/iaspnetcore/MCPServer.git/

blog:https://www.iaspnetcore.com/blogpost-683332645fb02c0677df0289-mcp-server-in-c-net




The WithToolsFromAssembly will scan the assembly for classes with the McpServerToolType attribute and register all methods with the McpServerTool attribute. Notice that the McpServerTool has a Description which will be fed into any client connecting to the server. This description helps the client determine which tool to call.