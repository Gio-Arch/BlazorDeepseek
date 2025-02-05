using BlazorDeepseek.Models;
using Markdig;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace BlazorDeepseek.Services
{
	public class DeepSeekService
	{
		private readonly RestClient _client;
		private readonly string _apiKey;

		public DeepSeekService(IConfiguration configuration)
		{
			_apiKey = configuration["DEEPSEEK_API_KEY"] ?? "";
			_client = new RestClient(configuration["DEEPSEEK_BASE_URL"] ?? "");
			_client.AddDefaultHeader("Authorization", $"Bearer {_apiKey}");
			_client.AddDefaultHeader("Content-Type", "application/json");
		}

		public async Task<string> SendMessageAsync(string userMessage)
		{
			string retVal;
			//var request = new RestRequest
			//{
			//	Method = Method.Post
			//};

			//DeepseekRequest deepseekRequest = new() { messages = [new() { content = userMessage }] };

			//request.AddJsonBody(deepseekRequest);
			//try
			//{

			//	RestResponse<DeepseekResponse> response = await _client.ExecuteAsync<DeepseekResponse>(request);
			//	if (!response.IsSuccessful)
			//	{
			//		throw new Exception($"Error: {response.StatusCode} - {response.ErrorMessage}");
			//	}
			//	retVal = response.Data?.choices?.FirstOrDefault()?.message?.content ?? "No response from DeepSeek.";
			//}
			//catch (Exception e)
			//{
			//	retVal = $"No response from DeepSeek. {e.Message}";
			//}
			//return $"{retVal}";


			//var fake = "{\r\n    \"id\": \"7a789fc5-ff31-45aa-bca6-ca605e319aa2\",\r\n    \"object\": \"chat.completion\",\r\n    \"created\": 1738777724,\r\n    \"model\": \"deepseek-chat\",\r\n    \"choices\": [\r\n        {\r\n            \"index\": 0,\r\n            \"message\": {\r\n                \"role\": \"assistant\",\r\n                \"content\": \"Quantum computing is a type of computing that uses the principles of quantum mechanics to process information. Unlike classical computers, which use bits as the smallest unit of information (which can be either 0 or 1), quantum computers use quantum bits, or qubits. Qubits can exist in a state of 0, 1, or any quantum superposition of these states. This means that a qubit can be in multiple states at once, a phenomenon known as superposition.\\n\\nAnother key principle of quantum mechanics that quantum computing leverages is entanglement. When qubits become entangled, the state of one qubit can depend on the state of another, no matter how far apart they are. This allows quantum computers to perform many calculations at once, potentially solving certain types of problems much faster than classical computers.\\n\\nQuantum computers are particularly well-suited for tasks that involve complex simulations, optimization problems, and factoring large numbers, which is important for cryptography. However, they are not intended to replace classical computers but rather to handle specific problems that are currently intractable for classical systems.\\n\\nIt's important to note that quantum computing is still in the early stages of development, and practical, large-scale quantum computers are not yet available. Researchers are working on overcoming significant challenges, such as quantum decoherence and error correction, to make quantum computing more reliable and scalable.\"\r\n            },\r\n            \"logprobs\": null,\r\n            \"finish_reason\": \"stop\"\r\n        }\r\n    ],\r\n    \"usage\": {\r\n        \"prompt_tokens\": 9,\r\n        \"completion_tokens\": 267,\r\n        \"total_tokens\": 276,\r\n        \"prompt_tokens_details\": {\r\n            \"cached_tokens\": 0\r\n        },\r\n        \"prompt_cache_hit_tokens\": 0,\r\n        \"prompt_cache_miss_tokens\": 9\r\n    },\r\n    \"system_fingerprint\": \"fp_3a5770e1b4\"\r\n}";
			var fake = "{\r\n   \"id\":\"7a789fc5-ff31-45aa-bca6-ca605e319aa2\",\r\n   \"object\":\"chat.completion\",\r\n   \"created\":1738777724,\r\n   \"model\":\"deepseek-chat\",\r\n   \"choices\":[\r\n      {\r\n         \"index\":0,\r\n         \"message\":{\r\n            \"role\":\"assistant\",\r\n            \"content\":\"Valentino Rossi, often referred to as The Doctor, is one of the most iconic and successful motorcycle racers in the history of the sport. Born on February 16, 1979, in Urbino, Italy, Rossi has won multiple World Championships across different classes, including 125cc, 250cc, 500cc, and MotoGP. ### Career Highlights: - **Grand Prix World Championships**: Rossi has won a total of 9 Grand Prix World Championships, including 7 in the premier class (MotoGP/500cc). - **Teams**: He has raced for several top teams, including Honda, Yamaha, and Ducati. His most successful years were with Yamaha, where he won four consecutive MotoGP titles from 2004 to 2008. - **Records**: Rossi holds numerous records, including the most premier class podiums and the most consecutive podium finishes. - **Rivalries**: His career has been marked by intense rivalries with other legendary riders like Max Biaggi, Sete Gibernau, Casey Stoner, Jorge Lorenzo, and Marc Márquez. ### Personal Style: - **Helmet Designs**: Rossi is known for his distinctive and ever-changing helmet designs, often featuring his iconic sun and moon motif. - **Personality**: His charismatic personality and sense of humor have made him a fan favorite worldwide. He is known for his post-race celebrations, which often include theatrical stunts and costumes.\"\r\n         },\r\n         \"logprobs\":null,\r\n         \"finish_reason\":\"stop\"\r\n      }\r\n   ],\r\n   \"usage\":{\r\n      \"prompt_tokens\":9,\r\n      \"completion_tokens\":267,\r\n      \"total_tokens\":276,\r\n      \"prompt_tokens_details\":{\r\n         \"cached_tokens\":0\r\n      },\r\n      \"prompt_cache_hit_tokens\":0,\r\n      \"prompt_cache_miss_tokens\":9\r\n   },\r\n   \"system_fingerprint\":\"fp_3a5770e1b4\"\r\n}";
			var response = JsonConvert.DeserializeObject<DeepseekResponse>(fake);
            

			retVal = response?.choices?.FirstOrDefault()?.message?.content ?? "No response from DeepSeek.";
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            var html = Markdown.ToHtml(retVal, pipeline);
            return $"{html}";
        }
	}
}