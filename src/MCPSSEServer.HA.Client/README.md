# For MCP Client Developers

Create a server-sent event MCP client.

The remote MCP server URL for the SSE endpoint, for example http://192.168.2.50:8123/mcp_server/sse

mcp server

mcp server in home assistant

http://192.168.2.125:8123/mcp_server/sse


## homeassistant-mcp-server.py

~~~
# homeassistant-mcp-server.py
from modelcontextprotocol.server import McpServer, McpServerTool

class HassTool(McpServerTool):
    @McpServerTool(description="控制Home Assistant设备开关")
    def HassTurnOn(self, entity_id: str):
        # 调用HA API实现设备开启逻辑
        return {"status": "success", "message": f"{entity_id}已开启"}

    @McpServerTool(description="控制Home Assistant设备关闭")
    def HassTurnOff(self, entity_id: str):
        # 调用HA API实现设备关闭逻辑
        return {"status": "success", "message": f"{entity_id}已关闭"}

if __name__ == "__main__":
    server = McpServer()
    server.add_tool(HassTool())
    server.run()

~~~