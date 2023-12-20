using Azure.AI.OpenAI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.TextGeneration;

namespace QwenServiceCollectionExtensions
{
    public static class QwenServiceCollectionExtensions
    {
        public static IKernelBuilder AddQwenChatCompletion(this IKernelBuilder builder, string modelId, string apiKey, string url, string? orgId = null, string? serviceId = null, HttpClient? httpClient = null)
        {
            string modelId2 = modelId;
            string apiKey2 = apiKey;
            string orgId2 = orgId;
            HttpClient httpClient2 = httpClient;

            Func<IServiceProvider, object, OpenAIChatCompletionService> implementationFactory = (IServiceProvider serviceProvider, object? _) => new OpenAIChatCompletionService(modelId, new OpenAIClient( new Uri(url), new Azure.AzureKeyCredential(apiKey)), serviceProvider.GetService<ILoggerFactory>());
            builder.Services.AddKeyedSingleton((object?)serviceId, (Func<IServiceProvider, object?, IChatCompletionService>)implementationFactory);
            builder.Services.AddKeyedSingleton((object?)serviceId, (Func<IServiceProvider, object?, ITextGenerationService>)implementationFactory);
            return builder;
        }
    }
}
