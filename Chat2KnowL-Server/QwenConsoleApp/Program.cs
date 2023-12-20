using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = Kernel.CreateBuilder();

builder.AddQwenChatCompletion(
         "Qwen", "none", "http://20.127.159.255:8000/v1"
         );

var kernel = builder.Build();

//等待用户输入
Console.Write("用户：");
var input = Console.ReadLine();

//循环对话
while (input != "quit")
{
    var prompt = @$"<message role=""user"">{input}</message>";
    var summarize = kernel.CreateFunctionFromPrompt(prompt, executionSettings: new OpenAIPromptExecutionSettings { MaxTokens = 100 });
    var result = kernel.InvokeStreamingAsync(summarize);
    Console.Write("OpenAI：");
    await foreach (var item in result)
    {
        Console.Write(item.ToString());
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.Write("用户：");
    input = Console.ReadLine();
}
