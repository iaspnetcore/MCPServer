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
    @McpServerTool(description="����Home Assistant�豸����")
    def HassTurnOn(self, entity_id: str):
        # ����HA APIʵ���豸�����߼�
        return {"status": "success", "message": f"{entity_id}�ѿ���"}

    @McpServerTool(description="����Home Assistant�豸�ر�")
    def HassTurnOff(self, entity_id: str):
        # ����HA APIʵ���豸�ر��߼�
        return {"status": "success", "message": f"{entity_id}�ѹر�"}

if __name__ == "__main__":
    server = McpServer()
    server.add_tool(HassTool())
    server.run()

~~~