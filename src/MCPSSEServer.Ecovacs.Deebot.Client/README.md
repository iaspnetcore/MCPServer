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
�����б�:
  ���ƣ�get_device_list��˵������ȡ�����б� JSON Schema: {"type":"object","properties":{},"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  ���ƣ�get_work_state��˵������ȡ�����˹���״̬ JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"}},"required":["nickname"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  ���ƣ�set_charging��˵�������ó��״̬ JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"},"act":{"type":"string","description":"Machine behavior, go-start start charging, stopGo end charging"}},"required":["nickname","act"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}
  ���ƣ�set_cleaning��˵����������ɨ״̬ JSON Schema: {"type":"object","properties":{"nickname":{"type":"string","description":"Robot nickname, for device lookup"},"act":{"type":"string","description":"Cleaning action, s-start cleaning, r-resume cleaning, p-pause cleaning, h-stop cleaning"}},"required":["nickname","act"],"additionalProperties":false,"$schema":"http://json-schema.org/draft-07/schema#"}


~~~~

step 4. call tool

