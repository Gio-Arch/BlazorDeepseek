﻿using Newtonsoft.Json;

namespace BlazorDeepseek.Models
{
	public class Choice
	{
		public int index { get; set; }
		public MessageResponse message { get; set; }
		public object logprobs { get; set; }
		public string finish_reason { get; set; }
	}

	public class MessageResponse
	{
		public string role { get; set; }
		public string content { get; set; }
	}

	public class PromptTokensDetails
	{
		public int cached_tokens { get; set; }
	}

	public class DeepseekResponse
	{
		public string id { get; set; }

		[JsonProperty("object")]
		public string objectResponse { get; set; }
		public int created { get; set; }
		public string model { get; set; }
		public List<Choice> choices { get; set; }
		public Usage usage { get; set; }
		public string system_fingerprint { get; set; }
	}

	public class Usage
	{
		public int prompt_tokens { get; set; }
		public int completion_tokens { get; set; }
		public int total_tokens { get; set; }
		public PromptTokensDetails prompt_tokens_details { get; set; }
		public int prompt_cache_hit_tokens { get; set; }
		public int prompt_cache_miss_tokens { get; set; }
	}


}
