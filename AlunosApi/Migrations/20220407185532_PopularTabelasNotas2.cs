using Microsoft.EntityFrameworkCore.Migrations;

namespace AlunosApi.Migrations
{
    public partial class PopularTabelasNotas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notas",
                keyColumn: "IdNotas",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "Matemática" },
                    { 2, "Inglês" }
                });

            migrationBuilder.InsertData(
                table: "Notas",
                columns: new[] { "IdNotas", "AlunoId", "IdAluno", "IdDisciplina" },
                values: new object[,]
                {
                    { 1, null, 1, 2 },
                    { 2, null, 1, 1 },
                    { 3, null, 2, 2 },
                    { 4, null, 2, 1 }
                });
        }
    }
}
