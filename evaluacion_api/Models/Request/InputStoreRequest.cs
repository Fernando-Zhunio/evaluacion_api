namespace evaluacion_api.Models.Request
{
	public class InputStoreRequest
	{
		//public int Id { get; set; }
		public string name { get; set; }
		public InputType type { get; set; }
		public string placeholder { get; set; }
		public string label { get; set; }
		public string? value { get; set; }
		//public List<Option>? options { get; set; }
		public int formHtmlId { get; set; }
	}
}
