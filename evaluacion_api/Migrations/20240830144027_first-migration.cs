using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace evaluacion_api.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormHtml",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormHtml", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ButtonHtmls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    FormHtmlId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonHtmls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ButtonHtmls_FormHtml_FormHtmlId",
                        column: x => x.FormHtmlId,
                        principalTable: "FormHtml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputHtmls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    placeholder = table.Column<string>(type: "TEXT", nullable: false),
                    label = table.Column<string>(type: "TEXT", nullable: false),
                    value = table.Column<string>(type: "TEXT", nullable: true),
                    formHtmlId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputHtmls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputHtmls_FormHtml_formHtmlId",
                        column: x => x.formHtmlId,
                        principalTable: "FormHtml",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    value = table.Column<string>(type: "TEXT", nullable: false),
                    label = table.Column<string>(type: "TEXT", nullable: false),
                    inputHtmlId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.id);
                    table.ForeignKey(
                        name: "FK_Option_InputHtmls_inputHtmlId",
                        column: x => x.inputHtmlId,
                        principalTable: "InputHtmls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FormHtml",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Formulario 1" },
                    { 2, "Formulario 2" }
                });

            migrationBuilder.InsertData(
                table: "ButtonHtmls",
                columns: new[] { "Id", "Color", "FormHtmlId", "Label" },
                values: new object[,]
                {
                    { 1, null, 1, "Button A" },
                    { 2, null, 2, "Button B" }
                });

            migrationBuilder.InsertData(
                table: "InputHtmls",
                columns: new[] { "Id", "formHtmlId", "label", "name", "placeholder", "type", "value" },
                values: new object[,]
                {
                    { 1, 1, "Nombres", "name", "Ingrese sus nombres", 0, null },
                    { 2, 1, "Fecha de nacimiento", "birthday", "Ingrese fecha de nacimiento", 2, null },
                    { 3, 1, "Estatura", "name", "Ingrese estatura", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ButtonHtmls_FormHtmlId",
                table: "ButtonHtmls",
                column: "FormHtmlId");

            migrationBuilder.CreateIndex(
                name: "IX_InputHtmls_formHtmlId",
                table: "InputHtmls",
                column: "formHtmlId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_inputHtmlId",
                table: "Option",
                column: "inputHtmlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButtonHtmls");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "InputHtmls");

            migrationBuilder.DropTable(
                name: "FormHtml");
        }
    }
}
