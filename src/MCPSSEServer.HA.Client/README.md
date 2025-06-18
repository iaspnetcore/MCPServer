# For MCP Client Developers

Create a server-sent event MCP client.

The remote MCP server URL for the SSE endpoint, for example http://192.168.2.50:8123/mcp_server/sse

mcp server

mcp server in home assistant

http://192.168.2.125:8123/mcp_server/sse


## How to use

1. ȷ��Home Assistant MCP Server����ȷע��




2. homeassistant-mcp-server.py

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

3.Before you can use tools provided by an MCP server, you need to discover what tools are available and understand their parameters.

Listing All Tools

Each McpClientTool contains metadata about the tool, including:

Name: The tool's identifier
Description: A human-readable description of what the tool does
JsonSchema: JSON Schema describing the tool's parameters

 ���ƣ�HassTurnOn��
 ˵����Turns on/opens/presses a device or entity. For locks, this performs a 'lock' action. Use for requests like 'turn on', 'activate', 'enable', or 'lock'. 
 JSON Schema: {"type":"object","properties":{"name":{"type":"string"},"area":{"type":"string"},"floor":{"type":"string"},"domain":{"type":"array","items":{"type":"string"}},"device_class":{"type":"array","items":{"type":"string","enum":["identify","restart","update","awning","blind","curtain","damper","door","garage","gate","shade","shutter","window","water","gas","outlet","switch","tv","speaker","receiver"]}}}}

 ~~~
 {
    "type": "object",
    "properties": {
        "name": {
            "type": "string"
        },
        "area": {
            "type": "string"
        },
        "floor": {
            "type": "string"
        },
        "domain": {
            "type": "array",
            "items": {
                "type": "string"
            }
        },
        "device_class": {
            "type": "array",
            "items": {
                "type": "string",
                "enum": [
                    "identify",
                    "restart",
                    "update",
                    "awning",
                    "blind",
                    "curtain",
                    "damper",
                    "door",
                    "garage",
                    "gate",
                    "shade",
                    "shutter",
                    "window",
                    "water",
                    "gas",
                    "outlet",
                    "switch",
                    "tv",
                    "speaker",
                    "receiver"
                ]
            }
        }
    }
}
 ~~~