using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McpServerConsole.Server.Tools
{
    [McpServerToolType]
    public static class TimeTool
    {
        [McpServerTool, Description("Get the current time for a city")]
        public static string GetCurrentTime(string city) =>
            $"It is {DateTime.Now.Hour}:{DateTime.Now.Minute} in {city}.";
    }
}
