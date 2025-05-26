using ModelContextProtocol.Server;
using System.ComponentModel;


namespace MCPSSEServer.Server.Tools
{

    /// <summary>
    /// 静态类型 不能用作 参数 WithTools<TimeTool>();
    /// </summary>
    [McpServerToolType]
    public  class TimeTool
    {
        [McpServerTool, Description("Get the current time for a city")]
        public static string GetCurrentTime(string city) =>
            $"It is {DateTime.Now.Hour}:{DateTime.Now.Minute} in {city}.";
    }
}
