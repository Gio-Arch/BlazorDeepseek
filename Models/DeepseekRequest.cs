namespace BlazorDeepseek.Models
{
	public class Message
	{
		public string role { get; set; } = "user";
		public string content { get; set; }
	}

	public class DeepseekRequest
	{
		public string model { get; set; } = "deepseek-chat";
		public List<Message> messages { get; set; } = [];
		public double temperature { get; set; } = 0.7;
		public int max_tokens { get; set; } = 300;
	}
}
