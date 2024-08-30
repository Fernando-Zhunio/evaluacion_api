using Microsoft.EntityFrameworkCore;

namespace evaluacion_api.Models
{
	public class InputHtml
	{
		public int Id { get; set; }
		public string name { get; set; }
		public InputType type { get; set; }
		public string placeholder { get; set; }
		public string label { get; set; }
		public string? value { get; set; }
		public List<Option>? options { get; set; }
		public int formHtmlId { get; set; }
		public FormHtml formHtml { get; set; }
	}


	public class Option
	{
		public int id { get; set; }
		public string value { get; set; }
		public string label { get; set; }
		public int inputHtmlId { get; set; }
		public InputHtml inputHtml { get; set; }
	}

	public enum InputType
	{
		text, number , date, email, password, file, color, range, select
	}

}

