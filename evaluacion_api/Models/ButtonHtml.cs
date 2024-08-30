namespace evaluacion_api.Models
{
	public class ButtonHtml
	{
		
		public int Id { get; set; }
		public string Label { get; set; }
		public string? Color { get; set; }
		public int FormHtmlId { get; set; }
		public FormHtml FormHtml { get; set; }
	}
}
