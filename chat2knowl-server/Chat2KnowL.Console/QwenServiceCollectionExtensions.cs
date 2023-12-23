using Azure.AI.OpenAI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.TextGeneration;

namespace Chat2KnowL.Console
{
    public static class QwenServiceCollectionExtensions
    {
        /// <summary>
        /// 添加通义千问聊天服务
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="modelId"></param>
        /// <param name="apiKey"></param>
        /// <param name="url"></param>
        /// <param name="orgId"></param>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public static IKernelBuilder AddQwenChatCompletion(this IKernelBuilder builder, string modelId, string apiKey, string url, string? orgId = null, string? serviceId = null)
        {
            string modelId2 = modelId;
            string apiKey2 = apiKey;
            string orgId2 = orgId;

            Func<IServiceProvider, object, OpenAIChatCompletionService> implementationFactory = (IServiceProvider serviceProvider, object? _) => new OpenAIChatCompletionService(modelId, new OpenAIClient(new Uri(url), new Azure.AzureKeyCredential(apiKey)), serviceProvider.GetService<ILoggerFactory>());
            builder.Services.AddKeyedSingleton((object?)serviceId, (Func<IServiceProvider, object?, IChatCompletionService>)implementationFactory);
            builder.Services.AddKeyedSingleton((object?)serviceId, (Func<IServiceProvider, object?, ITextGenerationService>)implementationFactory);
            return builder;
        }
    }
}
