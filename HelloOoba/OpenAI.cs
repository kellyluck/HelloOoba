using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenAI
{
    public class OpenAIRequest
    {
        public OpenAIRequest(string model, string prompt, int maxTokens, string role = "user")
        {
            MaxTokens = maxTokens;
            Messages = new List<MessageStuff>();
            Messages.Add(new MessageStuff() { Role = role, Content = prompt });
            Model = model;
        }

        [JsonPropertyName("messages")]
        public List<MessageStuff> Messages { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 99;

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; } = 1.0M;

    }

    public class OpenAIResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("created")]
        public int Created { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("logprobs")]
        public object LogProbs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string FinishReason { get; set; }

        [JsonPropertyName("message")]
        public MessageStuff Message { get; set; }
    }

    public class MessageStuff
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}