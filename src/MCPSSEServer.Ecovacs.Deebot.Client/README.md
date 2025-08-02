# For MCP Client Developers

Create a server-sent event MCP client.

The remote MCP server URL for the SSE endpoint, for example https://mcp-open.ecovacs.com/sse?ak=your ak

mcp server

mcp server for ecovacs

https://mcp-open.ecovacs.com/sse?ak=your ak


Offcial Document:https://open.ecovacs.com/#/serviceOverview

GitHub Repository:https://github.com/ecovacs-ai/ecovacs-mcp

## How to use

step 1. get ak

I got an API key by logging into my ecovacs account

https://open.ecovacs.cn/#/preparationForUse



step 2. connect mcp server

// For regions outside Mainland China, configure as https://mcp-open.ecovacs.com/sse?ak=your ak



step 3. list tools

~~~~
Tools available:
功能列表:
  名称：get_device_list，说明：获取机器列表 JSON Schema: {"type":"object","properties":{},"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  名称：get_work_state，说明：获取机器人工作状态 JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"}},"required":["nickname"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  名称：set_charging，说明：设置充电状态 JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"},"act":{"type":"string","description":"Machine behavior, go-start start charging, stopGo end charging"}},"required":["nickname","act"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  名称：set_cleaning，说明：设置清扫状态 JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"},"act":{"type":"string","description":"Cleaning action, s-start cleaning, r-resume cleaning, p-pause cleaning, h-stop cleaning"}},"required":["nickname","act"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}


~~~~

step 4. call tool

