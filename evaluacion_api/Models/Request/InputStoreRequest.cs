using System.ComponentModel.DataAnnotations;

namespace evaluacion_api.Models.Request
{
	public class InputStoreRequest
	{
		//public int Id { get; set; }
		[Required]
		public string name { get; set; }
		[Required]
		public InputType type { get; set; }
		[Required]
		public string placeholder { get; set; }
		[Required]
		public string label { get; set; }
		[Required]
		public string? value { get; set; }
		[Required]
		//public List<Option>? options { get; set; }
		public int formHtmlId { get; set; }
	}
}
