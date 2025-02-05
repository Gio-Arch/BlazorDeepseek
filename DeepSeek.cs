namespace BlazorDeepseek.Models
{
	public class ChatRequest
	{
		public string Model { get; set; } = "deepseek-chat";
		public List<ChatMessage> Messages { get; set; } = [];
		public bool Stream { get; set; } = false;
	}

	public class ChatMessage
	{
		public string Role { get; set; } = "";
		public string Content { get; set; } = "";
	}

	public class ChatResponse
	{
		public string Id { get; set; } = "";
		public string Object { get; set; } = "";
		public long Created { get; set; }
		public string Model { get; set; } = "";
		public List<ChatChoice> Choices { get; set; } = [];
	}

	public class ChatChoice
	{
		public ChatMessage Message { get; set; } = new();
		public int Index { get; set; }
		public string FinishReason { get; set; } = "";
	}
}
