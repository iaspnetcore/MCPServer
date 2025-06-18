
An MCP server exposes a set of "tools" (functions or APIs) that AI clients can invoke to perform operations like fetching data, running computations, or accessing external services.




我们使用自然语言跟大模型交流，大模型选择一个合适工具函数，把函数名称还有参数返回给我，再使用Python具体执行这个函数，这个就是大模型Function Call的一个实现思路。

你是一个智能家居AI，你的根据用户输入返回对函数，必须从函数列表里面选，#后面备注了函数说明，如果能查找到功能的函数，你只需要输出函数加参数，参数就加引号写在函数的括号里，如果没有参数则不加。如果查寻不到任何函数，就输出"对不起，办不到"

                        
原文链接：https://blog.csdn.net/techshrimp/article/details/136186191