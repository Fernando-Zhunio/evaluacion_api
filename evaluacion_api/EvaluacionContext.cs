using evaluacion_api.Models;
using Microsoft.EntityFrameworkCore;

namespace evaluacion_api
{
	public class EvaluacionContext : DbContext
	{
		public DbSet<ButtonHtml> ButtonHtmls { get; set; }
		public DbSet<InputHtml> InputHtmls { get; set; }

		public string DbPath { get; }
		public EvaluacionContext(DbContextOptions<EvaluacionContext> options) : base(options)
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = System.IO.Path.Join(path, "evaluacion.db");
		}

		// The following configures EF to create a Sqlite database file in the
		// special "local" folder for your platform.
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FormHtml>().HasData(
				new FormHtml { Id = 1, Name = "Formulario 1" },
				new FormHtml { Id = 2, Name = "Formulario 2" }
				);

			// Configuración de seeding
			modelBuilder.Entity<ButtonHtml>().HasData(
				new ButtonHtml { Id = 1, Label = "Button A", FormHtmlId = 1, Color = null },
				new ButtonHtml { Id = 2, Label = "Button B", FormHtmlId = 2, Color = null }
			);

			modelBuilder.Entity<InputHtml>().HasData(
				new InputHtml { Id = 1, label = "Nombres", placeholder = "Ingrese sus nombres", formHtmlId = 1, name = "name", type = InputType.text, value = null },
				new InputHtml { Id = 2, label = "Fecha de nacimiento", placeholder = "Ingrese fecha de nacimiento", formHtmlId = 1, name = "birthday", type = InputType.date, value = null },
				new InputHtml { Id = 3, label = "Estatura", placeholder = "Ingrese estatura", formHtmlId = 1, name = "name", type = InputType.number, value = null }
				//new InputHtml { Id = 4, label = "Nombres", placeholder = "Ingrese sus nombres", formHtmlId = 1, name = "name", type = InputType.text, value = null },
				);

		}
	}




}
