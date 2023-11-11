using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FentonOpenAI
{
    public class OpenAIRequest
    {
        public OpenAIRequest(int maxTokens, string prompt)
        {
            MaxTokens = maxTokens;
            Prompt = prompt;
        }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 16;

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; } = 1.0M;

    }
}