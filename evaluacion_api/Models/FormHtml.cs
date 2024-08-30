namespace evaluacion_api.Models
{
	public class FormHtml
	{
		public int Id { get; set; }
		public string Name { get; set; }
		List<InputHtml> InputHtml { get; set; }
		ButtonHtml Button { get; set; }
	}
}
